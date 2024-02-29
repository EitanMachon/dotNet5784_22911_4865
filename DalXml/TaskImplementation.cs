using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DO;
using DalXml;
using Dal;
using System.Xml.Linq;
using System.Data;
namespace DalXml;

internal class TaskImplementation : ITask // this class implement ITask interface
{
    readonly string tasks_xml = "tasks"; // the file name to save the tasks

    public int Create(DO.Task _item)       // this func get an engineer and add it to the list
    {
        var _id = Config.TaskId;
        List<DO.Task> _TaskList = XMLTools.LoadListFromXMLSerializer<DO.Task>(tasks_xml); // load the list from the file
        _TaskList.Add(_item with { Id = _id }); // add the engineer to the list
        XMLTools.SaveListToXMLSerializer(_TaskList, tasks_xml); // save the list to the file
        return _id; // return the id of the engineer
    }

    public void Delete(int id)
    {
        XElement taskList = XMLTools.LoadListFromXMLElement(tasks_xml); // load the list from the file
        XElement task = taskList.Elements().Where(e => int.Parse(e.Element("Id").Value) == id).FirstOrDefault(); // find the task with the given id
        if (task != null) // if the task exist
        {
            task.Remove(); // remove the task from the list
            XMLTools.SaveListToXMLElement(taskList, tasks_xml); // save the list to the file
        }
        else // if the task does not exist throw an exception
            throw new InvalidOperationException($"Task with ID {id} does not exist."); // if the task does not exist throw an exception
    }

    static DO.Task xmlToTask(XElement xml)
    {
        TimeSpan? timeSpan = TimeSpan.TryParse((string?)xml.Element("RequiredEffort"), out var result) ? (TimeSpan?)result : null;

        return new DO.Task(
            (int)(xml.ToIntNullable("Id")),
            xml.Element("Alias")!.Value,
            xml.Element("Description")!.Value,
            (DateTime)(xml.ToDateTimeNullable("CreatedAtDate")!),
            timeSpan == null ? new TimeSpan() : (TimeSpan)(timeSpan!),
            xml.ToEnumNullable<EngineerExperience>("Copmlexity"),
            xml.ToDateTimeNullable("StartDate"),
            xml.ToDateTimeNullable("ScheduledTime"),
            xml.ToDateTimeNullable("DeadLinetime"),
            xml.ToDateTimeNullable("ComplateTime"),
            xml.Element("Dekiverables")?.Value,
            xml.Element("Remarks")?.Value ?? "",
            (int)(xml.ToIntNullable("EngineerId")!)
            );
    }

    public DO.Task? Read(int id) // this func get an id and return the task with this id
    {
        XElement xElement = XMLTools.LoadListFromXMLElement(tasks_xml); // load the list from the file
        XElement task = xElement.Elements().Where(e => int.Parse(e.Element("Id").Value) == id).FirstOrDefault(); // find the task with the given id
        if (task != null) // if the task exist
            return xmlToTask(task); // return the task
        else // if the task does not exist throw an exception
            throw new InvalidOperationException($"Task with ID {id} does not exist."); // if the task does not exist throw an exception
    }

    public DO.Task? Read(Func<DO.Task, bool> filter)
    {
        XElement xElement = XMLTools.LoadListFromXMLElement(tasks_xml); // load the list from the file
        XElement? task = xElement.Elements().Where(e => filter(xmlToTask(e))).FirstOrDefault(); // find the task with the given id
        if (task != null) // if the task exist
            return xmlToTask(task); // return the task
        else // if the task does not exist throw an exception
            return null;
    }

    public IEnumerable<DO.Task?> ReadAll(Func<DO.Task, bool>? filter = null) // this func return all the tasks
    {
        List<DO.Task> tasksList = XMLTools.LoadListFromXMLSerializer<DO.Task>(tasks_xml); // load the list from the file
        if (filter == null) //  if there is no filter
            return tasksList; // return the list
        else // if there is a filter
            return tasksList.Where(filter); // return the list that match the filter
    }

    public void Update(DO.Task item)
    {
        XElement taskList = XMLTools.LoadListFromXMLElement(tasks_xml); // load the list from the file
        XElement? task = taskList.Elements().Where(e => e.ToIntNullable("Id") == item.Id).FirstOrDefault(); // find the task with the given id
        if (task != null) // if the task exist
        {
            //task.Remove(); // remove the task from the list
            //taskList.Add(item); // add the new task to the list

            // update the task by the given task
            task.Element("Alias")!.Value = item.Alias;
            task.Element("Description")!.Value = item.Description;
            task.Element("CreatedAtDate")!.Value = item.CreatedAtDate.ToString();
            task.Element("RequiredEffort")!.Value = item.RequiredEffort.ToString();
            task.Element("Copmlexity")!.Value = item.Copmlexity != null ? item.Copmlexity!.ToString() : null;
            task.Element("StartDate")!.Value = item.StartDate != null ? item.StartDate.ToString() : null;
            task.Element("ScheduledTime")!.Value = item.ScheduledTime != null ? item.ScheduledTime.ToString() : null;
            task.Element("DeadLinetime")!.Value = item.DeadLinetime != null ? item.DeadLinetime.ToString() : null;
            task.Element("ComplateTime")!.Value = item.ComplateTime != null ? item.ComplateTime.ToString() : null;
            task.Element("Dekiverables")!.Value = item.Dekiverables != null ? item.Dekiverables : null;
            if (item.Remarks != null)
                task.Element("Remarks")!.Value = item.Remarks;
            task.Element("EngineerId")!.Value = item.EngineerId.ToString();

            XMLTools.SaveListToXMLElement(taskList, tasks_xml); // save the list to the file
        }
        else // if the task does not exist throw an exception
            throw new InvalidOperationException($"Task with ID {item.Id} does not exist."); // if the task does not exist throw an exception
    }
}


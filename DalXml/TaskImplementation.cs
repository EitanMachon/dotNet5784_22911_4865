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
namespace DalXml;

internal class TaskImplementation : ITask // this class implement ITask interface
{
    readonly string tasks_xml = "tasks"; // the file name to save the tasks

        public int Create(DO.Task _item)       // this func get an engineer and add it to the list
        {
            var id = Config.TaskId;
            List<DO.Task> _TaskList = XMLTools.LoadListFromXMLSerializer<DO.Task>(tasks_xml); // load the list from the file
            _TaskList.Add(_item with { Id=id}); // add the engineer to the list
            XMLTools.SaveListToXMLSerializer(_TaskList, tasks_xml); // save the list to the file
            return id; // return the id of the engineer
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
    public DO.Task? Read(int id) // this func get an id and return the task with this id
    {
        XElement xElement = XMLTools.LoadListFromXMLElement(tasks_xml); // load the list from the file
        XElement task = xElement.Elements().Where(e => int.Parse(e.Element("Id").Value) == id).FirstOrDefault(); // find the task with the given id
        if (task != null) // if the task exist
            return (DO.Task)task; // return the task
        else // if the task does not exist throw an exception
            throw new InvalidOperationException($"Task with ID {id} does not exist."); // if the task does not exist throw an exception
    }

    public DO.Task? Read(Func<DO.Task, bool> filter)
    {
        XElement xElement = XMLTools.LoadListFromXMLElement(tasks_xml); // load the list from the file
        XElement task = xElement.Elements().Where(e => filter((DO.Task)e)).FirstOrDefault(); // find the task with the given id
        if (task != null) // if the task exist
            return (DO.Task)task; // return the task
        else // if the task does not exist throw an exception
            throw new Exception($"Task with ID {task.Element("Id").Value} does not exist."); // if the task does not exist throw an exception
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
        XElement task = taskList.Elements().Where(e => int.Parse(e.Element("Id").Value) == item.Id).FirstOrDefault(); // find the task with the given id
        if (task != null) // if the task exist
        {
            task.Remove(); // remove the task from the list
            taskList.Add(item); // add the new task to the list
            XMLTools.SaveListToXMLElement(taskList, tasks_xml); // save the list to the file
        }
        else // if the task does not exist throw an exception
            throw new InvalidOperationException($"Task with ID {item.Id} does not exist."); // if the task does not exist throw an exception
        
    }
}

   
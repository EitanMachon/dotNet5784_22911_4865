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

    

    public DO.Task? Read(int id)
    {
        List<DO.Task> tasks = XMLTools.LoadListFromXMLSerializer<DO.Task>("tasks");
        DO.Task? t = tasks.FirstOrDefault((item => item != null && item.Id == id), null);
        //if there is a task with that id in the list - return it using linq expansion methode.
        return t;

    }

    /// <summary>
    /// This function search for Task in the Tasks list from the XML file according to a filter function. 
    /// then, return the Task.
    /// </summary>
    public DO.Task? Read(Func<DO.Task?, bool> filter)
    {
        List<DO.Task> tasks = XMLTools.LoadListFromXMLSerializer<DO.Task>("tasks");
        DO.Task? t = tasks.FirstOrDefault(filter, null);
        return t;
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
        List<DO.Task> _TaskList = XMLTools.LoadListFromXMLSerializer<DO.Task>(tasks_xml); // load the list from the file

        if (_TaskList.FirstOrDefault(t => t.Id == item.Id) != null) // if the task exist
        {
            _TaskList.RemoveAll(t => t.Id == item.Id);
            _TaskList.Add(item);
            XMLTools.SaveListToXMLSerializer<DO.Task>(_TaskList, tasks_xml);
        }
        else // if the task does not exist throw an exception
            throw new InvalidOperationException($"Task with ID {item.Id} does not exist."); // if the task does not exist throw an exception
    }
}



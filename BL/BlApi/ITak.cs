using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi;
/// <summary>
///  this is the interface of the BL layer that is used to implement the BL layer  functions of the Task
/// </summary>
public interface ITak
{
    public int createTask(BO.Task task); // this function get a task and create it in the database

    public BO.Task? read(int id); // this function get an id and return the task that match the id

    public BO.Task? read(Func<BO.Task, bool> filter); // this func get a filter and return the first item that match the filter

    public IEnumerable<BO.Task?> readAll(Func<BO.Task, bool>? filter = null); // this function return all the tasks in the database

    public void update(BO.Task task); // this function get a task and update it in the database

    public void delete(BO.Task task); // this function get a task and delete it from the database 
}

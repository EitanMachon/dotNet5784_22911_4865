
namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

public class TaskImplementation : ITask
{
    public int Create(System.Threading.Tasks.Task item) // create a new task
    {
        if (item.Id != 0) // if the task already has an ID, throw an exception
        {
            throw new InvalidOperationException("Cannot create task with existing ID."); // throw an exception
        }
        int newTaskId = DataSource.Config.NextId; // generate new ID
        item.Id = newTaskId; // update the ID of the task
        DataSource.Tasks.Add(item); // add the task to the list
        return newTaskId; // return the new ID
    }




   public void Delete(int id) // delete a task
    {
        var existingTask = DataSource.Tasks.FirstOrDefault(t => t.Id == id); // find the task with the given ID and store it in a variable

        if (existingTask == null) // if the task does not exist, throw an exception
        {
            throw new InvalidOperationException($"Task with ID {id} does not exist."); // throw an exception
        }

        if (existingTask.IsActive) // if the task is active, remove it from the list
        {
            DataSource.Tasks.Remove(existingTask); // remove the task from the list
        }
        else
        {
            DataSource.Tasks.Remove(existingTask) // remove the  unupdate task from the list
            existingTask.IsActive = false; // if the task is not active, set its IsActive property to false
            DataSource.Tasks.Add(existingTask); // add the update task to the list
        }

    }


    public System.Threading.Tasks.Task? Read(int id) : return null; // read a task by ID and if it does not exist, return null
    {
        return DataSource.Tasks.FirstOrDefault(t => t.Id == id); // return the task with the given ID, its nean  read  the task
    }


public List<System.Threading.Tasks.Task> ReadAll() // read all tasks
{
    list1 = new List<System.Threading.Tasks.Task>(); // create a copy of the list
    return list1; // return the copy of the list
}


public void Update(System.Threading.Tasks.Task item)
{
    Read(item.Id) // if the task does not exist, throw an exception
    var existingTask = DataSource.Tasks.FirstOrDefault(t => t.Id == item.Id); // copy the task with the given ID and store it in a variable
    DataSource.Tasks.Remove(existingTask); // remove the task of the given object from the list
    DataSource.Tasks.Add(item); // add the given object to the list
}


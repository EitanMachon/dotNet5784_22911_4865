
namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

public class TaskImplementaion : ITask
{
    public int Create(Task item)
    {
        if (item.Id != 0) // if the task already has an ID, throw an exception
        {
            throw new InvalidOperationException("Cannot create task with existing ID."); // throw an exception
        }

        int newTaskId = DataSource.Config.NextId; // generate new ID for the task

        var newTask = new Task(newTaskId, item.Alias, item.Description, item.CreatedAtDate, item.RequiredEffort, item.IsMilestone, item.Copmlexity, item.StartDate, item.ScheduledTime, item.DeadLinetime, item.ComplateTime, item.Dekiverables, item.Remarks, item.EngineerId, item.Difficulty); // Create a new Task object with the generated ID

        DataSource.Tasks.Add(newTask); // Add the new task directly into the DataSource
        return newTaskId; // return the new ID of the task

    }


    public void Delete(int id) // delete a Task by his ID
    {
       
        var existingTask = DataSource.Tasks.FirstOrDefault(t => t.Id == id); // copy the Task with the given ID and store it in a variable

        if (existingTask == null) // if the Task does not exist, throw an exception
        {
            throw new InvalidOperationException($"Task with ID {id} does not exist."); // throw an exception
        }
        
        if (existingTask.IsActive) // if the Task is active remove him from the list 
        {
            DataSource.Tasks.Remove(existingTask); // remove the Task of the given object from the list
        }
        else
        {
            existingTask.IsActive = false; // set the Task to inactive
        }
    }

    public Task Read(int id)
    {
        return DataSource.Tasks.FirstOrDefault(d => d.Id == id) // copy the Task with the given ID and store it in a variable
            ?? throw new InvalidOperationException($"Task with ID {id} does not exist."); // throw an exception
              
    }

    public List<Task> ReadAll()
    {
        return DataSource.Tasks.ToList(); // return a list of all Tasks in the DataSource by making a copy of the list and returning it
       
    }

    public void Update(Task item)
    {
        
        var existingTask = DataSource.Tasks.FirstOrDefault(t => t.Id == item.Id); // copy the Task with the given ID and store it in a variable

        if(existingTask == null) // if the Task does not exist, throw an exception
        {
            throw new InvalidOperationException($"Task with ID {item.Id} does not exist."); // throw an exception
        }

        DataSource.Tasks.Remove(existingTask);
        DataSource.Tasks.Add(item);
    }

   
    

 
}

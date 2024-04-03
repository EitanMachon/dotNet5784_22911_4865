namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

internal class TaskImplementaion : ITask
{
    public int Create(Task item)
    {
        int newTaskId = DataSource.Config.GetNextTaskId(); // generate new ID for the task

        var newTask = new Task(newTaskId, item.Alias, item.Description, item.CreatedAtDate, item.RequiredEffort, item.Copmlexity, item.StartDate, item.ScheduledTime, item.DeadLinetime, item.ComplateTime, item.Dekiverables, item.Remarks, item.EngineerId); // Create a new Task object with the generated ID

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
        //return DataSource.Tasks.Where(d => d.Id == id).FirstOrDefault() // copy the Task with the given ID and store it in a variable
        //    ?? throw new InvalidOperationException($"Task with ID {id} does not exist."); // throw an exception
        if (DataSource.Tasks.Any(t => t.Id == id)) // if the Task with the given ID exists, return the Task
        {
            return DataSource.Tasks.Where(t => t.Id == id).FirstOrDefault()!; // return the Task with the given ID
        }
        else
        {
            throw new InvalidOperationException($"Task with ID {id} does not exist."); // throw an exception
        }
              
    }

    //public List<Task> ReadAll()
    //{
    //    return DataSource.Tasks.Select(x => x).ToList(); // return a list of all Dependencies in the DataSource by making a copy of the list and returning it

    //}
    public IEnumerable<Task> ReadAll(Func<Task, bool>? filter = null) //stage 2
    {
        if (filter != null) // if the filter is not null, return a list of Tasks that match the filter
        {
            return from item in DataSource.Tasks
                   where filter(item)
                   select item;
        }
        return from item in DataSource.Tasks
               select item;
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

    public Task? Read(Func<Task, bool> filter) // stage 2 // this func get a filter and return the first item that match the filter
    {
        return DataSource.Tasks.Where(filter).FirstOrDefault();
    }



}

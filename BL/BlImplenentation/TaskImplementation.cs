namespace BlImplenentation;

using DalApi;
using DO;
using System;
using System.Collections.Generic;

internal class TaskImplementation : ITask
{
    private IDal dal = Factory.Get; // create a new instance of the DAL layer to use its functions to implement the BL layer functions like Create, Delete, Read, ReadAll, and Update
    public int Create(Task item) // create a new Task
    {
        try
        {
            int idTask = Create(item); // create a new Task
            return idTask; // return the new ID of the Task
        }
        catch (DO.DalAlreadyExistsException e) // if the Task already exists, throw an exception
        {
            throw new Exception("Task with the same ID already exists", e); // throw an exception
        }
    }


    public void Delete(int id) // delete a Task by his ID
    {
        try // try to delete the Task
        {
            Delete(id); // delete the Task with the given ID in the DAL layer
        }
        catch (DO.DalDeletionImpossible e) // if the Task cannot be deleted, throw an exception
        {
            throw new Exception("Task with the given ID does not exist", e); // throw an exception
        }
    }

    public Task? Read(int id) // read a Task by his ID
    {
        if (id == 0) // if the ID is 0, throw an exception because it is not possible to read a Task with ID 0
        {
            throw new DO.NotFoundId("Task with ID 0 does not exist"); // throw an exception
        }
        return new Task(); // this is a temporary return value to avoid compilation errors
    }

    public Task? Read(Func<Task, bool> filter) // read a Task by a filter
    {
        if (filter == null) // if the filter is null, throw an exception because it is not possible to filter the list
        {
            throw new Exception("Filter is null");
        }
        return new Task(); // this is a temporary return value to avoid compilation errors
    }

    public IEnumerable<Task?> ReadAll(Func<Task, bool>? filter = null) // read all Tasks
    {
        if (filter != null) // if the filter is not null, return a list of Tasks that match the filter
        {
            return ReadAll(filter); // return a list of Tasks that match the filter
        }
        return ReadAll(); // return a list of all Tasks 
    }

    public void Update(Task item)  // update a Task
    {
        if (item == null) // if the Task is null, throw an exception because it is not possible to update a null Task
        {
            throw new Exception("Task is null");
        }
        if (item.Id == 0) // if the Task has no ID, throw an exception
        {
            throw new DO.NotFoundId("Task with ID 0 does not exist"); // throw an exception
        }
        try // try to update the Task
        {
            Update(item); // update the Task in the DAL layer
        }
        catch (DO.DalUpdateImpossible e) // if the Task cannot be updated, throw an exception
        {
            throw new Exception("Task with the given ID does not exist", e); // throw an exception
        }
    }
}
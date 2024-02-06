namespace BlImplenentation;

using DalApi;
using DO;
using System;
using System.Collections.Generic;

internal class TaskImplementation : ITask
{
    private IDal _dal = Factory.Get; // create a new instance of the DAL layer to use its functions to implement the BL layer functions like Create, Delete, Read, ReadAll, and Update
    
    public int Create(BO.Task boTask) // create a new Task by a given Task in the BO layer
    {
        if (boTask.Engineer.Id != 0) // if the Engineer ID is not 0, check if the Engineer exists in the database
        {
            var existingEngineer = _dal.iengineer.Read(t => t.Id == boTask.Engineer.Id); // read the Engineer by his ID in the DAL layer
            if (boTask.Id < 0) // if the Task ID is less than 0, throw an exception because it is not possible to create a Task with an ID that is less than 0
            {
                throw new BO.BlInvalidId($"Task with ID={boTask.Id} is invalid"); // throw an exception
            }
            if (boTask.Alias == null) // if the Task Alias is null, throw an exception because it is not possible to create a Task with a null Alias
            {
                throw new BO.BlInvalidAlias("Task with Alias=null is invalid"); // throw an exception
            }
                
        }

        DO.Task doTask = new DO.Task // create a new Task in the DAL layer by the given Task in the BO layer after checking the Engineer and his qualification
        {
            Id = 0, 
            Alias = boTask.Alias,
            Description = boTask.Description,
            CreatedAtDate = boTask.CreatedAtDate,
            Dekiverables = boTask.Dekiverables,
            Remarks = boTask.Remarks,
            EngineerId = boTask.Engineer.Id,
            Copmlexity = (EngineerExperience)boTask.Copmlexity,
            RequiredEffort = boTask.RequiredEffort,
        }; 

        int taskId = _dal.itask.Create(doTask); // create a new Task in the DAL layer and get his ID 

        foreach (var dependency in boTask.Dependencys) // create a new Dependency for each Dependency in the Task
        {
            if (_dal.itask.Read(x => x.Id == dependency.Id) == null) // if the Dependent Task does not exist, throw an exception
            {
                throw new BO.BLDependentTaskDoesntExist($"Dependent task with ID={dependency.Id} doesn't exist"); // throw an exception
            }
            _dal.idependancy.Create(new Dependency { DependentTask = taskId, DependencyId = dependency.Id }); // create a new Dependency in the DAL layer for the Task and the Dependent Task
        }

        return taskId; // after creating the Task and his Dependencies, return the Task ID

    }
    public void Delete(int id) // delete a Task by his ID
    {
        if(id != 0) // if the Task ID is not 0, check if the Task exists in the database
        {
            var existingTask = _dal.itask.Read(t => t.Id == id); // read the Task by his ID in the DAL layer
            if (existingTask == null) // if the Task does not exist, throw an exception because it is not possible to delete a Task that does not exist
            {
                throw new BO.BlDoesNotExistException($"Task with ID={id} doesn't exist"); // throw an exception
            }
            var dependency = _dal.idependancy.Read(t => t.DependentTask == id); // check if the Task has a Dependency, if he has a Dependency, throw an exception because it is not possible to delete a Task that has a Dependency
            if (dependency != null) // if the Task has a Dependency, throw an exception because it is not possible to delete a Task that has a Dependency
            {
                throw new BO.BLTaskHasDependencyException($"Task with ID={id} has a dependency"); // throw an exception
            }
        }
        try // try to delete the Task
        {
            _dal.itask.Delete(id); // delete the Task with the given ID in the DAL layer
        }
        catch (DO.DalDeletionImpossible e) // if the Task cannot be deleted, throw an exception
        {
            throw new DalDeletionImpossible($"Task with the ID {id} cannot be deleted", e); // throw an exception
        }   
    }

    public Engineer? Read(int id)
    {
        if (id != 0) // if the Task ID is not 0, check if the Task exists in the database
        {
            var existingTask = _dal.itask.Read(t => t.Id == id); // read the Task by his ID in the DAL layer
            if (existingTask == null) // if the Task does not exist, throw an exception because it is not possible to read a Task that does not exist
            {
                throw new BO.BlDoesNotExistException($"Task with ID={id} doesn't exist"); // throw an exception
            }
        }
        
    }

    public Task? Read(Func<Task, bool> filter) // read a Task by a filter
    {}
        

    public IEnumerable<Task?> ReadAll(Func<Task, bool>? filter = null) // read all Tasks
    {}

    public void Update(BO.Task boTask) // update a Task by a given Task in the BO layer
    {
        if (boTask.Engineer.Id != 0) // if the Engineer ID is not 0, check if the Engineer exists in the database
        {
            var existingEngineer = _dal.iengineer.Read(t => t.Id == boTask.Engineer.Id); // read the Engineer by his ID in the DAL layer
            if (boTask.Id < 0) // if the Task ID is less than 0, throw an exception because it is not possible to update a Task with an ID that is less than 0
            {
                throw new BO.BlInvalidId($"Task with ID={boTask.Id} is invalid"); // throw an exception
            }
            if (boTask.Alias == null) // if the Task Alias is null, throw an exception because it is not possible to update a Task with a null Alias
            {
                throw new BO.BlInvalidAlias("Task with Alias=null is invalid"); // throw an exception
            }
        }
        DO.Task doTask = new DO.Task // create a new Task in the DAL layer by the given Task in the BO layer after checking the Engineer and his qualification
        {
            Id = boTask.Id,
            Alias = boTask.Alias,
            Description = boTask.Description,
            CreatedAtDate = boTask.CreatedAtDate,
            Dekiverables = boTask.Dekiverables,
            Remarks = boTask.Remarks,
            EngineerId = boTask.Engineer.Id,
            Copmlexity = (EngineerExperience)boTask.Copmlexity,
            RequiredEffort = boTask.RequiredEffort,
        };
        _dal.itask.Update(doTask); // update the Task in the DAL layer
    }
}
namespace BlImplenentation;

using BlApi;
using BO;
using DO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Engineer = BO.Engineer;
using Task = BO.Task;
/// <summary>
/// this class is the implementation of ITask interface and contains the implementation of the Task functions in the BL layer
/// </summary>
internal class TaskImplementation : ITask
{
    private IDal _dal = DalApi.Factory.Get; // create a new instance of the DAL layer to use its functions to implement the BL layer functions like Create, Delete, Read, ReadAll, and Update
    private Task? finalTask; // create a new Task in the BO layer to use it in the Read function

    /// <summary>
    /// this function is used to create a new Task by a given Task in the BO layer
    /// </summary>

    public int Create(BO.Task boTask) // create a new Task by a given Task in the BO layer
    {
        if (boTask.EngineerId != 0) // if the Engineer ID is not 0, check if the Engineer exists in the database
        {
            var existingEngineer = _dal.iengineer.Read(t => t.Id == boTask.EngineerId); // read the Engineer by his ID in the DAL layer
            if (boTask.Id < 0) // if the Task ID is less than 0, throw an exception because it is not possible to create a Task with an ID that is less than 0
            {
                throw new BO.BlInvalidId($"Task with ID={boTask.Id} is invalid"); // throw an exception
            }
            if (boTask.Alias == null) // if the Task Alias is null, throw an exception because it is not possible to create a Task with a null Alias
            {
                throw new BO.BlInvalidAlias("Task with Alias=null is invalid"); // throw an exception
            }
        }
        object? engineerId = _dal.iengineer.Read(t => t.Id == boTask.EngineerId); // read the Engineer by his ID in the DAL layer
        if (engineerId == null) // if the Engineer does not exist, throw an exception because it is not possible to read a Task that does not have an Engineer
        {/////
            throw new BO.BLTaskHasNoEngineerException("notfoundengineer"); // throw an exception
        }
        DO.Task doTask = new DO.Task // create a new Task in the DAL layer by the given Task in the BO layer after checking the Engineer and his qualification
        {
            Id = 0,
            Alias = boTask.Alias,
            Description = boTask.Description,
            CreatedAtDate = boTask.CreatedAtDate,
            Dekiverables = boTask.Dekiverables,
            Remarks = boTask.Remarks,
            EngineerId = boTask.EngineerId,
            Copmlexity = (global::EngineerExperience)(EngineerExperience)boTask.Copmlexity, // this is global because the EngineerExperience is in the BO layer and the EngineerExperience is in the DO layer
            RequiredEffort = boTask.RequiredEffort,
        };


        int taskId = _dal.itask.Create(doTask); // create a new Task in the DAL layer and get his ID 

        if (boTask.Dependencys != null)
        {
            foreach (var dependency in boTask.Dependencys) // create a new Dependency for each Dependency in the Task
            {
                if (_dal.itask.Read(x => x.Id == dependency.Id) == null) // if the Dependent Task does not exist, throw an exception
                {
                    throw new BO.BLDependentTaskDoesntExist($"Dependent task with ID={dependency.Id} doesn't exist"); // throw an exception
                }
                _dal.idependancy.Create(new Dependency { DependentTask = taskId, Depends = dependency.Id }); // create a new Dependency in the DAL layer for the Task and the Dependent Task
            }
        }

        return taskId; // after creating the Task and his Dependencies, return the Task ID

    }
    /// <summary>
    /// this function is used to delete a Task by his ID in the BO layer by using his ID in the DAL layer
    /// </summary>
    public void Delete(int id) // delete a Task by his ID
    {
        if (id != 0) // if the Task ID is not 0, check if the Task exists in the database
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
    /// <summary>
    /// this function is used to read a Task by his ID in the BO layer by using his ID in the DAL layer
    /// </summary>
    public Task? Read(int id)
    {
        if (id == 0) // if the Task ID is not 0, check if the Task exists in the database
            return null;
        var existingTask = _dal.itask.Read(t => t.Id == id); // read the Task by his ID in the DAL layer
        if (existingTask == null) // if the Task does not exist, throw an exception because it is not possible to read a Task that does not exist
        {
            return null;
        }
        DO.Task? doTask = _dal.itask.Read(t => t.Id == id); // read the Task by his ID in the DAL layer after checking if the Task exists in the database
        DO.Engineer? engineer = _dal.iengineer.Read(t => t.Id == doTask.EngineerId && t.IsActive == true); // read the Engineer by his ID in the DAL layer
        EngineerInTask? engineerInTask = null;
        if (engineer != null)
        {
            engineerInTask = new EngineerInTask
            {
                Id = engineer.Id,
                Name = engineer.Name
            };
        }

        BO.Task? finalTask = new BO.Task // return the Task in the BO layer
        {
            Id = doTask.Id,
            Alias = doTask.Alias,
            Description = doTask.Description,
            CreatedAtDate = doTask.CreatedAtDate,
            Dekiverables = doTask.Dekiverables,
            Remarks = doTask.Remarks,
            Engineer = engineerInTask,
            Copmlexity = (EngineerExperience)doTask.Copmlexity,
            RequiredEffort = doTask.RequiredEffort,
        };


        return finalTask; // return the Task in the BO layer

    }
    /// <summary>
    /// this function is used to read all Tasks in the BO layer by using the filter in the DAL layer
    /// </summary>
    public IEnumerable<BO.Task?> ReadAll(Func<BO.Task, bool>? filter = null) // read all Tasks
    {
        IEnumerable<DO.Task> doTasks = _dal.itask.ReadAll().Where(t => t != null); // read all Tasks in the DAL layer
        List<BO.Task?> boTasks = new List<BO.Task?>(); // create a new list of Tasks in the BO layer
        foreach (var task in doTasks) // for each Task in the DAL layer
        {
            //DO.Engineer? engineer = _dal.iengineer.Read(e => e.Id == task.EngineerId && e.IsActive == true); // read the Engineer by his ID in the DAL layer
            DO.Engineer? engineer = _dal.iengineer.Read(task.EngineerId); // read the Engineer by his ID in the DAL layer
            if (engineer == null) // if the Engineer does not exist, throw an exception because it is not possible to read a Task that does not have an Engineer
            {/////
                throw new BO.BLTaskHasNoEngineerException($"Task with ID={task.Id} has no Engineer"); // throw an exception
            }
            EngineerInTask engineerDO = new EngineerInTask
            {
                Id = task.EngineerId,
                Name = engineer.Name,
            };  // cast the Engineer to the BO layer
            try // try to read the Task
            {
                BO.Task task2 = new BO.Task() // add the Task to the list of Tasks in the BO layer
                {
                    Id = task.Id,
                    Alias = task.Alias,
                    Description = task.Description,
                    CreatedAtDate = task.CreatedAtDate,
                    Dekiverables = task.Dekiverables,
                    Remarks = task.Remarks,
                    Engineer = engineerDO,
                    Copmlexity = (EngineerExperience)task.Copmlexity,
                    RequiredEffort = task.RequiredEffort,
                    startDate = task.StartDate,
                    DeadLinetime = task.DeadLinetime,
                };
                if (filter == null)
                {
                    boTasks.Add(task2);
                }
                else
                {
                    if (filter(task2))
                    {
                        boTasks.Add(task2);
                    }
                }
            }
            catch (DO.DalReadException e) // if the Task cannot be read, throw an exception
            {
                throw new DalReadException($"Task with the ID {task.Id} cannot be read", e); // throw an exception
            }
        }
        return boTasks; // return the list of Tasks in the BO layer    )
    }
    /// <summary>
    /// this function is used to update a Task by a given Task in the BO layer
    /// </summary>
    public void Update(BO.Task boTask) // update a Task by a given Task in the BO layer
    {
        if (boTask.EngineerId != 0) // if the Engineer ID is not 0, check if the Engineer exists in the database
        {
            var existingEngineer = _dal.iengineer.Read(t => t.Id == boTask.EngineerId); // read the Engineer by his ID in the DAL layer
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
            EngineerId = boTask.EngineerId,
            Copmlexity = (global::EngineerExperience)boTask.Copmlexity,
            RequiredEffort = boTask.RequiredEffort,
        };
        _dal.itask.Update(doTask); // update the Task in the DAL layer

    }

}
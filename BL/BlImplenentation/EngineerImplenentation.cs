namespace BlImplenentation;

using BLApi;
using BO;
using DO;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;

using System.Xml.Linq;
using Engineer = BO.Engineer;

internal class EngineerImplenentation : IEngineer
{
    private IDal _dal = DalApi.Factory.Get; // create a new instance of the DAL layer to use its functions to implement the BL layer functions like Create, Delete, Read, ReadAll, and Update
    //DalApi.IDal dal = new DalApi.DalApi();
    public int Create(BO.Engineer boEngineer) // create a new Engineer by a given Engineer in the BO layer
    {
        if (boEngineer.Id != 0) // if the Engineer ID is not 0, check if the Engineer exists in the database
        {
            var existingEngineer = _dal.iengineer.Read(t => t.Id == boEngineer.Id); // read the Engineer by his ID in the DAL layer
            if (existingEngineer != null) // if the Engineer exists, throw an exception because it is not possible to create an Engineer that already exists
            {
                throw new BO.BlEngineerAlreadyExists($"Engineer with ID={boEngineer.Id} already exists"); // throw an exception
            }
            if (!((int)boEngineer.Id > 0)) // if the Engineer ID is not greater than 0, throw an exception because it is not possible to create an Engineer with an ID that is not greater than 0
            {
                throw new BO.BlInvalidId($"Engineer with ID={boEngineer.Id} is invalid"); // throw an exception
            }
            if (boEngineer.Name == null) // if the Engineer Name is null, throw an exception because it is not possible to create an Engineer with a null Name
            {
                throw new BO.BlInvalidName("Engineer with Name=null is invalid"); // throw an exception
            }
            if (boEngineer.Email == null) // if the Engineer Email is null, throw an exception because it is not possible to create an Engineer with a null Email
            {
                throw new BO.BlInvalidEmail("Engineer with Email=null is invalid"); // throw an exception
            }
        }

        DO.Engineer doEngineer = new DO.Engineer // create a new Engineer in the DAL layer by the given Engineer in the BO layer after checking the Engineer and his qualification
        {
            Id = boEngineer.Id,
            Name = boEngineer.Name,
            Email = boEngineer.Email,
            SalaryHour = boEngineer.SalaryHour,
            Level = (global::EngineerExperience)(EngineerExperience)boEngineer.Level,
        };

        int engineerId = _dal.iengineer.Create(doEngineer); // create a new Engineer in the DAL layer and get his ID
        return engineerId; // after creating the Engineer and his Tasks, return the Engineer ID

    }
    public void Delete(int id) // delete an Engineer by his ID
    {
        if (id != 0) // if the Engineer ID is not 0, check if the Engineer exists in the database
        {
            var existingEngineer = _dal.iengineer.Read(t => t.Id == id); // read the Engineer by his ID in the DAL layer
            if (existingEngineer == null) // if the Engineer does not exist, throw an exception because it is not possible to delete an Engineer that does not exist
            {
                throw new BO.BlDoesNotExistException($"Engineer with ID={id} doesn't exist"); // throw an exception
            }
            var task = _dal.itask.Read(t => t.EngineerId == id); // check if the Engineer has a Task, if he has a Task, throw an exception because it is not possible to delete an Engineer that has a Task
            if (task != null) // if the Engineer has a Task, throw an exception because it is not possible to delete an Engineer that has a Task
            {
                throw new BO.BlEngineerHasTask($"Engineer with ID={id} has a Task"); // throw an exception
            }

            try // try to delete the Engineer
            {
                _dal.iengineer.Delete(id); // delete the Engineer with the given ID in the DAL layer
            }
            catch (DO.DalDeletionImpossible e) // if the Engineer cannot be deleted, throw an exception
            {
                throw new DalDeletionImpossible($"Engineer with the ID {id} cannot be deleted", e); // throw an exception
            }
        }
    }
    public Engineer? Read(int id) // read an Engineer by his ID
    {
        if (id != 0) // if the Engineer ID is not 0, check if the Engineer exists in the database
        {
            var existingEngineer = _dal.iengineer.Read(t => t.Id == id); // read the Engineer by his ID in the DAL layer
            if (existingEngineer == null) // if the Engineer does not exist, throw an exception because it is not possible to read an Engineer that does not exist
            {
                throw new BO.BlDoesNotExistException($"Engineer with ID={id} doesn't exist"); // throw an exception
            }          
        }
        DO.Engineer doEngineer = _dal.iengineer.Read(t => t.Id == id); // read the Engineer by his ID in the DAL layer
        object FindTheTask = _dal.itask.Read(t => t.EngineerId == id && t.DeadLinetime == null); // read the Task of the Engineer by his ID in the DAL layer and check if the Task is not finished 
        
             
        
        try
        {
            return new BO.Engineer // return the Engineer in the BO layer
            {
                Id = doEngineer.Id,
                Name = doEngineer.Name,
                Email = doEngineer.Email,
                SalaryHour = doEngineer.SalaryHour,
                Level = (BO.EngineerExperience)doEngineer.Level,
                Task = FindTheTask != null ? new BO.TaskInEngineer(((DO.Task)FindTheTask).Id, ((DO.Task)FindTheTask).Name) : null // if the Task exists, return the Task in the BO layer, if the Task does not exist, return null
            };
        }
        catch ( DalReadException e) // if the Engineer cannot be read, throw an exception
        {
            throw new DalReadException($"Engineer with the ID {id} cannot be read", e); // throw an exception
        }
        
    }
    public IEnumerable<Engineer?> ReadAll(Func<BO.Engineer, bool>? filter = null)
    {
        object findTheTask = null; // create a new instance of the Task
        findTheTask = _dal.itask.Read(t => t.EngineerId == 1 && t.DeadLinetime == null); // read the Task of the Engineer by his ID in the DAL layer and check if the Task is not finished
        try
        {
            if(filter == null) // if the filter is null, read all the Engineers
            {
                return from engineer in _dal.iengineer.ReadAll() // read all the Engineers in the DAL layer
                       select new BO.Engineer // return all the Engineers in the BO layer
                       {
                           Id = engineer.Id,
                           Name = engineer.Name,
                           Email = engineer.Email,
                           SalaryHour = engineer.SalaryHour,
                           Level = (BO.EngineerExperience)engineer.Level,
                           Task = findTheTask != null ? new BO.TaskInEngineer(((DO.Task)findTheTask).Id, ((DO.Task)findTheTask).Name) : null // if the Task exists, return the Task in the BO layer, if the Task does not exist, return null
                       };
            }
            else // if the filter is not null, read the Engineers by the filter
            {
                return from engineer in _dal.iengineer.ReadAll() // read the Engineers by the filter in the DAL layer
                       let temp = new BO.Engineer // return the Engineers by the filter in the BO layer
                       {
                           Id = engineer.Id,
                           Name = engineer.Name,
                           Email = engineer.Email,
                           SalaryHour = engineer.SalaryHour,
                           Level = (BO.EngineerExperience)engineer.Level,
                           Task = findTheTask != null ? new BO.TaskInEngineer(((DO.Task)findTheTask).Id, ((DO.Task)findTheTask).Name) : null // if the Task exists, return the Task in the BO layer, if the Task does not exist, return null
                       }
                       where filter(temp) // return the Engineers by the filter in the BO layer
                       select temp;
            }
        }
        catch (DalReadException e) // if the Engineers cannot be read, throw an exception
        {
            throw new DalReadException("Engineers cannot be read", e); // throw an exception
        }
        
         
    }
    public void Update(BO.Engineer boEngineer)
    {
        Console.WriteLine("You can update:\r\nThe name of the engineer\r\nEmail\r\nEngineer level (upward only)\r\ncost per hour\r\nSelecting a task that the engineer performs"); // print the options that the user can update
        if (boEngineer.Id != 0) // if the Engineer ID is not 0, check if the Engineer exists in the database
        {
            var existingEngineer = _dal.iengineer.Read(t => t.Id == boEngineer.Id); // read the Engineer by his ID in the DAL layer
            if (existingEngineer != null) // if the Engineer exists, throw an exception because it is not possible to create an Engineer that already exists
            {
                throw new BO.BlEngineerAlreadyExists($"Engineer with ID={boEngineer.Id} already exists"); // throw an exception
            }
            if (!((int)boEngineer.Id > 0)) // if the Engineer ID is not greater than 0, throw an exception because it is not possible to create an Engineer with an ID that is not greater than 0
            {
                throw new BO.BlInvalidId($"Engineer with ID={boEngineer.Id} is invalid"); // throw an exception
            }
            if (boEngineer.Name == null) // if the Engineer Name is null, throw an exception because it is not possible to create an Engineer with a null Name
            {
                throw new BO.BlInvalidName("Engineer with Name=null is invalid"); // throw an exception
            }
            if (boEngineer.Email == null) // if the Engineer Email is null, throw an exception because it is not possible to create an Engineer with a null Email
            {
                throw new BO.BlInvalidEmail("Engineer with Email=null is invalid"); // throw an exception
            }
        }
        DO.Engineer doEngineer = new DO.Engineer // create a new Engineer in the DAL layer by the given Engineer in the BO layer after checking the Engineer and his qualification before updating the Engineer
        {
            Id = boEngineer.Id,
            Name = boEngineer.Name,
            Email = boEngineer.Email,
            SalaryHour = boEngineer.SalaryHour,
            Level = (global::EngineerExperience)(EngineerExperience)boEngineer.Level, //this global because the DO.Engineer has a field with the same name
        };
        try
        {
            _dal.iengineer.Update(doEngineer); // update the Engineer with the given ID in the DAL layer
        }
        catch (DO.DalDeletionImpossible e) // if the Engineer cannot be updated, throw an exception
        {
            throw new DalDeletionImpossible($"Engineer with the ID {boEngineer.Id} cannot be updated", e); // throw an exception
        }

    } 
}
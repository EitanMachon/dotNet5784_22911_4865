namespace BlImplenentation;

using BO;
using DalApi;
using DO;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;

using System.Xml.Linq;

internal class EngineerImplenentation : IEngineer
{
    private IDal _dal = Factory.Get; // create a new instance of the DAL layer to use its functions to implement the BL layer functions like Create, Delete, Read, ReadAll, and Update
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
            Level = (EngineerExperience)boEngineer.Level,
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
              


    }

    public Engineer? Read(Func<Engineer, bool> filter)
    {
        if (filter == null) // if the filter is null, throw an exception because it is not possible to filter the list
        {
            throw new Exception("Filter is null");
        }
        return new Engineer(); // this is a temporary return value to avoid compilation errors
    }

    public IEnumerable<Engineer?> ReadAll(Func<Engineer, bool>? filter = null)
    {
        if (filter != null) // if the filter is not null, return a list of Engineers that match the filter
        {
            return ReadAll(filter); // return a list of Engineers that match the filter
        }
        return ReadAll(); // return a list of all Engineers 

    }

    public void Updaten(BO.Engineer boEngineer)
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
            Level = (EngineerExperience)boEngineer.Level,
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
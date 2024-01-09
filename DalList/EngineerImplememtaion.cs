
namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

public class EngineerImplementation : IEngineer
{
    public int Create(Engineer item)
    {
        if (item.Id != 0) //if the engineer already has an ID, throw an exception
        { 
            throw new InvalidOperationException("Cannot create engineer with existing ID."); // throw an exception
        }
            
        int newEngineerId = DataSource.Config.NextId; // generate new ID for the engineer
        item.Id = newEngineerId; // update the engineer with the new ID
        DataSource.EngineersAdd(item) // add the engineer to the list of engineers
        return newEngineerId; // return the new ID of the engineer
    }


    public void Delete(int id) // delete a Engineer
    {
        var existingEngineer = DataSource.Engineers.FirstOrDefault(t => t.Id == id); // find the task with the given ID and store it in a variable

        if (existingEngineer == null) // if the Engineer does not exist, throw an exception
        {
            throw new InvalidOperationException($"Engineer with ID {id} does not exist."); // throw an exception
        }

        if (existingEngineer.IsActive) // if the Engineer is active, remove it from the list
        {
            DataSource.Engineers.Remove(existingEngineer); // remove the Engineer from the list
        }
        else
        {
            DataSource.Engineers.Remove(existingEngineer) // remove the  unupdate Engineer from the list
            existingEngineer.IsActive = false; // if the Engineer is not active, set its IsActive property to false
            DataSource.Engineers.Add(existingEngineer); // add the update Engineer to the list
        }

    }


    public System.Threading.Engineers.Engineer? Read(int id) : return null; // read a Engineer by ID and if it does not exist, return null
    {
         return DataSource.Engineers.FirstOrDefault(t => t.Id == id); // return the Engineer with the given ID, its nean  read  the Engineer)
    }


public List<System.Threading.Engineers.Engineer> ReadAll() // read all Engineerings 
{
    list1 = new List<System.Threading.Engineers.Engineer>(); // create a copy of the list
    return list1; // return the copy of the list
}


public void Update(System.Threading.Engineers.Engineer item)
{
    Read(item.Id) // if the Engineer does not exist, throw an exception
    var existingEngineer = DataSource.Engineers.FirstOrDefault(t => t.Id == item.Id); // copy the Engineer with the given ID and store it in a variable
    DataSource.Engineers.Remove(existingEngineer); // remove the Engineer of the given object from the list
    DataSource.Engineers.Add(item); // add the given object to the list
}

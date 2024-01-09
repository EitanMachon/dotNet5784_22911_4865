
namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

public class EngineerImplementation : IEngineer
{
    public int Create(Engineer item) // create a Engineer and return its ID
    {
        if (item.Id != 0) // if the engineer already has an ID, throw an exception
        {
            throw new InvalidOperationException("Cannot create engineer with existing ID.");
        }

        int newEngineerId = DataSource.Config.NextId; // generate new ID for the engineer

        // Create a new Engineer object with the generated ID
        var newEngineer = new Engineer(newEngineerId, item.Name, item.Email, item.SalaryHour, item.Level);

        // Add the new engineer directly into the DataSource
        DataSource.Engineers.Add(newEngineer);

        return newEngineerId; // return the new ID of the engineer
    }

    public void Delete(int id) // delete a Engineer by his ID
    {
        var existingEngineer = DataSource.Engineers.FirstOrDefault(t => t.Id == id); // copy the Engineer with the given ID and store it in a variable

        if (existingEngineer == null) // if the Engineer does not exist, throw an exception
        {
            throw new InvalidOperationException($"Engineer with ID {id} does not exist.");
        }

        if (existingEngineer.IsActive) // if the Engineer is active remove him from the list 
        {
            DataSource.Engineers.Remove(existingEngineer); // remove the Engineer of the given object from the list
        }
        else
        {
            existingEngineer.IsActive = false; // set the Engineer to inactive

        }
    }


    public Engineer? Read(int id) // read a Engineer by his ID and return the Engineer
    {
        var engineer = DataSource.Engineers.FirstOrDefault(e => e.Id == id); // copy the Engineer with the given ID and store it in a variable
        return engineer; // return the Engineer with the given ID
    }

    public List<Engineer> ReadAll() // read all Engineers and return a list of all Engineers
    {
        return DataSource.Engineers.ToList(); // return a list of all Engineers in the DataSource by making a copy of the list and returning it
    }

    public void Update(Engineer item) // update a Engineer
    {
        var existingEngineer = DataSource.Engineers.FirstOrDefault(t => t.Id == item.Id); // copy the Engineer with the given ID and store it in a variable

        if (existingEngineer == null) // if the Engineer does not exist, throw an exception
        {
            throw new InvalidOperationException($"Engineer with ID {item.Id} does not exist.");
        }

        DataSource.Engineers.Remove(existingEngineer);  // remove the Engineer of the given object from the list
        DataSource.Engineers.Add(item); // add the updated Engineer to the list
    }
}
















namespace Dal;
using DalApi;
using DO ;
using System.Collections.Generic;

public class DepandencyImplementation : IDependency
{
    public int Create(Depandency item)
    {
        if (item.Id != 0) //if the Depandency already has an ID, throw an exception
        {
            throw new InvalidOperationException("Cannot create Depandency with existing ID."); // throw an exception
        }

        int newDepandencyId = DataSource.Config.NextId; // generate new ID for the Depandency and store it in a variable
        item.Id = newDepandencyId; // update the Depandency with the new ID
        DataSource.DepandencysAdd(item) // add the Depandency to the list of Depandencys
        return newDepandencyId; // return the new ID of the Depandency


        public void Delete(int id) // delete a Depandency

        var existingDepandency = DataSource.Engineers.FirstOrDefault(t => t.Id == id); // find the Depandency with the given ID and store it in a variable

        if (existingDepandency == null) // if the Depandency does not exist, throw an exception
        {
            throw new InvalidOperationException($"Depandency with ID {id} does not exist."); // throw an exception
        }

        if (existingDepandency.IsActive) // if the Depandency is active, remove it from the list
        {
            DataSource.Depandencys.Remove(existingDepandency); // remove the Depandency from the list
        }
        else
        {
            DataSource.Depandencys.Remove(existingDepandency) // remove the  unupdate Depandency from the list
            existingDepandency.IsActive = false; // if theDepandency is not active, set its IsActive property to false
            DataSource.Depandencys.Add(existingDepandency); // add the update Depandency to the list
        }

    }


    public System.Threading.Depandencys.Depandency? Read(int id) : return null; // read a Depandency by ID and if it does not exist, return null
    {
         return DataSource.Depandencys.FirstOrDefault(t => t.Id == id); // return the Depandency with the given ID, its nean  read  the Depandency)
    }


public List<System.Threading.Depandencys.Depandency> ReadAll() // read all Depandencys 
{
    list1 = new List<System.Threading.Depandencys.Depandency>(); // create a copy of the list
    return list1; // return the copy of the list
}


public void Update(System.Threading.Depandencys.Depandency item)
{
    Read(item.Id) // if the Depandency does not exist, throw an exception
    var existingDepandency = DataSource.Depandencys.FirstOrDefault(t => t.Id == item.Id); // copy theDepandency with the given ID and store it in a variable
    DataSource.Depandencys.Remove(existingEngineer); // remove the Depandency of the given object from the list
    DataSource.Depandencys.Add(item); // add the given object to the list
}
}
   
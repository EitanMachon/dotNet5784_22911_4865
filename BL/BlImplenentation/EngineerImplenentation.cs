namespace BlImplenentation;
using DalApi;
using DO;
internal class EngineerImplenentation : IEngineer
{
    private IDal dal = Factory.Get; // create a new instance of the DAL layer to use its functions to implement the BL layer functions like Create, Delete, Read, ReadAll, and Update
    //DalApi.IDal dal = new DalApi.DalApi();
    public int Create(Engineer item)
    {
        try
        {
            int idEngineer = Create(item); // create a new Engineer
            return idEngineer; // return the new ID of the Engineer
        }
        catch (DO.DalAlreadyExistsException e) // if the Engineer already exists, throw an exception
        {
            throw new Exception("Engineer with the same ID already exists", e); // throw an exception
        }
       

    }

    public void Delete(int id) // delete an Engineer by his ID
    {
        try // try to delete the Engineer
        {
            Delete(id); // delete the Engineer with the given ID in the DAL layer
        }
        catch (DO.DalDeletionImpossible e) // if the Engineer cannot be deleted, throw an exception
        {
            throw new Exception("Engineer with the given ID does not exist", e); // throw an exception
        }
        
    }

    public Engineer? Read(int id) // read an Engineer by his ID
    {
        if (id == 0) // if the ID is 0, throw an exception because it is not possible to read an Engineer with ID 0
        {
            throw new DO.NotFoundId("Engineer with ID 0 does not exist"); // throw an exception
        }
        
        return new Engineer(); // this is a temporary return value to avoid compilation errors
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

    public void Update(Engineer item)
    {
        if (item == null) // if the Engineer is null, throw an exception because it is not possible to update a null Engineer
        {
            throw new Exception("Engineer is null");
        }
        if (item.Id == 0) // if the Engineer has no ID, throw an exception
        {
            throw new DO.NotFoundId("Engineer with ID 0 does not exist"); // throw an exception
        }
        try // try to update the Engineer
        {
            Update(item); // update the Engineer
        }
        catch (DO.DalDeletionImpossible e) // if the Engineer cannot be updated, throw an exception
        {
            throw new Exception("Engineer with the given ID does not exist", e); // throw an exception
        }
    }
}

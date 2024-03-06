using BlApi;
using BO;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Dependcys = BO.Dependcys;


namespace BlImplenentation;

internal class DependencyImplemation : BlApi.IDependency
{
    private IDal _dal = DalApi.Factory.Get; // The Dal instance to use for the implementation

    public int Create(Dependcys boDependcys) // Create a new dependancy
    {
        if (boDependcys.Id != 0) 
        {
            var tempDep = _dal.idependancy.Read(boDependcys.Id); // Check if the dependancy already exists
            if (tempDep != null) // If the dependancy already exists
            {
                throw new InvalidOperationException("The dependancy already exists");
            }
        }
        DO.Dependency doDep = new DO.Dependency() // Create a new dependancy in the DO layer
        {
            Id = boDependcys.Id,
            DependentTask = boDependcys.DependentTask,
            Depends = boDependcys.Depends
        };

        int depId = _dal.idependancy.Create(doDep); // Create the dependancy in the DO layer
        return depId;   // Return the id of the new dependancy
    }

    public void Delete(int id)
    {
        if ( id != 0) // If the id is not 0
        {
            var tempDep = _dal.idependancy.Read(id); // Check if the dependancy exists
            if (tempDep == null) // If the dependancy does not exist
            {
                throw new InvalidOperationException("The dependancy does not exist");
            }
        }
        try
        {
            _dal.idependancy.Delete(id); // Delete the dependancy in the DO layer
        }
        catch (DO.BadDependancyIdException ex) // If the dependancy id is invalid
        {
            throw new InvalidOperationException("The dependancy does not exist");
        }
    }

    public Dependcys? Read(int id)
    {
        DO.Dependency? exsitingDep = _dal.idependancy.Read(t => t.Id == id); // Read the dependancy from the DO layer
        if (exsitingDep == null) // If the dependancy does not exist
        {
            return null;
        }
        try // Try to create a new dependancy in the BL layer
        {
            if (exsitingDep == null) // If the dependancy does not exist
            {
                throw new InvalidOperationException("The dependancy does not exist");
            }
            DO.Dependency findDep = _dal.idependancy.Read(t => t.Id == id);
            return new Dependcys
            {
                Id = findDep.Id,
                DependentTask = findDep.DependentTask,
                Depends = findDep.Depends
            };
        }
        catch (Exception ex) // If the dependancy could not be created
        {
            throw new InvalidOperationException("The dependancy could not be read");
        }
    }

    public IEnumerable<Dependcys?> ReadAll(Func<Dependcys, bool>? filter = null)
    {
        DO.Dependency? findTheDep = null; // create a new instance of the Dependency
        findTheDep = _dal.idependancy.ReadAll(t => t.Id != 0).FirstOrDefault(); // read the Dependency in the DAL layer
        try
        {
            if (filter == null) // if the filter is null, read all the Dependencies
            {
                return from depend in _dal.idependancy.ReadAll() // read all the Dependencies in the DAL layer
                       select new Dependcys // return all the Dependencies in the BO layer
                       {
                           Id = depend.Id,
                           DependentTask = depend.DependentTask,
                           Depends = depend.Depends
                       };
            }
            else // if the filter is not null, read the Dependencies by the filter
            {
                var depends = from depend in _dal.idependancy.ReadAll() // read the Dependencies by the filter in the DAL layer
                              let temp = new Dependcys // return the Dependencies by the filter in the BO layer
                              {
                                  Id = depend.Id,
                                  DependentTask = depend.DependentTask,
                                  Depends = depend.Depends
                              }
                              select temp;
                depends = from item in depends
                          where (filter(item))
                          select (item);
                return depends;
            }
        }
        catch (DalReadException e) // if the Dependencies cannot be read, throw an exception
        {
            throw new DalReadException("Dependencies cannot be read", e); // throw an exception
        }
        
        

    }

    public void Update(Dependcys Dependcys)
    {
        if (Dependcys.Id != 0) // if the id is not 0
        {
            var tempDep = _dal.idependancy.Read(Dependcys.Id); // check if the dependancy exists
            if (tempDep == null) // if the dependancy does not exist
            {
                throw new InvalidOperationException("The dependancy does not exist");
            }
        }
        DO.Dependency doDep = new DO.Dependency() // create a new dependancy in the DO layer
        {
            Id = Dependcys.Id,
            DependentTask = Dependcys.DependentTask,
            Depends = Dependcys.Depends
        };
        try
        {
            _dal.idependancy.Update(doDep); // update the dependancy in the DO layer
        }
        catch (DO.BadDependancyIdException ex) // if the dependancy id is invalid
        {
            throw new InvalidOperationException("The dependancy does not exist");
        }
    }
}

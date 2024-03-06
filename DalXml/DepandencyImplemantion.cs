using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DO;

namespace Dal;

    internal class DepandencyImplemantion : IDependency // this class implement IDependency interface
    {
        readonly string Depandency_xml = "Depandencys"; // the file name to save the Depandency

    public int Create(Dependency item)
    {
        List<Dependency> DepandencyList = XMLTools.LoadListFromXMLSerializer<Dependency>(Depandency_xml); // load the list from the file
        //get the new id into the item and only then add him SING CONFIG..///////////////////////////////////////////////////////////////
        int nextId = Config.DependencyId;
        
        DepandencyList.Add(item with { Id = nextId }); // add the Depandency to the list
        XMLTools.SaveListToXMLSerializer(DepandencyList, Depandency_xml); // save the list to the file
        return nextId; // return the id of the Depandency
    }

    public void Delete(int id)
    {
        List<Dependency> DepandencyList = XMLTools.LoadListFromXMLSerializer<Dependency>(Depandency_xml); // load the list from the file
        Dependency Depandency = DepandencyList.Find(e => e.Id == id); // find the Depandency with the given id
        if (Depandency != null)    // if the Depandency exist
        {
            DepandencyList.Remove(Depandency); //  remove the Depandency from the list
            XMLTools.SaveListToXMLSerializer(DepandencyList, Depandency_xml); // save the list to the file
        }
        else
            throw new InvalidOperationException($"Depandency with ID {id} does not exist."); // if the Depandency does not exist throw an exception
    }

    public Dependency? Read(int id)
    {
        List<Dependency> DepandencyList = XMLTools.LoadListFromXMLSerializer<Dependency>(Depandency_xml); // load the list from the file
        Dependency Depandency = DepandencyList.Find(e => e.Id == id); // find the Depandency with the given id
        if (Depandency != null) // if the Depandency exist
            return Depandency; // return the Depandency
        else // if the Depandency does not exist throw an exception
            throw new InvalidOperationException($"Depandency with ID {id} does not exist."); // if the Depandency does not exist throw an exception
    }

    public Dependency? Read(Func<Dependency, bool> filter)
    {
        List<Dependency> DepandencyList = XMLTools.LoadListFromXMLSerializer<Dependency>(Depandency_xml); // load the list from the file
        Dependency Depandency = DepandencyList.Find(e => filter(e)); // find the Depandency that match the filter
        if (Depandency != null) // if the Depandency exist
            return Depandency; // return the Depandency
        else // if the Depandency does not exist throw an exception
            throw new InvalidOperationException($"Depandency with ID {Depandency.Id} does not exist."); // if the Depandency does not exist throw an exception
    }

    public IEnumerable<Dependency?> ReadAll(Func<Dependency, bool>? filter = null)
    {
        List<Dependency> DepandencyList = XMLTools.LoadListFromXMLSerializer<Dependency>(Depandency_xml); // load the list from the file
        if (filter == null) //  if there is no filter
            return DepandencyList; // return the list
        return DepandencyList.Where(filter); // return the list that match the filter
    }

    public void Update(Dependency item)
    {
        List<Dependency> DepandencyList = XMLTools.LoadListFromXMLSerializer<Dependency>(Depandency_xml);
        Dependency Depandency = DepandencyList.Find(e => e.Id == item.Id); // find the Depandency with the given id
        if (Depandency != null) // if the Depandency exist
        {
            DepandencyList.Remove(Depandency); //  remove the Depandency from the list
            DepandencyList.Add(item); // add the Depandency to the list
            XMLTools.SaveListToXMLSerializer(DepandencyList, Depandency_xml); // save the list to the file
        }
        else // if the Depandency does not exist throw an exception
            throw new InvalidOperationException($"Depandency with ID {item.Id} does not exist."); // if the Depandency does not exist throw an exception
    }
}


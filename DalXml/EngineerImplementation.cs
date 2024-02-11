using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DO;
using DalXml;
using Dal;
namespace DalXml;

internal class EngineerImplementation : IEngineer
{
    readonly string engineers_xml = "engineers"; // the file name to save the engineers
    public int Create(Engineer _item)       // this func get an engineer and add it to the list
    {
        List<DO.Engineer> _engineersList = XMLTools.LoadListFromXMLSerializer<Engineer>(engineers_xml); // load the list from the file
        _engineersList.Add(_item); // add the engineer to the list
        XMLTools.SaveListToXMLSerializer(_engineersList, engineers_xml); // save the list to the file
        return _item.Id; // return the id of the engineer
    }

    public void Delete(int _id) // this func get an id and delete the engineer with this id
    {
        List<DO.Engineer> _engineersList = XMLTools.LoadListFromXMLSerializer<Engineer>(engineers_xml); // load the list from the file
        DO.Engineer _engineer = _engineersList.Find(e => e.Id == _id); // find the engineer with the given id
        if (_engineer != null)    // if the engineer exist
        {
            _engineersList.Remove(_engineer); //  remove the engineer from the list
            XMLTools.SaveListToXMLSerializer(_engineersList, engineers_xml); // save the list to the file
        }
        else
            throw new InvalidOperationException($"Engineer with ID {_id} does not exist."); // if the engineer does not exist throw an exception
    }

   
    public DO.Engineer? Read(int id) // this func get an id and return the engineer with this id
    {
        List<DO.Engineer> engineersList = XMLTools.LoadListFromXMLSerializer<Engineer>(engineers_xml); // load the list from the file
        DO.Engineer engineer = engineersList.Find(e => e.Id == id); // find the engineer with the given id
        if (engineer != null) // if the engineer exist
            return engineer; // return the engineer
        return null;
    }

    public DO.Engineer? Read(Func<DO.Engineer, bool> filter) // this func get a filter and return the first _item that match the filter
    {
        List<DO.Engineer> engineersList = XMLTools.LoadListFromXMLSerializer<Engineer>(engineers_xml); // load the list from the file
        DO.Engineer? engineer = engineersList.Where(e => filter(e)).FirstOrDefault(); // find the engineer that match the filter
        if (engineer != null) // if the engineer exist
            return engineer; // return the engineer
        return null;
        // if the engineer does not exist throw an exception
    }

    public IEnumerable<DO.Engineer?> ReadAll(Func<DO.Engineer, bool>? filter = null) // this func return all the engineers
    {
        List<DO.Engineer> engineersList = XMLTools.LoadListFromXMLSerializer<Engineer>(engineers_xml); // load the list from the file
        if (filter == null) //  if there is no filter
            return engineersList.AsEnumerable(); // return all the engineers
        return engineersList.Where(e => filter(e)); // return all the engineers that match the filter
    }

    public void Update(DO.Engineer item) // this func get an engineer and update it
    {
        List<DO.Engineer> engineersList = XMLTools.LoadListFromXMLSerializer<Engineer>(engineers_xml); // load the list from the file
        DO.Engineer? engineer = engineersList.Find(e => e.Id == item.Id); // find the engineer with the given id
        if (engineer != null) // if the engineer exist
        {
            engineersList.Remove(engineer); // remove the engineer from the list
            engineersList.Add(item); // add the updated engineer to the list
            XMLTools.SaveListToXMLSerializer(engineersList, engineers_xml); // save the list to the file
        }          
        else
            throw new InvalidOperationException($"Engineer with ID {item.Id} does not exist."); // if the engineer does not exist throw an exception
    }
}

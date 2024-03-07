using DalApi;
using DO;
using System;

namespace Dal
{
    internal class DependencyImplementation : IDependency
    {
        public int Create(Dependency item) // create a Dependency and return its ID
        {

            int newDependencyId = DataSource.Config.GetNextDependency(); // generate new ID for the Dependency
            Dependency newItem = item with { Id = newDependencyId }; // create a new Dependency with the new ID
            DataSource.Dependencies.Add(newItem); // Add the new Dependency directly into the DataSource
            return newDependencyId; //  return the new Dependency 

            //int newDependencyId = DataSource.Config.GetNextDependency(); // generate new ID for the Dependency
        }

        public void Delete(int id)
        {
            var existingDependency = DataSource.Dependencies.FirstOrDefault(t => t.Id == id); // copy the Dependency with the given ID and store it in a variable

            if (existingDependency == null) // if the Dependency does not exist, throw an exception
            {
                throw new InvalidOperationException($"Dependency with ID {id} does not exist.");
            }

                DataSource.Dependencies.Remove(existingDependency); // remove the Dependency of the given object from the list
        }

        public Dependency Read(int id) // read a Dependency by his ID and return the Dependency
        {
           
            if (DataSource.Dependencies.Any(t => t.Id == id)) // if the Dependency with the given ID exists, return the Dependency
            {
                return DataSource.Dependencies.Where(t => t.Id == id).FirstOrDefault(); // return the Dependency with the given ID
            }
            else
            {
                throw new InvalidOperationException($"Dependency with ID {id} does not exist."); // throw an exception
            }
        }


        public IEnumerable<Dependency> ReadAll(Func<Dependency, bool>? filter = null) //stage 2
        {
            if (filter != null)
            {
                return from item in DataSource.Dependencies
                       where filter(item)
                       select item;
            }
            return from item in DataSource.Dependencies
                   select item;
        }


        public void Update(Dependency item)
        {
            // find the Dependency in the list, if not exist throw exception
                Dependency? found = DataSource.Dependencies.Find(x => x.Id == item.Id) ?? throw new InvalidOperationException($"Dependency with ID {item.Id} does not exist.");

            //find the index of the request Dependency, and replace it with the update one.
            int idx = DataSource.Dependencies.IndexOf(found);
            DataSource.Dependencies[idx] = item;
        }

        public Dependency? Read(Func<Dependency, bool> filter) // stage 2 // this func get a filter and return the first item that match the filter
        {
            return DataSource.Dependencies.Where(filter).FirstOrDefault();
        }
    }
}

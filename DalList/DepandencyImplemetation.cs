using DalApi;
using DO;

namespace Dal
{
    public class DependencyImplementation : IDependency
    {
        public int Create(Dependency item) // create a Dependency and return its ID
        {
            if (item.Id != 0) // if the Dependency already has an ID, throw an exception
            {
                throw new InvalidOperationException("Cannot create Dependency with an existing ID.");
            }

            int newDependencyId = DataSource.Config.NextId; // generate new ID for the Dependency
            var newDependency = new Dependency(newDependencyId, item.DependencyType, item.DependencyId); // Create a new Dependency object with the generated ID
            DataSource.Dependencies.Add(item); // Add the new Dependency directly into the DataSource
            return newDependencyId; //  return the new Dependency 
        }

        public void Delete(int id)
        {
            var existingDependency = DataSource.Dependencies.FirstOrDefault(t => t.Id == id); // copy the Dependency with the given ID and store it in a variable

            if (existingDependency == null) // if the Dependency does not exist, throw an exception
            {
                throw new InvalidOperationException($"Dependency with ID {id} does not exist.");
            }

            if (existingDependency.IsActive) // if the Dependency is active remove him from the list
            {
                DataSource.Dependencies.Remove(existingDependency); // remove the Dependency of the given object from the list
            }
            else
            {
                existingDependency.IsActive = false; // set the Dependency to inactive
            }
        }

        public Dependency Read(int id) // read a Dependency by his ID and return the Dependency
        {
            return DataSource.Dependencies.FirstOrDefault(d => d.Id == id) // copy the Dependency with the given ID and store it in a variable
                ?? throw new InvalidOperationException($"Dependency with ID {id} does not exist.");
        } 

        public List<Dependency> ReadAll() 
        {
            return DataSource.Dependencies.ToList(); // return a list of all Dependencies in the DataSource by making a copy of the list and returning it
        }

        public void Update(Dependency item)
        {
            var existingDependency = DataSource.Dependencies.FirstOrDefault(t => t.Id == item.Id); // copy the Dependency with the given ID and store it in a variable

            if (existingDependency == null) // if the Dependency does not exist, throw an exception
            {
                throw new InvalidOperationException($"Dependency with ID {item.Id} does not exist."); // throw an exception
            }

            DataSource.Dependencies.Remove(existingDependency); // remove the Dependency of the given object from the list
            DataSource.Dependencies.Add(item); // Add the new Dependency directly into the DataSource
        }


    }
}

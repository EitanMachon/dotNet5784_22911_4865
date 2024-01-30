namespace BlApi;
/// <summary>
///  this is the interface of the BL layer that is used to implement the BL layer  functions of the Engineer
/// </summary>

namespace BO
{
    internal interface IDependency
    {
        public int create(BO.IDependency IDependency); // this function get a task and create it in the database

        public BO.IDependency? read(int id); // this function get an id and return the task that match the id

        public BO.IDependency? read(Func<BO.IDependency, bool> filter); // this func get a filter and return the first item that match the filter

        public IEnumerable<BO.IDependency?> readAll(Func<BO.IDependency, bool>? filter = null); // this function return all the tasks in the database

        public void update(BO.IDependency IDependency); // this function get a task and update it in the database

        public void delete(BO.IDependency IDependency); // this function get a task and delete it from the databa
}
}

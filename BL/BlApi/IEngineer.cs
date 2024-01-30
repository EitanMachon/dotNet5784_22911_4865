namespace BlApi;
/// <summary>
///  this is the interface of the BL layer that is used to implement the BL layer  functions of the Engineer
/// </summary>

namespace BL
{
    internal interface IEngineer
    {
        public int create(BO.Engineer Engineer); // this function get a task and create it in the database

        public BO.Engineer? read(int id); // this function get an id and return the task that match the id

        public BO.Engineer? read(Func<BO.Engineer, bool> filter); // this func get a filter and return the first item that match the filter

        public IEnumerable<BO.Engineer?> readAll(Func<BO.Engineer, bool>? filter = null); // this function return all the tasks in the database

        public void update(BO.Engineer Engineer); // this function get a task and update it in the database

        public void delete(BO.Engineer Engineer); // this function get a task and delete it from the databa
    }
}

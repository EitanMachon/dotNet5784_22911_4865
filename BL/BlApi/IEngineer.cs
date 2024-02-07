
/// <summary>
///  this is the interface of the BL layer that is used to implement the BL layer  functions of the Engineer
/// </summary>

namespace BLApi;

public interface IEngineer
{
    public int Create(BO.Engineer Engineer); // this function get a task and create it in the database

    public BO.Engineer? Read(int id); // this function get an id and return the task that match the id

    public IEnumerable<BO.Engineer?> ReadAll(Func<BO.Engineer, bool>? filter = null); // this function return all the tasks in the database

    public void Update(BO.Engineer Engineer); // this function get a task and update it in the database

    public void Delete(int id); // this function get a task and delete it from the databa
}

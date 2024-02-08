
/// <summary>
///  this is the interface of the BL layer that is used to implement the BL layer  functions of the Engineer
/// </summary>

namespace BLApi;
/// <summary>
/// this is the interface of the BL layer that is used to implement the BL layer  functions of the Engineer
/// </summary>
public interface IEngineer
{
    /// <summary>
    /// this function get a Engineer and create it in the database
    /// </summary>
    public int Create(BO.Engineer Engineer); // this function get a task and create it in the database
    /// <summary>
    /// this function get an id and return the Engineer that match the id
    /// </summary>
    public BO.Engineer? Read(int id); // this function get an id and return the task that match the id
    /// <summary>
    /// this function return all the Engineer in the database that match the filter
    /// </summary>
    public IEnumerable<BO.Engineer?> ReadAll(Func<BO.Engineer, bool>? filter = null); // this function return all the tasks in the database
    /// <summary>
    /// this function get a Engineer and update it in the database
    /// </summary>
    public void Update(BO.Engineer Engineer); // this function get a task and update it in the database
    /// <summary>
    /// this function get an id and delete the Engineer that match the id from the database
    /// </summary>
    public void Delete(int id); // this function get a task and delete it from the databa
}
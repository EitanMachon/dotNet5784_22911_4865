namespace BlImplementation;
using BlApi;
using BLApi;
using BlImplenentation;
/// <summary>
/// this class is the implementation of IBl interface and it is the main class of the BL layer 
/// </summary>
internal class Bl : IBl
{
    /// <summary>
    /// return new instance of ITask
    /// </summary>
    public ITask Task => new TaskImplementation();
    /// <summary>
    /// return new instance of IEngineer
    /// </summary>
    public IEngineer Engineer =>  new EngineerImplenentation();
}





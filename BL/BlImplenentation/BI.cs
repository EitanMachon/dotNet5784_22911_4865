using BlApi;
using Bl;
//using DalApi;
using BlImplenentation;
using BLApi;



namespace BlImplementation;
internal class Bl : IBl
{
    public ITask Task => new TaskImplementation();
    public IEngineer Engineer =>  new EngineerImplenentation();
}





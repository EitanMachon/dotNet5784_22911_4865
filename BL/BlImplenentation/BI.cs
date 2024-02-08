namespace BlImplementation;
using BlApi;
using BlImplenentation;

internal class Bl : IBl
{
    public ITask Task => new TaskImplementation();
    public IEngineer Engineer =>  new EngineerImplenentation();
}





namespace Dal;
using DalApi;
sealed internal class DalList : IDal
{
    public static DalList Instance { get; } = new DalList(); // Singleton

    private DalList() { } // private constructor

    public IDependency idependancy => new DependencyImplementation();

    public IEngineer iengineer => new EngineerImplementation();

    public ITask itask => new TaskImplementaion();
}


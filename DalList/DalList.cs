namespace Dal;
using DalApi;
sealed public class DalList : IDal
{
    public IDependency idependancy => new DependencyImplementation();

    public IEngineer iengineer => new EngineerImplementation();

    public ITask task => new TaskImplementaion();
}


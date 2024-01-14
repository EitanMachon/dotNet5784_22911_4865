using System;
using DalApi;
using DO;
//namespace DO;
//namespace DalApi;
//namespace Dal;

public interface IDal
{
    IDependency idependancy { get; } // property to access the dependency DAL object
    IEngineer iengineer { get; } // property to access the engineer DAL object
    ITask task { get; } // property to access the task DAL object
}

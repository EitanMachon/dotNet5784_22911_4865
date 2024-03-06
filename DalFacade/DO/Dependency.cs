using System;
namespace DO;

public record Dependency
(
     int Id, // The id of the dependency
     int DependentTask,  // The id of the dependent task
     int Depends // The id of the task that the dependent task depends on
) 
{
    public Dependency() : this(0, 0, 0) { }
}

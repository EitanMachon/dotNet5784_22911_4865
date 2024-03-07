using System;
namespace DO;

public record Dependency
(
     int Id, // the id of the dependency
     int DependentTask,// befor task
     int Depends// the task
)
{
    public Dependency() : this(0, 0, 0) { }
}

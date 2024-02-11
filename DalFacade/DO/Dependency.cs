using System;
namespace DO;

public record Dependency
(
     int Id,
     int DependentTask,
     int Depends
)
{
    public Dependency() : this(0, 0, 0) { }
    public bool IsActive { get; set; } = false; // default value for new dependencies
}

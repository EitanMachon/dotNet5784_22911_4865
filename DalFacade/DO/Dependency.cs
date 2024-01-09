using System;
namespace DO;

public record Dependency
(
     int Id,
     int DependentTask,
     int Depends
)
{
    public object TaskId;
    public int DependencyType;

    public Dependency() : this(0, 0, 0) { }
    public bool IsActive { get; set; } = false; // default value for new dependencies
    public int Id { get; init; } // 'init' allows setting during object initialization
    public int DependencyId { get; set; }
}
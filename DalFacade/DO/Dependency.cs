using System;
namespace DO;

public record Dependency
(
     int id,
     int DependentTask,
     int Depends
)
{
    public Dependency() : this(0, 0, 0) { } //ctor
}

namespace DO;

public record Depandency
(
     int id,
     int DependentTask,
     int Depends
)
{
    public Depandency() : this(0, 0, 0) { }
}
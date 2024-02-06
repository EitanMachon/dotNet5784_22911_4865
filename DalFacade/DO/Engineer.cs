
namespace DO;

public record Engineer
(
    int Id,
    string Name,
    string Email,
    double SalaryHour,
    EngineerExperience Level
)
{

    public Engineer() : this(0, "", "", 0, 0) { } // empty ctor
    public bool IsActive { get; set; } = false; // default value for new engineers
    public int Id { get; init; } // 'init' allows setting during object initialization

    public static implicit operator int(Engineer v)
    {
        throw new NotImplementedException();
    }
}

namespace DO;

public record Engineer
(
    int Id,
    string Name,
    string Email,
    double SalaryHour
// fix this method;
     EngineerExperience Level
)
    
{
    public Engineer():this(0, "", "", 0, 0) { }
    }

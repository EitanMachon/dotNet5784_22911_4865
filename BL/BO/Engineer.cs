using System.Xml.Linq;


namespace BO;

public class Engineer
{
    private int id5;
    private double updateSalary;
    private global::EngineerExperience level;

    public Engineer()
    {
    }

    public Engineer(int id5, string? name, string? email, double updateSalary, global::EngineerExperience level)
    {
        this.id5 = id5;
        Name = name;
        Email = email;
        this.updateSalary = updateSalary;
        this.level = level;
    }

    public int Id { get; init;} // this is the id of the engineer
public string Name { get; init; } // this is the name of the engineer
public string Email { get; set; } // this is the email of the engineer
public double SalaryHour { get; set; } // this is the salary per hour of the engineer
public EngineerExperience Level { get; set; } // this is the level of the engineer
public BO.TaskInEngineer Task { get; set; } // this is the task of the engineer
}

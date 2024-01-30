using System.Xml.Linq;


namespace BO
{
    internal class Engineer
    {
  public int Id { get; init;} // this is the id of the engineer
    public string Name { get; init; } // this is the name of the engineer
    public string Email { get; set; } // this is the email of the engineer
    public double SalaryHour { get; set; } // this is the salary per hour of the engineer
    public EngineerExperience Level { get; set; } // this is the level of the engineer
    }
}

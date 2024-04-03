namespace BlImplementation;
using BlApi;
using BLApi;
using BlImplenentation;

/// <summary>
/// this class is the implementation of IBl interface and it is the main class of the BL layer 
/// </summary>
internal class Bl : IBl
{
    /// <summary>
    /// return new instance of ITask
    /// </summary>
    public ITask Task => new TaskImplementation(this);
    /// <summary>
    /// return new instance of IEngineer
    /// </summary>
    // public void (DateTime a);

    public IEngineer Engineer =>  new EngineerImplenentation();
    
    public ISchedule Schedule => new ScheduleImplementation();
    public IDependency Dependency => new DependencyImplemation();
    static readonly BlApi.IBl s_bl = BlApi.Factory.Get();

    private static DateTime s_Clock = s_bl.Schedule.GetNowDate() ?? DateTime.Now;
    public DateTime Clock { get { return s_Clock; }
    
    private set { s_Clock = value; } } 

      
    //public IDependency Dependency => new DependencyImplemation();
    public DateTime AddYear( int year)
    {
        s_Clock = s_Clock.AddYears(year);
        s_bl.Schedule.SetNowDate(Clock);
        return s_Clock;
    }

    public DateTime AddMonth( int month)
    {
        s_Clock = s_Clock.AddMonths(month);
        s_bl.Schedule.SetNowDate(Clock);
        return s_Clock;
    }

    public DateTime AddDay(int day)
    {
        s_Clock = s_Clock.AddDays(day);
        s_bl.Schedule.SetNowDate(Clock);
        return s_Clock;
    }

    public DateTime AddHour( int hour)
    {


        s_Clock = s_Clock.AddHours(hour);
        s_bl.Schedule.SetNowDate(Clock);
        return s_Clock;
    }
    public void ResteClock()
    {
        
        s_Clock = DateTime.Now;
        s_bl.Schedule.SetNowDate(s_Clock);
    }


}

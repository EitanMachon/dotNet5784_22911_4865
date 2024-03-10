using BLApi;

namespace BlApi;

/// <summary>
/// this static class is used to create the BlApi layer that is used to implement the BL layer functions of the task
/// </summary>  
public interface IBl
{
    /// <summary>
    /// this is the interface of the BL layer that is used to implement the BL layer  functions of the task
    /// </summary>
    public ITask Task { get; }  // this is the interface of the BL layer that is used to implement the BL layer  functions of the Task
    /// <summary>
    /// this is the interface of the BL layer that is used to implement the BL layer  functions of the engineer
    /// </summary>
    public IEngineer Engineer { get; } // this is the interface of the BL layer that is used to implement the BL layer  functions of the Engineer

    //  public IDependency Dependency { get; } // this is the interface of the BL layer that is used to implement the BL layer  functions of the Dependency

    //public void setT(DateTime a);
    public ISchedule Schedule { get; } // this is the interface of the BL layer that is used to implement the BL layer  functions of the Schedule
    
    public DateTime Clock { get; } // this is the interface of the BL layer that is used to implement the BL layer  functions of the clock

    public DateTime AddYear( int year);
    public DateTime AddMonth( int month);
    public DateTime AddDay(int day);

    public DateTime AddHour(int hour);
    public void ResteClock();

    // void setT(DateTime currentTime);
}


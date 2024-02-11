namespace BlImplementation;
using BlApi;
using System;
/// <summary>
/// this is a class that implements the ISchedule interface that is used to get and set the start and end date of the schedule
/// </summary>

internal class ScheduleImplementation : ISchedule
{
    private IDal _dal = DalApi.Factory.Get; // this is a private field of type IDal that is initialized with the DalApi.Factory.Get
    /// <summary>
    /// // this is a method that returns the end date of the schedule
    /// </summary>
    public DateTime? GetEndDate()
    {
        return _dal.ischedule.GetEndDate();
    }
    /// <summary>
    /// this is a method that returns the start date of the schedule
    /// </summary>
    public DateTime? GetStartDate()
    {
        return _dal.ischedule.GetStartDate();
    }
    /// <summary>
    /// this is a method that sets the end date of the schedule
    /// </summary>
    public void SetEndDate(DateTime? endDate)
    {
        _dal.ischedule.SetEndDate(endDate);
    }
    /// <summary>
    /// this is a method that sets the start date of the schedule
    /// </summary>
    public void SetStartDate(DateTime? time)
    {
        _dal.ischedule.SetStartDate(time);
    }
}

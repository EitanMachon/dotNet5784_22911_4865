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
    /// this is a method that saves the dates in the dal
    /// </summary>
    public void SaveSchedule()
    {
        
        _dal.ischedule.SaveSchedule(); // this is a call to the SaveSchedule method of the dal
    }
    public DateTime? GetProjectStartDateTime()
    {
        return _dal.ischedule.GetProjectStartDateTime(); // this is a call to the SaveSchedule method of the dal
    }

}

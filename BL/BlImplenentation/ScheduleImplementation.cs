namespace BlImplementation;
using BlApi;
using DalApi;
using System;

internal class ScheduleImplementation : ISchedule
{
    private IDal _dal = DalApi.Factory.Get;

    public DateTime? GetEndDate()
    {
        return _dal.Schedule.GetEndDate();
    }

    public DateTime? GetStartDate()
    {
        return _dal.Schedule.GetStartDate();
    }

    public void SetEndDate(DateTime? endDate)
    {
        _dal.Schedule.SetEndDate(endDate);
    }

    public void SetStartDate(DateTime time)
    {
        _dal.Schedul.SetStartDate(time);
    }
}

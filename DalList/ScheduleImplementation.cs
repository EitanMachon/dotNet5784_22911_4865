
namespace Dal;

internal class ScheduleImplementation : DalApi.ISchedule
{
    public DateTime? GetProjectStartDateTime()
    {
        throw new NotImplementedException();
    }

    public bool getTasks()
    {
        throw new NotImplementedException();
    }

    public void SaveSchedule()
    {
        // we do not have something to save here...
    }
    public DateTime? GetNowDate()
    {
        return DataSource.Config.NowDate;
    }

    public void SetNowDate(DateTime? nowDate)
    {
        DataSource.Config.NowDate = nowDate;
    }
}


using System.Xml.Linq;

namespace Dal;

internal class ScheduleImplementation : DalApi.ISchedule
{
    public DateTime? GetProjectStartDateTime()
    {
        throw new NotImplementedException();
    }

    public bool getTasks()
    {
        List<DO.Task> tasks = DataSource.Tasks;
        if (tasks.All(task => task.ScheduledTime != null))
        {
            SaveSchedule();
            return true;
        }
        return false;
    }

    public void SaveSchedule()
    {
        List<DO.Task> tasks = DataSource.Tasks;

        if (tasks.Count > 0) // save only if there are tasks
        {
            DateTime? scheduleDate = tasks.Min(task => task.ScheduledTime); // Find the minimum StartDate
           DataSource.Config.ProjectStartDate= scheduleDate;
        }
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

namespace Dal;

internal class ScheduleImplementation
{
    public DateTime? GetEndDate()
    {
        return DataSource.Config.ProjectEndDate;
    }

    public DateTime? GetStartDate()
    {
        return DataSource.Config.ProjectStartDate;
    }

    public void SetEndDate(DateTime? date)
    {

        DataSource.Config.ProjectEndDate = date;
    }

    public void SetStartDate(DateTime? date)
    {
        DataSource.Config.ProjectStartDate = date;
    }

   
}

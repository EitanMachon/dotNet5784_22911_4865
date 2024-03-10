namespace DalApi;

public interface ISchedule
{
    void SaveSchedule();
    DateTime? GetProjectStartDateTime();
    public bool getTasks();
    public DateTime? GetNowDate();

    public void SetNowDate(DateTime? nowDate);
}

namespace DalApi;

public interface ISchedule
{
    void SaveSchedule();
    DateTime? GetProjectStartDateTime();
    public bool getTasks();
}

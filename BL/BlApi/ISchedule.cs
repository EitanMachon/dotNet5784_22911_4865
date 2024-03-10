namespace BlApi;

public interface ISchedule // this is an interface for the schedule class
{
    public void SaveSchedule();

    public bool getGantt();
    public DateTime? GetNowDate() ;

    public void SetNowDate(DateTime? nowDate);
}

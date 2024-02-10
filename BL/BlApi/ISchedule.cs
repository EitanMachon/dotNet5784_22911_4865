namespace BlApi;

internal interface ISchedule // this is an interface for the schedule class
{
    /// <summary>
    /// this is a method that returns the start date of the schedule
    /// </summary>
    DateTime? GetStartDate();
    /// <summary>
    /// this is a method that returns the end date of the schedule
    /// </summary>
    DateTime? GetEndDate();
    /// <summary>
    /// this is a method that sets the start date of the schedule
    /// </summary>
    void SetStartDate(DateTime? startDate);
    /// <summary>
    /// this is a method that sets the end date of the schedule
    /// </summary>
    void SetEndDate(DateTime? endDate);
}

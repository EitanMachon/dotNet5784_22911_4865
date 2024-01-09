namespace DO;

public record Task
(
   int Id,
   string Alias,
   string Description,
   DateTime CreatedAtDate,
   TimeSpan RequiredEffort,
   bool IsMilestone,
   EngineerExperience Copmlexity,
   DateTime StartDate,
   DateTime ScheduledTime,
   DateTime DeadLinetime,
   DateTime ComplateTime,
   string Dekiverables,
   string Remarks,
   int EngineerId,
   EngineerExperience Difficulty
)
{ 
    public Task():this(0, "", "", DateTime.Now, TimeSpan.Zero, false, EngineerExperience.Beginner, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, "", "", 0, EngineerExperience.Beginner) { }
};
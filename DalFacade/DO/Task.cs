using System.Xml.Linq;

namespace DO;

public record Task
(
   int Id,
   string Alias,
   string Description,
   DateTime CreatedAtDate,
   TimeSpan RequiredEffort,
   EngineerExperience? Copmlexity,
   DateTime? StartDate,
   DateTime? ScheduledTime,
   DateTime? DeadLinetime,
   DateTime? ComplateTime,
   string Dekiverables,
   string Remarks,
   int EngineerId
)
{
    public bool IsActive { get; set; } = false; // default value for new engineers
    public Task() : this(0, "", "", DateTime.Now, TimeSpan.Zero, EngineerExperience.Beginner, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, "", "", 0) { } // default ctor
};
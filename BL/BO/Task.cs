using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class Task
{
    public int Id { get; init; }
    public string Alias { get; set; }
    public string Description { get; set; } 
    public DateTime CreatedAtDate { get; set; }

    public TimeSpan RequiredEffort { get; set; }
    public bool IsMilestone { get; set; }

    public EngineerExperience { get; set; }
public DateTime? StartDate { get; set; }
public DateTime? ScheduledTime { get; set; }
public DateTime? DeadLinetime { get; set; }
public DateTime? ComplateTime { get; set; }
public string Dekiverables { get; set; }
public string Remarks { get; set; }
public int EngineerId { get; set; }
public EngineerExperience Difficulty { get; set; }

}

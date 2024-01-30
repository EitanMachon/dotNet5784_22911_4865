using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class Task
{
    public int Id { get; init; } // this is the id of the task
    public string Alias { get; init; } // this is the alias of the task
    public string Description { get; set; } // this is the description of the task
    public DateTime CreatedAtDate { get; set; } // this is the date the task was created

    public TimeSpan RequiredEffort { get;  } // this is the required effort of the task
    public bool IsMilestone { get; set; } // this is the milestone of the task

 public EngineerExperience Copmlexity { get; set; } // this is the complexity of the task   
public DateTime? StartDate { get; }  // this is the start date of the task
public DateTime? ScheduledTime { get; set; } // this is the scheduled time of the task
public DateTime? DeadLinetime { get; set; } // this is the deadline time of the task
public DateTime? ComplateTime { get; } // this is the complete time of the task
public string Dekiverables { get; set; } // this is the deliverables of the task
public string Remarks { get; set; } // this is the remarks of the task
public int EngineerId { get; set; } // this is the id of the engineer
public EngineerExperience Difficulty { get; set; } // this is the difficulty of the task

}

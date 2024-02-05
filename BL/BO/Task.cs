namespace BO;

using System;
using DO;
using DalApi;

public class Task 
{
    public int Id { get; init; } // this is the id of the task
    public string Description { get; set; } // this is the description of the task
    public string Alias { get; init; } // this is the alias of the task
    public DateTime CreatedAtDate { get; set; } // this is the date the task was created
    // public BO.Status status { get; set; } // this is the status of the task
    // public List<BO.TaskInList> Dependencys { get; set; } // this is the list of the tasks
    public List<BO.TaskInList> Dependencys { get; set; } // this is the list of the tasks and its not working because of the namespace of the TaskInList th
    public TimeSpan RequiredEffort { get;  } // this is the required effort of the task
    // public bool IsMilestone { get; set; } // this is the milestone of the task
    public DateTime? StartDate { get; }  // this is the start date of the task
    public DateTime? ScheduledTime { get; set; } // this is the scheduled time of the task
    public BO.EngineerExperience Copmlexity { get; set; } // this is the complexity of the task   


    // public DateTime? DeadLinetime { get; set; } // this is the deadline time of the task
    public DateTime? ComplateTime { get; } // this is the complete time of the task
    public string Dekiverables { get; set; } // this is the deliverables of the task
    public string Remarks { get; set; } // this is the remarks of the task
    public BO.EngineerInTask? Engineer { get; set; } // this is the engineer of the task
public BO.EngineerExperience Difficulty { get; set; } // this is the difficulty of the task

}

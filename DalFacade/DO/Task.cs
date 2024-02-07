﻿using System.Xml.Linq;

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
   DateTime? StartDate,
   DateTime? ScheduledTime,
   DateTime? DeadLinetime,
   DateTime? ComplateTime, 
   string Dekiverables,
   string Remarks,
   int EngineerId,
   EngineerExperience Difficulty
)
{
    public DateTime ForecastDate;

    public bool IsActive { get; set; } = false; // default value for new engineers
    public int Id { get; init; } // 'init' allows setting during object initialization
    public Task():this (0, "", "", DateTime.Now, TimeSpan.Zero, false, EngineerExperience.Beginner, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, "", "", 0, EngineerExperience.Beginner) { } // default ctor
    public Task (int _id1,
   string _alias,
   string _description,
   DateTime _createdDate,
   TimeSpan _requiredHours,
   bool _isMilestone,
   EngineerExperience _complexity,
   DateTime ? StartDate,
   DateTime ? _finishDate,
   DateTime ? _deadlineDate,
   DateTime ? ComplateTime,
   string _whatYouDid,
   string _remark,
   int _engineerId,
   EngineerExperience _difficulty)
                   

    {
        Id = _id1;
        Alias = _alias;
        Description = _description;
        CreatedAtDate = _createdDate;
        RequiredEffort = _requiredHours;
        IsMilestone = _isMilestone;
        Copmlexity = _complexity;
        StartDate = DateTime.Now;
        ScheduledTime = _finishDate; 
        DeadLinetime = _deadlineDate;
        ComplateTime = DateTime.Now;
        Dekiverables = _whatYouDid;
        Remarks= _remark;
        EngineerId = _engineerId;
        Difficulty = (EngineerExperience)_difficulty;

    }
    public static explicit operator Task(XElement v) // explicit conversion operator we adaded it to convert from XElement to Task
    {
        throw new NotImplementedException();
    }
};
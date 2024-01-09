﻿namespace DO;

public record Engineer
(
    int Id,
    string Name,
    string Email,
    double SalaryHour,
    EngineerExperience Level
)
{
    public Engineer(int _id) : this(0, "", "", 0, 0) { } // default ctor
    public bool IsActive { get; set; } = false; // default value for new engineers
    public int Id { get; init; } // 'init' allows setting during object initialization
}

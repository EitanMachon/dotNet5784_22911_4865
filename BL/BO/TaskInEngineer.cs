using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class TaskInEngineer
{
    private object name;

    public int Id { get; init; } // this is the id of the task
    public string Alias { get; set; } // this is the alias of the task

    //TaskInEngineer(int id, string alias) // constructor of the TaskInEngineer
    //{
    //    Id = id; // set the id of the task
    //    Alias = alias; // set the alias of the task
    //}

    //public TaskInEngineer(int id, object name)
    //{
    //    Id = id;
    //    this.name = name;
    //}
}

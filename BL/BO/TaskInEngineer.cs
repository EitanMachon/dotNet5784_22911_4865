using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;
/// <summary>
/// this class is used to represent a task in the list of tasks of an engineer in the BL layer
/// </summary>
public class TaskInEngineer
{
    private object name;

    public int Id { get; init; } // this is the id of the task
    public string Alias { get; set; } // this is the alias of the task

    
}

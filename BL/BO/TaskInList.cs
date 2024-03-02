using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;
/// <summary>
///  this class is used to represent a task in the list of tasks
/// </summary>
public class TaskInList
{   
    /// <summary>
    /// this is the id of the task in the list
    /// </summary>
    public int Id { get ; init; } // this is the id of the task
    /// <summary>
    /// this is the description of the task in the list
    /// </summary>
    public string Description { get; set; } // this is the description of the task
    /// <summary>
    /// this is the alias of the task in the list
    /// </summary>
    public string Alias { get; set; } // this is the alias of the task
    /// <summary>
    /// this is the status of the task in the list and we get the status from the status enum
    /// </summary>
    public BO.Status status { get; set; } // this is the status of the task

}

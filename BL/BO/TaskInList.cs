using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class TaskInList
{   
    public int Id { get ; init; } // this is the id of the task
    public string Description { get; set; } // this is the description of the task
    public string Alias { get; init; } // this is the alias of the task
    public BO.Status status { get; set; } // this is the status of the task
}

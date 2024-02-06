using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class EngineerInTask
{
    public int Id { get; init; } // this is the id of the task
    public string Name { get; init; } // this is the name of the engineer

    EngineerInTask(int id, string name) // constructor of the EngineerInTask
    {
        Id = id; // set the id of the engineer
        Name = name; // set the name of the engineer
    }

}

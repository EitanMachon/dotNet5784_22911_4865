using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;
/// <summary>
///  this class helps to show the engineer in the task
/// </summary>
public class EngineerInTask
{
    public int Id { get; init; } // this is the id of the task
    public string Name { get; set; } // this is the name of the engineer

    //EngineerInTask(int id, string name) // constructor of the EngineerInTask
    //{
    //    Id = id; // set the id of the engineer
    //    Name = name; // set the name of the engineer
    //}
    //EngineerInTask(DO.Engineer _engineer)
    //{
    //    Id = 0; // set the id of the engineer to 0
    //    Name = null; // set the name of the engineer to null
    //}
    //EngineerInTask(EngineerInTask engineerInTask) // copy constructor of the EngineerInTask
    //{
    //    Id = engineerInTask.Id; // set the id of the engineer
    //    Name = engineerInTask.Name; // set the name of the engineer
    //}

}

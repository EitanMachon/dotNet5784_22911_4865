﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DalApi;
using DalXml;
//using Do;
namespace Dal;




//stage 3
sealed internal class DalXml : IDal
{
    public static DalXml Instance { get; } = new DalXml(); // Singleton

    private DalXml() { } // private constructor

    public ITask itask => new TaskImplementation();

    public IDependency idependancy => new DepandencyImplemantion();

    public IEngineer iengineer => new EngineerImplementation();

    public ISchedule ischedule => new ScheduleImplementation();
}

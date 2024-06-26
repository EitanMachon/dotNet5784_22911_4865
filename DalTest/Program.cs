﻿// See https://aka.ms/new-console-template for more information
using Dal;
using DalApi;
using deleteXml;
using DO;
using DalXml;
using System;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Xml.Linq;
namespace Dal;




class Program
{
    //stage 1
    //private static IDependency? s_dalDependency = new DependencyImplementation(); //stage 1
    //private static IEngineer? s_dalEngineer = new EngineerImplementation(); //stage 1 
    //private static ITask? s_dalTasks = new TaskImplementaion();//stage 1`   
    // static readonly IDal s_dal = new DalList(); //stage 2
    //static readonly IDal s_dal = new DalXml(); //stage 3
    static readonly IDal s_dal = Factory.Get; //stage 4

    static EngineerExperience[] experience = {
    EngineerExperience.Beginner,
    EngineerExperience.AdvancedBeginner,
    EngineerExperience.Intermediate,
    EngineerExperience.Advanced,
    EngineerExperience.Expert
};// the array of the level of the engineer


   
    
    public static void DepandencyRun()// the function run the task 
    {
        Console.WriteLine("choose a Item to check:0 for exit ,1 for Creat, 2 for Read, 3 for ReadAll, 4 for Update, 5 for Delete");
        int a = int.Parse(Console.ReadLine());
        try
        {
            int _id1;
            int _dt, _dep;
            switch (a)
            {
                

                case 1://Creat 
                    //gets all params from user 
                    Console.WriteLine("put a new id:");// get id for the depandency
                    _id1 = int.Parse(Console.ReadLine()); // get the id
                //    n1.Id = _id1; // put the id in the depandency
                    Console.WriteLine("put a depandendent task:");// get id for the depandency
                    _dt = int.Parse(Console.ReadLine()); // get the depandendent task
                //    n1.DependentTask = _dt; // put the depandendent task in the depandency
                    Console.WriteLine("put a depans task:");// get id for the depandency
                    _dep = int.Parse(Console.ReadLine()); // get the depans task
                //    n1.DependensTask = _dep; // put the depans task in the depandency
                    Dependency n1 = new Dependency(_id1, _dt, _dep); // create a new depandency
                    s_dal.idependancy.Create(n1);// send to creat
                    break;
  
                case 2:// Read 
                    Console.WriteLine("put a id for read:");// get id for the depandency
                    _id1 = int.Parse(Console.ReadLine());
                    s_dal.idependancy.Read(_id1);// send to creat
                    break;

                case 3: // ReadAll
                    s_dal.idependancy.ReadAll();// send to readall
                    break;

                case 4: // Update
                    Console.WriteLine("put a id to update:");// get id for the depandency
                    int _id3 = int.Parse(Console.ReadLine()); // get the id

                    DO.Dependency Help = s_dal.idependancy.Read(_id3); // get the needed depandency
                    Console.WriteLine(Help); // print depandency values

                    Console.WriteLine("put a depandendent task:");// get id for the depandency
                    _dt = int.Parse(Console.ReadLine()); // get the depandendent task

                    Console.WriteLine("put a depans task:"); // get id for the depandency
                    _dep = int.Parse(Console.ReadLine()); // get the depans task

                    Dependency tempDep = new(_id3, _dt, _dep); // create a new depandency
                    s_dal.idependancy.Update(tempDep); // update the depandency
                    break;

                case 5: // Delete 
                    Console.WriteLine("put a id for read:");// get id for the depandency
                    int _id2 = int.Parse(Console.ReadLine());
                    s_dal.idependancy.Delete(_id2);// send to Delete
                    break;

                default:
                    Console.WriteLine("there is no option like that");
                    break;
            }
        }
        catch (Exception e)// get if thier is exaption 
        {
            Console.WriteLine(e.Message);
        }
    }

    
 public static void EngineerRun()// the function run the engineer 
    {

        Console.WriteLine(@"put an action: 
    1 for Creat
    2 for Read
    3 for ReadAll
    4 for Update
    5 for Delete "); // print the options to the user

        int _a = int.Parse(Console.ReadLine());
        try
        {
            string _name;
            string _email;
            string hel;
            double updateSalary=0;
            EngineerExperience level;
            string _givenLevelStr;
            switch (_a)
            {
                case 1://Creat
                    Console.WriteLine("put a new id:");// get id for the engineer
                    int _id1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("put a name:");// get name for the engineer
                     _name = Console.ReadLine();
                   //  n1.Name = _name;
                    Console.WriteLine("put a email:");// get email for the engineer
                    _email = Console.ReadLine();                                
                    // n1.Email = _email;
                    Console.WriteLine("put a salary:");// get salary for the engineer
                        double _salary = double.Parse(Console.ReadLine());
                    //n1.SalaryHour = _salary;
                    Console.WriteLine("put a level: (0-4) ");// get level for the engineer
                    _givenLevelStr = Console.ReadLine();
                    level = (EngineerExperience)int.Parse(_givenLevelStr);
                    Engineer n1 = new Engineer {Id = _id1,Name= _name,Email = _email,SalaryHour= _salary, Level = level };
                    s_dal.iengineer.Create(n1);// send to creat
                    break;

                case 2:// Read 
                    Console.WriteLine("put a id fr read:");// get id for the engineer
                    int _id2 = int.Parse(Console.ReadLine());
                    s_dal.iengineer.Read(_id2);// send to read
                    break;

                case 3: // ReadAll
                    s_dal.iengineer.ReadAll();// send to readall function
                    break;

                case 4: // Update
                    {
                        Console.WriteLine("Enter engineer id:");
                        int _id5 = int.Parse(Console.ReadLine());

                        DO.Engineer Help = s_dal.iengineer.Read(_id5); // get the needed engineer
                        Console.WriteLine(Help); // print engineer values


                        Console.WriteLine("Enter engineer name:");
                        _name = Console.ReadLine();
                        if (_name == "")      /// if the input "", use the previous name
                            _name = Help.Name;

                        Console.WriteLine("Enter engineer email:");
                        _email = Console.ReadLine();
                        if (_email == "")      /// if the input empty, use the previous email
                            _email = Help.Email;

                        Console.WriteLine("Enter engineer salary:");
                        hel = Console.ReadLine();
                        if (hel != "")      /// if the input empty, use the previous cost
                            updateSalary = double.Parse(Console.ReadLine());
                        if (hel == "")      /// if the input empty, use the previous cost
                        {
                            updateSalary = Help.SalaryHour;
                        }


                        Console.WriteLine("Enter engineer level:");
                        hel = Console.ReadLine();
                        if (hel == "")
                        {       
                            level = (EngineerExperience)(int)Help.Level;
                        }

                       // level = (EngineerExperience)int.Parse(_givenLevelStr);
                        else
                        {
                            _givenLevelStr = Console.ReadLine();

                            level = (EngineerExperience)int.Parse(_givenLevelStr);
                        }

                        Engineer tempEng = new(_id5, _name, _email, updateSalary, level); // create a new engineer
                        s_dal.iengineer.Update(tempEng);
                    }
                    break;
                case 5: // Delete 
                    Console.WriteLine("put a id delete:");// get id for the engineer
                    int _id4 = int.Parse(Console.ReadLine());
                    s_dal.iengineer.Delete(_id4);
                    break;

                default:
                    Console.WriteLine("there is no option like that");
                    break;
            }
        }
        catch (Exception e)// get if thier is exaption 
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void TaskRun()// the function run the depandency 
    {
        Console.WriteLine("choose a Item to check:0 for exit ,1 for Creat, 2 for Read, 3 for ReadAll, 4 for Update, 5 for Delete");
        int a = int.Parse(Console.ReadLine());
        try
        {
            int _id1;
            DateTime _createDate;
            string _description="";
            string _alias="";
            EngineerExperience _complexity;
            TimeSpan _requiredHours;
            string _whatYouDid;
            string _somethingToSay="";
            switch (a)
            {
                case 1://Creat 
                    Console.WriteLine("put a new id:");// get id for the task
                    _id1 = int.Parse(Console.ReadLine()); // get the id
                    //n3.Id = _id1; // put the id in the task
                    Console.WriteLine("put a alias:");// ask for the name
                    _alias = Console.ReadLine(); // get the name

                    Console.WriteLine("put a description:");// ask for the description
                    _description = Console.ReadLine(); // get the description

                    _createDate = DateTime.Now; // get the create date

                    Console.WriteLine("put a required hours:");// ask for the required hours
                    _requiredHours = TimeSpan.Parse(Console.ReadLine()); // get the required hours

                    Console.WriteLine("put a complexity of the task:");// ask for the complexity
                    _complexity = (EngineerExperience)int.Parse(Console.ReadLine()); // get the complexity

                    DateTime? _finishDate = _createDate + _requiredHours; // get the finish date
                                                                          // n3.FinishDate = _finishDate; // put the finish date in the task
                    Console.WriteLine("enter a deadline date:");// ask for the deadline date
                    DateTime? _deadlineDate = DateTime.Parse(Console.ReadLine()); // get the deadline date  

                    Console.WriteLine("enter a Enginee Id:");// ask for the Enginee Id
                    int _engineerId = int.Parse(Console.ReadLine()); // get the Enginee Id
                    //n3.EngineerId = _engineerId; // put the Enginee Id in the task
                    
                    _whatYouDid = " "; // get the what you did
                    string _remark = " "; // get the remark


                    DO.Task n3 = new DO.Task
                    (
                      Id: _id1,
                        Alias :_alias,
                        Description : _description,
                        CreatedAtDate : _createDate,
                        RequiredEffort : _requiredHours,
                        Copmlexity : _complexity,
                        StartDate : DateTime.Now,
                        ScheduledTime : _finishDate,
                        DeadLinetime : _deadlineDate,
                        ComplateTime : DateTime.Now,
                        Dekiverables : _whatYouDid,
                        Remarks : _remark,
                        EngineerId : _engineerId
                    );
                    Console.WriteLine( s_dal.itask.Create(n3));// send to creat
                   // Console.WriteLine("the id of the task:" + n3.Id); // ask for the Difficulty of the task
                    break;

                case 2:// Read 
                    Console.WriteLine("put a id for read:");// get id for the task
                    _id1 = int.Parse(Console.ReadLine()); // get the id
                    s_dal!.itask.Read(_id1);// send to read
                    break;

                case 3: // ReadAll
                    s_dal!.itask.ReadAll();// send to readall
                    break;

                case 4: // Update
                    string vr = "";
                    Console.WriteLine("put a id to update:");// get id for the task
                    int _id3 = int.Parse(Console.ReadLine()); // get the id

                    DO.Task Help = s_dal!.itask.Read(_id3); // get the needed task
                    Console.WriteLine(Help); // print task values

                    Console.WriteLine("put a alias:");// ask for the name
                    _alias = Console.ReadLine(); // get the name
                    if (_alias == "")
                        _alias =Help.Alias;

                    Console.WriteLine("put a description:");// ask for the description
                    _description = Console.ReadLine(); // get the description
                    if (_description == "")
                        _description = Help.Description;

                    Console.WriteLine("put a create date:");// ask for the create date
                    vr = Console.ReadLine();
                    if(vr!="")
                       _createDate = DateTime.Parse(Console.ReadLine()); // get the create date
                    
                    Console.WriteLine("put a required hours:");// ask for the required hours
                    vr = Console.ReadLine();
                    if (vr != "")
                         _requiredHours = TimeSpan.Parse(Console.ReadLine()); // get the required hours

                    Console.WriteLine("put a complexity of the task:");// ask for the complexity
                    vr = Console.ReadLine();
                    if (vr != "")
                        _complexity = (EngineerExperience)int.Parse(Console.ReadLine()); // get the complexity

                    Console.WriteLine("enter a deadline date:");// ask for the deadline date
                    vr = Console.ReadLine();
                    if (vr != "")
                         _deadlineDate = DateTime.Parse(Console.ReadLine()); // get the deadline date
                                                                                  // Assuming you have a Random object initialized somewhere in your code.
                    Random random = new Random();

                    // Set the range in days

                   //int rangeInDays = (int)_complexity;  
                    // Generate random start date within the range
                   // DateTime? _startDate = DateTime.Now.AddDays(-random.Next(rangeInDays));

                    // Generate random finish date within the range
                  // DateTime? _actulyFinish = _startDate.Value.AddDays(random.Next(rangeInDays));
                    //
                    Console.WriteLine("enter what you did:");// ask for the what you did
                    vr = Console.ReadLine();
                    if (vr != "")
                        _whatYouDid = Console.ReadLine(); // get the what you did

                    Console.WriteLine("Do you have something to say?");// ask for the something to say
                    vr = Console.ReadLine();
                    if (vr != "")
                        _somethingToSay = Console.ReadLine();// get the something to say

                   // DO.Task tempEng = new(_id3, _alias, _description, _createDate, _requiredHours,
                 //    _isMilestone, _complexity, _deadlineDate, _whatYouDid, _somethingToSay,

                         // create a new engineer
                //    s_dal.iengineer.Update(help);
                  //  int Id,
   //string Alias,
   //string Description,
   //DateTime CreatedAtDate,
   //TimeSpan RequiredEffort,
   //bool IsMilestone,
   //EngineerExperience Copmlexity,
   //DateTime? StartDate,
   //DateTime? ScheduledTime,
   //DateTime? DeadLinetime,
   //DateTime? ComplateTime,
   //string? Dekiverables,
   //string? Remarks,
   //int EngineerId,
   //EngineerExperience Difficulty

                    break;
                case 5: // Delete 
                    Console.WriteLine("put a id for read:");// get id for the task
                    int _id2 = int.Parse(Console.ReadLine()); // get the id
                    s_dal!.itask.Delete(_id2);// send to Delete
                    break;

                default:
                    Console.WriteLine("there is no option like that");
                    break;
            }
        }
        catch (Exception e)// get if thier is exaption 
        {
            Console.WriteLine(e.Message);
        }
    }




    /// ///////////////////////////////////////////////////////////////////////
    static void Main(string[] args)
    
    
    
    
    {
        // Initialization.Do(s_dal);
        Console.WriteLine("We build a garage system"); // print the first line to the user
        Console.WriteLine("Welcome to our garage system"); // print the first line to the user
        Console.WriteLine("Hello, what we can do for you today?");
        Console.Write("Would you like to create Initial data? (Y/N)"); //stage 3
       string? ans = Console.ReadLine() ?? throw new FormatException("Wrong input"); //stage 3
        if (ans == "Y") //stage 3
            Initialization.Do(); //stage 4
           

        Console.WriteLine("choose a Item to check:0 for exit ,1 for Engineer, 2 for Task, 3 for Depandency");
        int a = int.Parse(Console.ReadLine());

        while (a != 0)// while he dont chooce 0 he will continue to run
        {
           // Console.WriteLine("Ok, let's start");
            try
            {

                switch (a)
                {
                    case 1:// Engineer class
                        EngineerRun();
                        break;
                    case 2:// Task class
                        TaskRun();
                        break;
                    case 3: // Depandency
                        DepandencyRun();
                        break;
                    default:
                        break;


                }
            }
            catch (Exception e)// get if thier is exaption 
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("choose a Item to check:0 for exit ,1 for Engineer, 2 for Task, 3 for Depandency");
            a = int.Parse(Console.ReadLine());

        }
    }
}
 

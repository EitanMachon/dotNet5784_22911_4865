// See https://aka.ms/new-console-template for more information
using BO;
using BlApi;

using DalTest;
using DalApi;
using DalXml;
using System;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace BlTest;
public class Program
{
    //static readonly IDal s_dal = Factory.Get; //stage 4
    //static readonly IDal s_dal = Factory.Get; //stage 4
    //static readonly IDal s_dal = Factory.Get; //stage 4
    //static readonly IDal s_dal = Factory.Get; //stage 4
    static readonly BlApi.IBl s_bl = BlApi.Factory.Get();

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
            double updateSalary = 0;
            BO.EngineerExperience level;
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
                    level = (BO.EngineerExperience)int.Parse(_givenLevelStr);
                    BO.Engineer n1 = new Engineer { Id = _id1, Name = _name, Email = _email, SalaryHour = _salary, Level = (BO.EngineerExperience)level };
                    s_bl.Engineer.Create(n1);// send to creat function of BL
                    break;

                case 2:// Read 
                    Console.WriteLine("put a id fr read:");// get id for the engineer
                    int _id2 = int.Parse(Console.ReadLine());
                    Console.WriteLine(s_bl.Engineer.Read(_id2)); // send to read
                    break;

                case 3: // ReadAll
                    Console.WriteLine("Read all");
                    Console.WriteLine(Tools.ToStringProperty(s_bl.Engineer.ReadAll()));// send to readall function
                    break;

                case 4: // Update
                    {
                        Console.WriteLine("Enter engineer id:");
                        int _id5 = int.Parse(Console.ReadLine());

                        BO.Engineer? Help = s_bl.Engineer.Read(_id5); // get the needed engineer
                        if (Help == null)
                            throw new BO.BlDoesNotExistException($"Engineer with ID={_id5} does not exists");

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
                            updateSalary = double.Parse(hel);
                        else      /// if the input empty, use the previous cost
                        {
                            updateSalary = Help.SalaryHour;
                        }

                        Console.WriteLine("Enter engineer level:");
                        hel = Console.ReadLine();
                        if (hel == "")
                        {
                            level = (BO.EngineerExperience)(int)Help.Level;
                        }
                        else
                        {
                            level = (BO.EngineerExperience)int.Parse(hel);
                        }

                        BO.Engineer tempEng = new BO.Engineer { Id = _id5, Name = _name, Email = _email, SalaryHour = updateSalary, Level = level }; // create a new engineer
                        s_bl.Engineer.Update(tempEng);
                    }
                    break;
                case 5: // Delete 
                    Console.WriteLine("put a id delete:");// get id for the engineer
                    int _id4 = int.Parse(Console.ReadLine());
                    s_bl.Engineer.Delete(_id4);
                    break;

                default:
                    Console.WriteLine("there is no option like that");
                    break;
            }
        }
        catch (Exception e)// get if thier is exaption 
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }

    public static void TaskRun()// the function run the depandency 
    {
        Console.WriteLine("choose a Item to check:0 for exit ,1 for Creat, 2 for Read, 3 for ReadAll, 4 for Update, 5 for Delete");
        int a = int.Parse(Console.ReadLine());
        int _id1;
        DateTime _createDate;
        string? _description = "";
        string? _alias = "";
        BO.EngineerExperience _complexity;
        TimeSpan _requiredHours;
        string _whatYouDid;
        string _somethingToSay = "";
        DateTime? _scheduledTime;
        try
        {
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

                    // Console.WriteLine("is a milestone? true/false:");// ask for the milestone
                    //_isMilestone = bool.Parse(Console.ReadLine()); // get the milestone

                    Console.WriteLine("put a complexity of the task:");// ask for the complexity
                    _complexity = (BO.EngineerExperience)int.Parse(Console.ReadLine()); // get the complexity

                    DateTime? _finishDate = _createDate + _requiredHours; // get the finish date
                                                                          // n3.FinishDate = _finishDate; // put the finish date in the task
                    Console.WriteLine("enter a deadline date:");// ask for the deadline date
                    DateTime? _deadlineDate = DateTime.Parse(Console.ReadLine()); // get the deadline date  

                    Console.WriteLine("enter a Enginee Id:");// ask for the Enginee Id
                    int _engineerId = int.Parse(Console.ReadLine()); // get the Enginee Id
                    //n3.EngineerId = _engineerId; // put the Enginee Id in the task
                    Console.WriteLine("enter a Difficulty:");// ask for the Difficulty of the task
                    int _difficulty = int.Parse(Console.ReadLine()); // get the Difficulty of the task
                    //n3.Difficulty = _difficulty; // put the Difficulty of the task in the task
                    _whatYouDid = " "; // get the what you did
                    string? _remark = " "; // get the remark

                    BO.Task n3 = new BO.Task
                    {
                        Id = _id1,
                        Alias = _alias,
                        Description = _description,
                        CreatedAtDate = _createDate,
                        RequiredEffort = _requiredHours,
                        Copmlexity = _complexity,
                        StartDate = DateTime.Now,
                        ScheduledTime = _finishDate,
                        DeadLinetime = _deadlineDate,
                        ComplateTime = DateTime.Now,
                        Dekiverables = _whatYouDid,
                        Remarks = _remark,
                        EngineerId = _engineerId,
                    };
                    Console.WriteLine(s_bl.Task.Create(n3));
                    break;

                case 2:// Read 
                    Console.WriteLine("put a id for read:");// get id for the task
                    _id1 = int.Parse(Console.ReadLine()); // get the id
                    Console.WriteLine(s_bl!.Task.Read(_id1));// send to read
                    break;

                case 3: // ReadAll
                    //s_bl!.Task.ReadAll();// send to readall
                    foreach (var t in s_bl!.Task.ReadAll())
                    {
                        Console.WriteLine(t);
                    }
                    break;

                case 4: // Update
                    string vr = "";
                    Console.WriteLine("put a id to update:");// get id for the task
                    int _id3 = int.Parse(Console.ReadLine()); // get the id

                    BO.Task? Help = s_bl!.Task.Read(_id3); // get the needed task

                    if (Help == null)
                        throw new BlDoesNotExistException($"Task with ID={_id3} does not exists");

                    Console.WriteLine(Help); // print task values

                    Console.WriteLine("put a alias:");// ask for the name
                    _alias = Console.ReadLine(); // get the name
                    if (_alias == "")
                        _alias = Help.Alias;

                    Console.WriteLine("put a description:");// ask for the description
                    _description = Console.ReadLine(); // get the description
                    if (_description == "")
                        _description = Help.Description;

                    Console.WriteLine("put a required hours:");// ask for the required hours
                    vr = Console.ReadLine();
                    if (vr != "")
                        _requiredHours = TimeSpan.Parse(vr);
                    else { _requiredHours = Help.RequiredEffort; } // if vr==""
                                                                   //_requiredHours = TimeSpan.Parse(Console.ReadLine()); // get the required hours

                    Console.WriteLine("put a complexity of the task:");// ask for the complexity
                    vr = Console.ReadLine();
                    if (vr != "")
                        _complexity = (BO.EngineerExperience)int.Parse(vr); // get the complexity
                    else { _complexity = Help.Copmlexity; }

                    Console.WriteLine("enter a deadline date:");// ask for the deadline date
                    vr = Console.ReadLine();
                    if (vr != "")
                        _deadlineDate = DateTime.Parse(vr); // get the deadline date
                    else { _deadlineDate = Help.DeadLinetime; } // Assuming you have a Random object initialized somewhere in your code.


                    Console.WriteLine("enter a ScheduledTime date:");// ask for the deadline date
                    vr = Console.ReadLine();
                    if (vr != "")
                        _scheduledTime = DateTime.Parse(vr); // get the deadline date
                    else { _scheduledTime = Help.ScheduledTime; } // Assuming you have a Random object initialized somewhere in your code.

                    Console.WriteLine("enter what you did:");// ask for the what you did
                    vr = Console.ReadLine();
                    if (vr != "")
                        _whatYouDid = vr; // get the what you did
                    else { _whatYouDid = Help.Dekiverables; }

                    Console.WriteLine("Do you have something to add?");// ask for the something to say
                    vr = Console.ReadLine();
                    if (vr != "")
                        _somethingToSay = vr;// get the something to say
                    else { _somethingToSay = Help.Remarks; }

                    Console.WriteLine("new Enginee id:");// ask for the something to say
                    vr = Console.ReadLine();
                    int id = 0;
                    if (vr != "")
                        _engineerId = int.Parse(vr); // get the id
                    else { _engineerId = Help.EngineerId; }

                    BO.Task nt = new BO.Task
                    {
                        Id = _id3,
                        Alias = _alias,
                        Description = _description,
                        CreatedAtDate = DateTime.Now,
                        RequiredEffort = _requiredHours,
                        Copmlexity = _complexity,
                        StartDate = DateTime.Now,
                        ScheduledTime = null,
                        DeadLinetime = _deadlineDate,
                        ComplateTime = DateTime.Now,
                        Dekiverables = _whatYouDid,
                        Remarks = _somethingToSay,
                        EngineerId = _engineerId,
                    };
                    //  BO.Task tempEng = new(_id3, _alias, _description, DateTime.Now, DateTime.Now,false, _complexity,); // create a new engineer
                    s_bl.Task.Update(nt);

                    //_id1;
                    //Alias = _alias;
                    //Description = _description;
                    //CreatedAtDate = _createdDate;
                    //RequiredEffort = _requiredHours;
                    //IsMilestone = _isMilestone;
                    //Copmlexity = _complexity;
                    //StartDate = DateTime.Now;
                    //ScheduledTime = _finishDate;
                    //DeadLinetime = _deadlineDate;
                    //ComplateTime = DateTime.Now;
                    //Dekiverables = _whatYouDid;
                    //Remarks = _remark;
                    //EngineerId = _engineerId;
                    //Difficulty = (EngineerExperience)_difficulty;
                    break;

                case 5: // Delete 
                    Console.WriteLine("put a id for read:");// get id for the task
                    int _id2 = int.Parse(Console.ReadLine()); // get the id
                    s_bl!.Task.Delete(_id2);// send to Delete
                    break;

                default:
                    Console.WriteLine("there is no option like that");
                    break;
            }
        }
        catch (Exception e)// get if thier is exaption 
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }

    //////////////////////////////////////////////////////////////////////////
    static void Main(string[] args)
    {
        // Initialization.Do(s_dal);
        Console.WriteLine("We build a garage system"); // print the first line to the user
        Console.WriteLine("Welcome to our garage system"); // print the first line to the user
        Console.WriteLine("Hello, what we can do for you today?");
        Console.Write("Would you like to create Initial data? (Y/N)"); //stage 3
        string? ans = Console.ReadLine() ?? throw new FormatException("Wrong input"); //stage 3
        if (ans == "Y" || ans == "y") //stage 3
            Initialization.Do(); //stage 4

        Console.WriteLine("choose a Item to check:0 for exit ,1 for Engineer, 2 for Task");
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
                    default:
                        break;
                }
            }
            catch (Exception e)// get if thier is exaption 
            {
                Console.WriteLine(e.Message);
            }

            // read the next choise
            Console.WriteLine("choose a Item to check:0 for exit ,1 for Engineer, 2 for Task, 3 for Depandency");
            a = int.Parse(Console.ReadLine());
        }

        // save the schedule to the file
        Console.WriteLine("save the schedule to the file...");
        s_bl.Schedule.SaveSchedule();
    }
}


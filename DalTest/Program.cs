// See https://aka.ms/new-console-template for more information
using Dal;
using DalApi;
using DalTest;
using DO;
using System;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Xml.Linq;

class Program
{
    //stage 1
    //private static IDependency? s_dalDependency = new DependencyImplementation(); //stage 1
    //private static IEngineer? s_dalEngineer = new EngineerImplementation(); //stage 1 
    //private static ITask? s_dalTasks = new TaskImplementaion();//stage 1`   
    static readonly IDal s_dal = new DalList(); //stage 2

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
            switch (a)
            {

                case 1://Creat 
                    Dependency n1 = new Dependency();
                    s_dal.Create(n1);// send to creat
                    break;

                case 2:// Read 
                    Console.WriteLine("put a id for read:");// get id for the depandency
                    int _id1 = int.Parse(Console.ReadLine());
                    s_dal.Read(_id1);// send to creat
                    break;

                case 3: // ReadAll
                    s_dal.ReadAll();// send to readall
                    break;

                case 4: // Update
                    Console.WriteLine("put a id to update:");// get id for the depandency
                    int _id3 = int.Parse(Console.ReadLine()); // get the id

                    DO.Dependency Help = s_dal.Read(_id3); // get the needed depandency
                    Console.WriteLine(Help); // print depandency values

                    Console.WriteLine("put a depandendent task:");// get id for the depandency
                    int _dt = int.Parse(Console.ReadLine()); // get the depandendent task

                    Console.WriteLine("put a depans task:"); // get id for the depandency
                    int _dep = int.Parse(Console.ReadLine()); // get the depans task

                    Dependency tempDep = new(_id3, _dt, _dep); // create a new depandency
                    s_dal.Update(tempDep); // update the depandency
                    break;

                case 5: // Delete 
                    Console.WriteLine("put a id for read:");// get id for the depandency
                    int _id2 = int.Parse(Console.ReadLine());
                    s_dal.Delete(_id2);// send to Delete
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
        Initialization.Do(s_dal);
        Console.WriteLine("We build a garage system, let's start!"); // print the first line to the user
        Console.WriteLine("Welcome to our garage system"); // print the first line to the user
        Console.WriteLine("Hello, what we can do for you today?");
        Console.WriteLine("choose a Item to check:0 for exit ,1 for Engineer, 2 for Task, 3 for Depandency");
        int a = int.Parse(Console.ReadLine());

        while (a != 0)// while he dont chooce 0 he will continue to run
        {
            Console.WriteLine("Ok, let's start");
            try
            {

                switch (a)
                {
                    //case 1:// Engineer class
                    //    EngineerRun();
                    //    break;
                    //case 2:// Task class
                    //    TaskRun();
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

            Console.WriteLine("choose a Item to check:");
            a = int.Parse(Console.ReadLine());
        }
    }
}
    /// <summary>
    ///  the functions that run evey class:
    /// </summary>
    //    public static void EngineerRun()// the function run the engineer 
    //    {

    //        Console.WriteLine(@"put an action: 
    //1 for Creat
    //2 for Read
    //3 for ReadAll
    //4 for Update
    //5 for Delete "); // print the options to the user

    //        int _a = int.Parse(Console.ReadLine());
    //        try
    //        {
    //            switch (_a)
    //            {
    //                case 1://Creat
    //                    Console.WriteLine("put a new id:");// get id for the engineer
    //                    int _id1 = int.Parse(Console.ReadLine());
    //                    Engineer n1 = new Engineer(_id1);
    //                    s_dalEngineer.Create(n1);// send to creat
    //                    break;
    //                case 2:// Read 
    //                    Console.WriteLine("put a id fr read:");// get id for the engineer
    //                    int _id2 = int.Parse(Console.ReadLine());
    //                    s_dalEngineer.Read(_id2);// send to read
    //                    break;
    //                case 3: // ReadAll
    //                    s_dalEngineer.ReadAll();// send to readall function
    //                    break;
    //                case 4: // Update
    //                    {
    //                        Console.WriteLine("Enter engineer id:");
    //                        int _id5 = int.Parse(Console.ReadLine());

    //                        DO.Engineer Help = s_dalEngineer.Read(_id5); // get the needed engineer
    //                        Console.WriteLine(Help); // print engineer values


    //                        Console.WriteLine("Enter engineer name:");
    //                        string _name = Console.ReadLine();
    //                        if (_name == "")      /// if the input "", use the previous name
    //                            _name = Help.Name;

    //                        Console.WriteLine("Enter engineer email:");
    //                        string _email = Console.ReadLine();
    //                        if (_email == "")      /// if the input empty, use the previous email
    //                            _email = Help.Email;

    //                        Console.WriteLine("Enter engineer salary:");
    //                        double updateSalary = double.Parse(Console.ReadLine());
    //                        if (updateSalary == null)      /// if the input empty, use the previous cost
    //                        {
    //                            updateSalary = Help.SalaryHour;

    //                        }


    //                        Console.WriteLine("Enter engineer level:");
    //                        string _givenLevelStr = Console.ReadLine();
    //                        int level;
    //                        if(_givenLevelStr=="")
    //                        {
    //                            level = (int)Help.Level;
    //                        }
    //                        else
    //                        {
    //                            level = int.Parse(_givenLevelStr);
    //                        }

    //                        Engineer tempEng = new(_id5, _name, _email, updateSalary, (EngineerExperience)level); // create a new engineer
    //                         s_dalEngineer.Update(tempEng);
    //                    }
    //                    break;
    //                case 5: // Delete 
    //                    Console.WriteLine("put a id delete:");// get id for the engineer
    //                    int _id4 = int.Parse(Console.ReadLine());
    //                    s_dalEngineer.Delete(_id4);
    //                    break;

    //                default:
    //                    Console.WriteLine("there is no option like that");
    //                    break;
    //            }
    //        }
    //        catch (Exception e)// get if thier is exaption 
    //        {
    //            Console.WriteLine(e.Message);
    //        }
    //    }
    //    public static void DepandencyRun()// the function run the task 
    //    {
    //        Console.WriteLine("choose a Item to check:0 for exit ,1 for Creat, 2 for Read, 3 for ReadAll, 4 for Update, 5 for Delete");
    //        int a = int.Parse(Console.ReadLine());
    //        try
    //        {
    //            switch (a)
    //            {
    //                case 1://Creat 
    //                    Dependency n1 = new Dependency();
    //                    s_dalDependency.Create(n1);// send to creat
    //                    break;
    //                case 2:// Read 
    //                    Console.WriteLine("put a id for read:");// get id for the depandency
    //                    int _id1 = int.Parse(Console.ReadLine());
    //                    s_dalDependency.Read(_id1);// send to creat
    //                    break;
    //                case 3: // ReadAll
    //                    s_dalDependency.ReadAll();// send to readall

    //                    break;

    //                case 4: // Update
    //                    Console.WriteLine("put a id to update:");// get id for the depandency
    //                    int _id3 = int.Parse(Console.ReadLine()); // get the id

    //                    DO.Dependency Help = s_dalDependency.Read(_id3); // get the needed depandency
    //                    Console.WriteLine(Help); // print depandency values

    //                    Console.WriteLine("put a depandendent task:");// get id for the depandency
    //                    int _dt = int.Parse(Console.ReadLine()); // get the depandendent task

    //                    Console.WriteLine("put a depans task:"); // get id for the depandency
    //                    int _dep = int.Parse(Console.ReadLine()); // get the depans task

    //                    Dependency tempDep = new(_id3, _dt, _dep); // create a new depandency
    //                    s_dalDependency.Update(tempDep); // update the depandency
    //                    break;

    //                case 5: // Delete 
    //                    Console.WriteLine("put a id for read:");// get id for the depandency
    //                    int _id2 = int.Parse(Console.ReadLine());
    //                    s_dalDependency.Delete(_id2);// send to Delete
    //                    break;

    //                default:
    //                    Console.WriteLine("there is no option like that");
    //                    break;
    //            }
    //        }
    //        catch (Exception e)// get if thier is exaption 
    //        {
    //            Console.WriteLine(e.Message);
    //        }
    //    }

    //    public static void TaskRun()// the function run the depandency 
    //    {
    //        Console.WriteLine("choose a Item to check:0 for exit ,1 for Creat, 2 for Read, 3 for ReadAll, 4 for Update, 5 for Delete");
    //        int a = int.Parse(Console.ReadLine());
    //        try
    //        {
    //            switch (a)
    //            {
    //                case 1://Creat 
    //                    DO.Task n3 = new DO.Task();
    //                    s_dalTasks.Create(n3);// send to create 
    //                    break;
    //                case 2:// Read 
    //                 Console.WriteLine("put a id for read:");// get id for the task
    //                 int _id1 = int.Parse(Console.ReadLine()); // get the id
    //                 s_dalTasks.Read(_id1);// send to read
    //                 break;

    //                case 3: // ReadAll
    //                    s_dalTasks.ReadAll();// send to readall
    //                    break;

    //                case 4: // Update
    //                Console.WriteLine("put a id to update:");// get id for the task
    //                int _id3 = int.Parse(Console.ReadLine()); // get the id

    //                DO.Task Help = s_dalTasks.Read(_id3); // get the needed task
    //                Console.WriteLine(Help); // print task values

    //                Console.WriteLine("put a alias:");// ask for the name
    //                string _alias = Console.ReadLine(); // get the name

    //                Console.WriteLine("put a description:");// ask for the description
    //                string _description = Console.ReadLine(); // get the description

    //                Console.WriteLine("put a create date:");// ask for the create date
    //                DateTime _createDate = DateTime.Parse(Console.ReadLine()); // get the create date

    //                Console.WriteLine("put a required hours:");// ask for the required hours
    //                TimeSpan _requiredHours = TimeSpan.Parse(Console.ReadLine()); // get the required hours

    //                Console.WriteLine("is a milestone? true/false:");// ask for the milestone
    //                bool _isMilestone = bool.Parse(Console.ReadLine()); // get the milestone

    //                Console.WriteLine("put a complexity of the task:");// ask for the complexity
    //                EngineerExperience _complexity = (EngineerExperience)int.Parse(Console.ReadLine()); // get the complexity





    //                Console.WriteLine("enter a finish date:");// ask for the finish date
    //                DateTime? _finishDate = DateTime.Parse(Console.ReadLine()); // get the finish date

    //                Console.WriteLine("enter a deadline date:");// ask for the deadline date
    //            DateTime? _deadlineDate = DateTime.Parse(Console.ReadLine()); // get the deadline date
    //                                                                          // Assuming you have a Random object initialized somewhere in your code.
    //                Random random = new Random();

    //                // Set the range in days
    //                int rangeInDays = (int)_complexity;  // For example, a range of 30 days

    //                // Generate random start date within the range
    //                DateTime? _startDate = DateTime.Now.AddDays(-random.Next(rangeInDays));

    //                // Generate random finish date within the range
    //                DateTime? _actulyFinish = _startDate.Value.AddDays(random.Next(rangeInDays));
    //                //
    //                Console.WriteLine("enter what you did:");// ask for the what you did
    //            string _whatYouDid = Console.ReadLine(); // get the what you did

    //            Console.WriteLine("Do you have something to say?");// ask for the something to say
    //            string _somethingToSay = Console.ReadLine(); // get the something to say


    //            break;
    //            case 5: // Delete 
    //                Console.WriteLine("put a id for read:");// get id for the task
    //                int _id2 = int.Parse(Console.ReadLine()); // get the id
    //                s_dalTasks.Delete(_id2);// send to Delete
    //                break;

    //            default:
    //                Console.WriteLine("there is no option like that");
    //                break;
    //        }
    //    }
    //    catch (Exception e)// get if thier is exaption 
    //    {
    //        Console.WriteLine(e.Message);
    //    }
    //}





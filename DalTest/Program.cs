// See https://aka.ms/new-console-template for more information
using Dal;
using DalApi;
using DalTest;
using DO;
using System;
using System.Reflection.Emit;
using System.Xml.Linq;

class Program
{
    //stage 1
    private static IDependency? s_dalDependency = new DependencyImplementation(); //stage 1
    private static IEngineer? s_dalEngineer = new EngineerImplementation(); //stage 1
    private static ITask? s_dalTasks = new TaskImplementation(); //stage 1


    /// <summary>
    ///  the functions that run evey class:
    /// </summary>
    public static void EngineerRun()// the function run the engineer 
    {

        Console.WriteLine("choose a Item to check:0 for exit ,1 for Creat, 2 for Read, 3 for ReadAll, 4 for Update, 5 for Delete");
        int a = int.Parse(Console.ReadLine());
        try
        {
            switch (a)
            {
                case 1://Creat
                        Console.WriteLine("put a new id:");// get id for the engineer
                        int _id1 = int.Parse(Console.ReadLine());
                        Engineer n1 = new Engineer(_id1);
                        s_dalEngineer.Create(n1);// send to creat
                        break;
                case 2:// Read 
                    Console.WriteLine("put a id fr read:");// get id for the engineer
                    int _id2 = int.Parse(Console.ReadLine());
                    s_dalEngineer.Read(_id2);// send to read
                    break;
                case 3: // ReadAll
                    s_dalEngineer.ReadAll();// send to readall function
                    break;
                case 4: // Update
                    {
                        Console.WriteLine("Enter engineer id:");
                        int _id5 = int.Parse(Console.ReadLine());

                        DO.Engineer help = s_dalEngineer.Read(_id5); // get the needed engineer
                        Console.WriteLine(help); // print engineer values


                        Console.WriteLine("Enter engineer name:");
                        name = Console.ReadLine();
                        if (name == "")      /// if the input "", use the previous name
                            name = help.Name;

                        Console.WriteLine("Enter engineer email:");
                        email = Console.ReadLine();
                        if (email == "")      /// if the input empty, use the previous email
                            email = help.Email;

                        Console.WriteLine("Enter engineer cost:");
                        string costStr = Console.ReadLine();
                        if (costStr == "")      /// if the input empty, use the previous cost
                            cost = help.Cost;
                        else cost = double.Parse(costStr);

                        Console.WriteLine("Enter engineer level:");
                        string levelStr = Console.ReadLine();
                        if (levelStr == "")      /// if the input empty, use the previous level
                            level = (int)help.Level;
                        else level = int.Parse((levelStr));

                        Engineer tempEng = new(id, name, email, cost, (EngineerExperience)level);
                        s_dalEngineer.Update(tempEng);
                    }
                    break;
                case 5: // Delete 
                    Console.WriteLine("put a id delete:");// get id for the engineer
                    int _id4 = int.Parse(Console.ReadLine());
                    s_dalEngineer.Delete(_id4);
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
        public static void TaskRun()// the function run the task 
        {
        Console.WriteLine("choose a Item to check:0 for exit ,1 for Creat, 2 for Read, 3 for ReadAll, 4 for Update, 5 for Delete");
        int a = int.Parse(Console.ReadLine());
        try
        {
            switch (a)
            {
                case 1://Creat 
                    Dependency n1 = new Dependency();
                    s_dalDependency.Create(n1);// send to creat
                break;
                case 2:// Read 
                    Console.WriteLine("put a id for read:");// get id for the depandency
                    int _id1 = int.Parse(Console.ReadLine());
                    s_dalDependency.Read(_id1);// send to creat
                    break;
                case 3: // ReadAll
                    s_dalDependency.ReadAll();// send to readall

                    break;
                case 4: // Update

                    break;
                case 5: // Delete 
                    Console.WriteLine("put a id for read:");// get id for the depandency
                    int _id2 = int.Parse(Console.ReadLine());
                    s_dalDependency.Delete(_id2);// send to Delete
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

    public static void DepandencyRun()// the function run the depandency 
        {
        Console.WriteLine("choose a Item to check:0 for exit ,1 for Creat, 2 for Read, 3 for ReadAll, 4 for Update, 5 for Delete");
        int a = int.Parse(Console.ReadLine());
        try
        {
            switch (a)
            {
                case 1://Creat 

                break ;
                case 2:// Read 

                    break;
                    case 3: // ReadAll

                    break;
                case 4: // Update

                    break;
                case 5: // Delete 

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

        Initialization.Do(s_dalStudent, s_dalCourse, s_dalLinks);

        Console.WriteLine("choose a Item to check:0 for exit ,1 for Engineer, 2 for Task, 3 for Depandency");
        int a = int.Parse(Console.ReadLine());

        while (Console.ReadLine() != "0")// while he dont chooce 0 he will continue to run
        {
            Console.WriteLine("put an action: 1 for Creat, 2 for Read, 3 for ReadAll, 4 for Update, 5 for Delete ");
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

            Console.WriteLine("choose a Item to check:");
            a = int.Parse(Console.ReadLine());
        }
    }
    

}












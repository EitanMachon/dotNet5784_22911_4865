// See https://aka.ms/new-console-template for more information
using DalTest;

Console.WriteLine("Hello, World!");
class Program;
static void Main(string[] args)

{
    private static IDepende? s_dalStudent = new StudentImplementation(); //stage 1
    private static ICourse? s_dalCourse = new CourseImlementation(); //stage 1
    private static ILink? s_dalLinks = new LinkImplementation();
    Initialization.Do(s_dalStudent, s_dalCourse, s_dalLinks);
Console.WriteLine("choose a action");
int a=0;
Console.ReadLine(a);

while (a!=0) 
{
    try
    {
        Console.WriteLine();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

    Console.WriteLine("choose a action");
    Console.ReadLine(a);
}
}
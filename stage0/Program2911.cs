partial class Program
{
    private static void Main(string[] args)
    {
        Welcome2911();
        Welcome4865();
        Console.ReadKey();
    }

    static partial void Welcome4865();
   
    private static void Welcome2911()
    {
        Console.WriteLine("Enter your name: ");
        string username = Console.ReadLine();
        Console.WriteLine("{0}, welcome to my first cnsole application", username);
    }
}
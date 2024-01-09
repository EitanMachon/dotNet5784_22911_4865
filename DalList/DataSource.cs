namespace Dal;
internal static class DataSource
{
   
    internal static List<DO.Engineer> engineers { get; } = new();
    internal static List<DO.Task> Tasks { get; } = new();
    internal static List<DO.Depandency> Depandencys { get; } = new();

    internal static class Config 
    {
        internal const int startId = 1;
        private static int nextId = startId;
        internal static int NextId { get => nextId++; }
    }


    }


namespace Dal;
internal static class DataSource
{
   
    internal static List<Do.engineer> engineers { get; } = new();
    internal static List<Do.Task> Tasks { get; } = new();
    internal static List<Do.Depandency> Depandencys { get; } = new();

    nternal static class Config
    {
        internal const int startId = 0;
        private static int nextId = startId;
        internal static int NextId { get => nextId++; }
        
    }

}



using DO;

namespace Dal
{
    public static class DataSource
    {
        internal static List<DO.Engineer> Engineers { get; } = new();
        internal static List<DO.Task> Tasks { get; } = new();
        internal static List<DO.Dependency> Dependencies { get; } = new();


        public static class Config
        {
            internal const int startId = 1;
            private static int nextId = startId;
            public static int NextId { get => nextId++; }
        }
    }
}

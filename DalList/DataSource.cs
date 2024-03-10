
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
            internal const int startTaskId = 1;
            private static int nextTaskId = startTaskId;
            public static int GetNextTaskId() => nextTaskId;

            internal const int startDependencyId = 1;
            private static int nextDependencyId = startDependencyId;
            public static int GetNextDependency() => nextDependencyId;



            internal static DateTime? ProjectEndDate { get; set; }
            internal static DateTime? ProjectStartDate { get; set; }
            internal static DateTime? NowDate { get; set; }
        }
    }
}

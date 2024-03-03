using BLApi;

namespace BlApi
{
    /// <summary>
    /// this static class is used to create the BlApi layer that is used to implement the BL layer functions of the task
    /// </summary>  
    public interface IBl
    {
        /// <summary>
        /// this is the interface of the BL layer that is used to implement the BL layer  functions of the task
        /// </summary>
        public ITask Task { get; }  // this is the interface of the BL layer that is used to implement the BL layer  functions of the Task
        /// <summary>
        /// this is the interface of the BL layer that is used to implement the BL layer  functions of the engineer
        /// </summary>
        public IEngineer Engineer { get; } // this is the interface of the BL layer that is used to implement the BL layer  functions of the Engineer

        // public BO.IDependency dependency { get; }

        public ISchedule Schedule { get; } // this is the interface of the BL layer that is used to implement the BL layer  functions of the Schedule
        
        public DateTime Clock { get; } // this is the interface of the BL layer that is used to implement the BL layer  functions of the clock

        public DateTime AddYear(DateTime date, int year)
        {
            var temp = date;
            date = temp.AddYears(year);
            return date;
        }

        public DateTime AddMonth(DateTime date, int month)
        {
            var temp = date;
            date = temp.AddMonths(month);
            return date;
        }

        public DateTime AddDay(DateTime date, int day)
        {
            var temp = date;
            date = temp.AddDays(day);
            return date;
        }

        public DateTime AddHour(DateTime date, int hour)
        {
            var temp = date;
            date = temp.AddHours(hour);
            return date;
        }
    }

}

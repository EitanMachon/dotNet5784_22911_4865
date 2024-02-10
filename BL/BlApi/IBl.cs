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
    }

}

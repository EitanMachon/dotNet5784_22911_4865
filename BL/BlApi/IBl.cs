using BLApi;

namespace BlApi
{
    public interface IBl
    {
        public ITask Task { get; }  // this is the interface of the BL layer that is used to implement the BL layer  functions of the Task
        public IEngineer Engineer { get; } // this is the interface of the BL layer that is used to implement the BL layer  functions of the Engineer

        // public BO.IDependency dependency { get; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLApi
{
    /// <summary>
    ///  this is the interface of the BL layer that is used to implement the BL layer  functions of the Task
    /// </summary>
    public interface ITask
    {
        public int Create(BO.Task task); // this function get a task and create it in the database

        public BO.Task? Read(int id); // this function get an id and return the task that match the id

        public IEnumerable<BO.Task?> ReadAll(Func<BO.Task, bool>? filter = null); // this function return all the tasks in the database

        public void Update(BO.Task task); // this function get a task and update it in the database

        public void Delete(int id); // this function get a task and delete it from the database 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    /// <summary>
    ///  this is the interface of the BL layer that is used to implement the BL layer  functions of the Task
    /// </summary>
    public interface ITask
    {
        /// <summary>
        /// this function create a task in the DAL layer and return the id of the task that was created
        /// </summary>
        public int Create(BO.Task task); // this function get a task and create it in the database
        /// <summary>
        /// this function get an id and return the task that match the id
        public BO.Task? Read(int id); // this function get an id and return the task that match the id
        /// <summary>
        /// this function return all the tasks in the database
        /// </summary>
        public IEnumerable<BO.Task?> ReadAll(Func<BO.Task, bool>? filter = null); // this function return all the tasks in the database
        /// <summary>
        /// this function get a task and update it in the database
        /// </summary>
        public void Update(BO.Task task); // this function get a task and update it in the database
        /// <summary>
        ///  this function get a task and delete it from the database
        /// </summary>
        public void Delete(int id); // this function get a task and delete it from the database 
    }
}

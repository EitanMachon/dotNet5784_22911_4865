using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
/// <summary>
///  this clases are for exceptions in the BL layer and the BL implementation layer 
/// </summary>
public class BlInvalidId : Exception // in case of invalid id
{
    public BlInvalidId()
    {
    }

    public BlInvalidId(string? message) : base(message)
    {
    }

    public BlInvalidId(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
public class BlStationExists : Exception // in case of station already exists
{
    public BlStationExists()
    {
    }

    public BlStationExists(string? message) : base(message)
    {
    }

    public BlStationExists(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
public class BlInvalidAlias : Exception // in case of invalid alias
{
    public BlInvalidAlias()
    {
    }

    public BlInvalidAlias(string? message) : base(message)
    {
    }

    public BlInvalidAlias(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
public class BLTaskHasNoEngineerException : Exception // in case of task without engineer
{
    public BLTaskHasNoEngineerException() 
    {
    }

    public BLTaskHasNoEngineerException(string? message) : base(message)
    {
    }

    public BLTaskHasNoEngineerException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
public class BlDoesNotExistException : Exception // in case of object does not exist
{
    public BlDoesNotExistException()
    {
    }

    public BlDoesNotExistException(string? message) : base(message)
    {
    }

    public BlDoesNotExistException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
public class BLTaskHasDependencyException : Exception // in case of task has dependency
{
    public BLTaskHasDependencyException()
    {
    }

    public BLTaskHasDependencyException(string? message) : base(message)
    {
    }

    public BLTaskHasDependencyException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
public class BLDependentTaskDoesntExist : Exception // in case of dependent task does not exist
{
    public BLDependentTaskDoesntExist()
    {
    }

    public BLDependentTaskDoesntExist(string? message) : base(message)
    {
    }

    public BLDependentTaskDoesntExist(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
public class BlEngineerAlreadyExists : Exception // in case of engineer already exists
{
    public BlEngineerAlreadyExists()
    {
    }

    public BlEngineerAlreadyExists(string? message) : base(message)
    {
    }

    public BlEngineerAlreadyExists(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
public class BlInvalidName : Exception // in case of invalid name
{
    public BlInvalidName()
    {
    }

    public BlInvalidName(string? message) : base(message)
    {
    }

    public BlInvalidName(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
public class BlInvalidEmail : Exception // in case of invalid email
{
    public BlInvalidEmail()
    {
    }

    public BlInvalidEmail(string? message) : base(message)
    {
    }

    public BlInvalidEmail(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
public class BlEngineerHasTask : Exception // in case of engineer has task
{
    public BlEngineerHasTask()
    {
    }

    public BlEngineerHasTask(string? message) : base(message)
    {
    }

    public BlEngineerHasTask(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
public class BlEngineerNotQualifiedForTask : Exception // in case of engineer not qualified for task
    {
        public BlEngineerNotQualifiedForTask()
        {
        }

        public BlEngineerNotQualifiedForTask(string? message) : base(message)
        {
        }

        public BlEngineerNotQualifiedForTask(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BlEngineerNotQualifiedForTask(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

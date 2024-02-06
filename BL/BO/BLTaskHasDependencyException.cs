using System.Runtime.Serialization;

namespace BO
{
    [Serializable]
    internal class BLTaskHasDependencyException : Exception
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

        protected BLTaskHasDependencyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
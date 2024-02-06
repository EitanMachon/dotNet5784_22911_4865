using System.Runtime.Serialization;

namespace BO
{
    [Serializable]
    internal class BlDoesNotExistException : Exception
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

        protected BlDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
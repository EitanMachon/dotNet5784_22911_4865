using System.Runtime.Serialization;

namespace DO
{
    [Serializable]
    internal class DalCreateException : Exception
    {
        public DalCreateException()
        {
        }

        public DalCreateException(string? message) : base(message)
        {
        }

        public DalCreateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DalCreateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
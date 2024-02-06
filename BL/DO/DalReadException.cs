using System.Runtime.Serialization;

namespace DO
{
    [Serializable]
    internal class DalReadException : Exception
    {
        public DalReadException()
        {
        }

        public DalReadException(string? message) : base(message)
        {
        }

        public DalReadException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DalReadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
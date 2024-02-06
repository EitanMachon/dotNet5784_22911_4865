using System.Runtime.Serialization;

namespace DO
{
    [Serializable]
    internal class DalDeleteException : Exception
    {
        public DalDeleteException()
        {
        }

        public DalDeleteException(string? message) : base(message)
        {
        }

        public DalDeleteException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DalDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
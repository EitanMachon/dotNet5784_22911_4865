using System.Runtime.Serialization;

namespace DO
{
    [Serializable]
    internal class BadDependancyIdException : Exception
    {
        public BadDependancyIdException()
        {
        }

        public BadDependancyIdException(string? message) : base(message)
        {
        }

        public BadDependancyIdException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BadDependancyIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
using System.Runtime.Serialization;
/// <summary>
/// this class represents an exception that is thrown when trying to create a new object in the data source
/// </summary>
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
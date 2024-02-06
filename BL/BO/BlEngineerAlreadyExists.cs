using System.Runtime.Serialization;

namespace BO
{
    [Serializable]
    internal class BlEngineerAlreadyExists : Exception
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

        protected BlEngineerAlreadyExists(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
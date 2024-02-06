using System.Runtime.Serialization;

namespace BO
{
    [Serializable]
    internal class BlInvalidName : Exception
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

        protected BlInvalidName(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
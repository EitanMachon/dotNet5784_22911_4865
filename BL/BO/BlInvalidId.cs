using System.Runtime.Serialization;

namespace BO
{
    [Serializable]
    internal class BlInvalidId : Exception
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

        protected BlInvalidId(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
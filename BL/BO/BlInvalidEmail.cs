using System.Runtime.Serialization;

namespace BO
{
    [Serializable]
    internal class BlInvalidEmail : Exception
    {
        public BlInvalidEmail()
        {
        }

        public BlInvalidEmail(string? message) : base(message)
        {
        }

        public BlInvalidEmail(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BlInvalidEmail(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
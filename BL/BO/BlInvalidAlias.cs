using System.Runtime.Serialization;

namespace BO
{
    [Serializable]
    internal class BlInvalidAlias : Exception
    {
        public BlInvalidAlias()
        {
        }

        public BlInvalidAlias(string? message) : base(message)
        {
        }

        public BlInvalidAlias(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BlInvalidAlias(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
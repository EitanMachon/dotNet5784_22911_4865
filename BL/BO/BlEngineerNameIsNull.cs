using System.Runtime.Serialization;

namespace BO
{
    [Serializable]
    internal class BlEngineerNameIsNull : Exception
    {
        public BlEngineerNameIsNull()
        {
        }

        public BlEngineerNameIsNull(string? message) : base(message)
        {
        }

        public BlEngineerNameIsNull(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BlEngineerNameIsNull(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
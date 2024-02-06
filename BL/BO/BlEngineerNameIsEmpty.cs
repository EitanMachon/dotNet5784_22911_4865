using System.Runtime.Serialization;

namespace BO
{
    [Serializable]
    internal class BlEngineerNameIsEmpty : Exception
    {
        public BlEngineerNameIsEmpty()
        {
        }

        public BlEngineerNameIsEmpty(string? message) : base(message)
        {
        }

        public BlEngineerNameIsEmpty(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BlEngineerNameIsEmpty(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
using System.Runtime.Serialization;

namespace BO
{
    [Serializable]
    internal class BlEngineerLevelIsNegative : Exception
    {
        public BlEngineerLevelIsNegative()
        {
        }

        public BlEngineerLevelIsNegative(string? message) : base(message)
        {
        }

        public BlEngineerLevelIsNegative(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BlEngineerLevelIsNegative(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
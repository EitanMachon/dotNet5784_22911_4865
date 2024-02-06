using System.Runtime.Serialization;

namespace BO
{
    [Serializable]
    internal class BlEngineerLevelIsTooHigh : Exception
    {
        public BlEngineerLevelIsTooHigh()
        {
        }

        public BlEngineerLevelIsTooHigh(string? message) : base(message)
        {
        }

        public BlEngineerLevelIsTooHigh(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BlEngineerLevelIsTooHigh(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
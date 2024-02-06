using System.Runtime.Serialization;

namespace BO
{
    [Serializable]
    internal class BlEngineerHasTask : Exception
    {
        public BlEngineerHasTask()
        {
        }

        public BlEngineerHasTask(string? message) : base(message)
        {
        }

        public BlEngineerHasTask(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BlEngineerHasTask(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
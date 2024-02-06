using System.Runtime.Serialization;

namespace BlImplenentation
{
    [Serializable]
    internal class BlEngineerNotQualifiedForTask : Exception
    {
        public BlEngineerNotQualifiedForTask()
        {
        }

        public BlEngineerNotQualifiedForTask(string? message) : base(message)
        {
        }

        public BlEngineerNotQualifiedForTask(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BlEngineerNotQualifiedForTask(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
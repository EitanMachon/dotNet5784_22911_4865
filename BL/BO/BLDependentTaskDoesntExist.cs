using System.Runtime.Serialization;

namespace BO
{
    [Serializable]
    internal class BLDependentTaskDoesntExist : Exception
    {
        public BLDependentTaskDoesntExist()
        {
        }

        public BLDependentTaskDoesntExist(string? message) : base(message)
        {
        }

        public BLDependentTaskDoesntExist(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BLDependentTaskDoesntExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
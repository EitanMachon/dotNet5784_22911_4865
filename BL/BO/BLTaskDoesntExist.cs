using System.Runtime.Serialization;

namespace BO
{
    [Serializable]
    internal class BLTaskDoesntExist : Exception
    {
        public BLTaskDoesntExist()
        {
        }

        public BLTaskDoesntExist(string? message) : base(message)
        {
        }

        public BLTaskDoesntExist(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BLTaskDoesntExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
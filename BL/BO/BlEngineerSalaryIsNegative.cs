using System.Runtime.Serialization;

namespace BO
{
    [Serializable]
    internal class BlEngineerSalaryIsNegative : Exception
    {
        public BlEngineerSalaryIsNegative()
        {
        }

        public BlEngineerSalaryIsNegative(string? message) : base(message)
        {
        }

        public BlEngineerSalaryIsNegative(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BlEngineerSalaryIsNegative(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
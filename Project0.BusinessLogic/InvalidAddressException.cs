using System;
using System.Runtime.Serialization;

namespace Project0.BusinessLogic
{
    /// <summary>
    /// Exception for invalid Address Format
    /// </summary>
    [Serializable]
    public class InvalidAddressException : Exception
    {
        public InvalidAddressException()
        {
        }

        public InvalidAddressException(string message) : base(message)
        {
        }

        public InvalidAddressException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAddressException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
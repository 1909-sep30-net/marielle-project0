using System;
using System.Runtime.Serialization;

namespace Project0.BusinessLogic
{
    [Serializable]
    internal class InvalidLocationExceptio : Exception
    {
        public InvalidLocationExceptio()
        {
        }

        public InvalidLocationExceptio(string message) : base(message)
        {
        }

        public InvalidLocationExceptio(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidLocationExceptio(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
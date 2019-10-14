using System;
using System.Runtime.Serialization;

namespace Project0.App
{/// <summary>
/// Exception when no customer is found in the database
/// </summary>
    [Serializable]
    internal class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException()
        {
        }

        public CustomerNotFoundException(string message) : base(message)
        {
        }

        public CustomerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
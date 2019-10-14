using System;
using System.Runtime.Serialization;

namespace Project0.DataAccess
{/// <summary>
/// Exception for Customer ordering than what is available in DB
/// </summary>
    [Serializable]
    public class InsufficientStockException : Exception
    {
        public InsufficientStockException()
        {
        }

        public InsufficientStockException(string message) : base(message)
        {
        }

        public InsufficientStockException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InsufficientStockException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
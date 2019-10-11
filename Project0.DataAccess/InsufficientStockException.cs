using System;
using System.Runtime.Serialization;

namespace Project0.DataAccess
{
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
using System;
using System.Runtime.Serialization;

namespace Project0.BusinessLogic
{
    /// <summary>
    /// Exception for invalid stock i.e. stock that is less than 1
    /// </summary>
    [Serializable]
    public class InvalidStockException : Exception
    {
        public InvalidStockException()
        {
        }

        public InvalidStockException(string message) : base(message)
        {
        }

        public InvalidStockException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidStockException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
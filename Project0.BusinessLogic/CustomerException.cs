using System;

namespace Project0.BusinessLogic
{
    /// <summary>
    /// Exceptions in customer class
    /// </summary>
    public class CustomerException : Exception
    {
        public CustomerException(string message) : base(message)
        {
        }
    }
}
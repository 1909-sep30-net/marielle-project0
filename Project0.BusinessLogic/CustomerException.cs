using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.BusinessLogic
{
     public class CustomerException:Exception
    {
        public CustomerException(string message) : base(message) { }
    }
}

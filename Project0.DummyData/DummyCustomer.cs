using Project0.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.DummyData
{
    public class DummyCustomer
    {
        public static List<Customer> DCustomer = new List<Customer>() 
        {
            new Customer()
            {
                FirstName = "Marielle",
                LastName = "Nolasco",
                CustAddress = new Address()
                {
                    Street = "2210 Pomar Vista",
                    City = "San Leandro",
                    State = States.CA,
                    Zipcode = 94578
                }
            },
            new Customer()
            {
                FirstName = "Spencer",
                LastName = "Anderson",
                CustAddress = new Address()
                {
                    Street = "1999 Madison",
                    City = "Castro Valley",
                    State = States.CA,
                    Zipcode = 94578
                }
            }
        };
    }
}

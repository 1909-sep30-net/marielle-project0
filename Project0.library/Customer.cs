using System;

namespace Project0.library
{
    public class Customer
    {
        private string firstName;
        private string lastName;
        private Address custAddress;
        private int custID;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address CustAddress { get; set; }
    }
}

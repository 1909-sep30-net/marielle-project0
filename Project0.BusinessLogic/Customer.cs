using System;

namespace Project0.BusinessLogic
{
    public class Customer
    {
        private string firstName;
        private string lastName;
        public string userName;
        private Address custAddress;
        private int custID;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address CustAddress { get; set; }
        public string UserName { get; set; }
    }
}

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

        public string FirstName {
            get
            {
                return FirstName;
            }
            set 
            {
                validate(FirstName);
                firstName = FirstName;

            } }

        private void validate(string s)
        {
            if (s == null || s == "" || s == " " || s == "\n") throw new CustomerException("Empty Input");
           
        }

        public string LastName {
            get 
            {
                return LastName;
            }

            set 
            {
                validate(LastName); 
                lastName = LastName;
            } 
        }
        public Address CustAddress { get; set; }
        public string UserName {
            get
            {
                return UserName;
            }
            set 
            {
                validate(UserName);
                userName = UserName;
                
            } }
    }
}

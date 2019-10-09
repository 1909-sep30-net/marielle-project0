using System;
using System.Text.RegularExpressions;

namespace Project0.BusinessLogic
{
    public class Customer
    {
        private string firstName;
        private string lastName;
        //public string userName;
        private Address custAddress;
        private int custID;

        public string FirstName {
            get => firstName;
            set 
            {
                try
                {
                    validate(value);
                    firstName = value;
                }
                catch (CustomerException)
                {

                    throw new CustomerException("Invalid First Name");
                }
                

            } }

       

        public string LastName {
            get => lastName;
            set 
            {
                try
                {
                    validate(value);
                    lastName = value;
                }
                catch (CustomerException)
                {

                    throw new CustomerException("Invalid Last Name");
                }
            } 
        }
        public Address CustAddress { get; set; }
        //public string UserName {
        //    get
        //    {
        //        return UserName;
        //    }
        //    set 
        //    {
        //        try
        //        {
        //            validate(value);
        //            userName = value;

        //        }
        //        catch (CustomerException ex)
        //        {

        //            throw ex;
        //        }
                
        //    } 
        
        //}
        public int CustID { get; set; }
        private void validate(string s)
        {
            if (!(Regex.Match(s, @"\s*[A-z]+").Success)) throw new CustomerException("Empty Input");

        }
    }
}

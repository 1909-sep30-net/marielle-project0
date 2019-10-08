using System;
using System.Text.RegularExpressions;

namespace Project0.BusinessLogic
{
    public class Address
    {
        private string street, city;
        private States state;
        private int zipcode;
        public string Street 
        {
            get 
            {
                return Street;
            }

            set 
            {
                if (Regex.Match(value, @"\d+\s[A-z]+?(\s[A-z])*").Success) street = value;
                else 
                {
                    throw new InvalidAddressException("Invalid Street");
                }
            }
                
        }
        public string City 
        {
            get
            {
                return city;
            }

            set 
            {
                if (Regex.Match(value, @"[A-z]+?(\s[A-z])*").Success) city = value;
                throw new InvalidAddressException("Invalid City");
            }
            
        }
        public States State 
        {
            get => state;
            set 
            {
                validate(value);
                state = value;
                throw new InvalidAddressException("Invalid State");
            }
        }

        private void validate(States value)
        {
            throw new NotImplementedException();
        }

        public int Zipcode 
        { 
            get => zipcode; 
            set
            {
                if (Regex.Match(value.ToString(), @"\d{5}").Success) zipcode = value;
                throw new InvalidAddressException("Invalid Zipcode");
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Project0.BusinessLogic;
using Project0.DummyData;

namespace Project0.DataAccess
{
    public class CustomerHandler
    {
        public void AddCustomer(Customer c)
        {
            //Code to add customer to database
            DummyCustomer.DCustomer.Add(c);
            
        }

        public int GetCustomerID()
        {
            //code to get customer ID from DB;
            return 0;
        }

        public List<Customer> Search(string firstName, string lastName)
        {
            //generate code that searches db by name
            List<Customer> customerFound = new List<Customer>();
            switch (Validate(firstName, lastName))
            {
                case 0:
                    throw new CustomerException("Invalid name");
                    
                case 1:
                    //first name valid, last name unknown
                    foreach (Customer c in DummyCustomer.DCustomer) 
                    {
                        if (c.FirstName == firstName) customerFound.Add(c);
                    }
                    if(customerFound == null) throw CustomerNotFoundException("Customer not found");
                    break;

                case 2:
                    //last name valid, first name unknown
                    foreach (Customer c in DummyCustomer.DCustomer)
                    {
                        if (c.LastName == lastName) customerFound.Add(c);
                    }
                    if (customerFound == null) throw CustomerNotFoundException("Customer not found");
                    break;

                case 3:
                    foreach (Customer c in DummyCustomer.DCustomer)
                    {
                        if (c.LastName == lastName && c.FirstName == firstName) customerFound.Add(c);
                    }
                    if (customerFound == null) throw CustomerNotFoundException("Customer not found");
                    break;
                    //full name valid;
            }
            return customerFound;
            //code to Search customer in DB
        }

        public Exception CustomerNotFoundException(string v)
        {
            throw new NotImplementedException(v);
        }

        private int Validate(string firstName, string lastName)
        {
            int fName = 0;
            int lName = 0;
            if (Regex.Match(firstName, @"\s*[A-z]\s*").Success) fName++;
            if (Regex.Match(lastName, @"\s*[A-z]\s*").Success) lName = lName + 2;
            return lName + fName;
            
        }
    }
}

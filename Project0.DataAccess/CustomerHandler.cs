using Microsoft.EntityFrameworkCore;
using Project0.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BL = Project0.BusinessLogic;

namespace Project0.DataAccess
{/// <summary>
/// This class connects the DB versions of the Customer class to Business Logic versions of the Customer Class and vice versa
/// Accesses the DB
/// </summary>
    public class CustomerHandler
    {
        /// <summary>
        /// Method that converts Business Logic Customer objects to Data Access customer objects (for connecting with database)
        /// </summary>
        /// <param name="c"></param>
        /// <returns>DataAccces Customer object</returns>
        public Customer ParseCustomer(BL.Customer c)
        {
            Customer cust = new Customer()
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                Street = c.CustAddress.Street,
                City = c.CustAddress.City,
                State = c.CustAddress.State.ToString(),
                ZipCode = c.CustAddress.Zipcode.ToString()
            };

            return cust;
        }
        /// <summary>
        /// Method that converts DataAccess Customer objects to Business Logic Customer objects (for ineracting with UI)
        /// </summary>
        /// <param name="c"></param>
        /// <returns>BusinessLogic Customer object</returns>
        public BL.Customer ParseCustomer(Customer c)
        {
            BL.Customer cust = new BL.Customer()
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                CustAddress = new BL.Address()
                {
                    Street = c.Street,
                    City = c.City,
                    State = (BL.States)Enum.Parse(typeof(BL.States), c.State, true),
                    Zipcode = int.Parse(c.ZipCode)
                }
            };

            return cust;
        }

        /// <summary>
        /// Method that sets up connection with db
        /// </summary>
        /// <returns>DBContext</returns>
        public Project0DBContext GetContext()
        {
            string connectionString = SecretConfiguration.ConnectionString;

            DbContextOptions<Project0DBContext> options = new DbContextOptionsBuilder<Project0DBContext>()
                .UseSqlServer(connectionString)
                .UseLoggerFactory(SQLLogger.AppLoggerFactory).Options;

            return new Project0DBContext(options);
        }
        /// <summary>
        /// Method that adds customers to database
        /// </summary>
        /// <param name="c"></param>
        public void AddCustomer(BL.Customer c)
        {
            //Code to add customer to database
            using var context = GetContext();
            Customer cust = ParseCustomer(c);
            context.Customer.Add(cust);
            context.SaveChanges();
        }
        /// <summary>
        /// Method that searches a customer in the database based on their first and last names
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>List of Business Logic Customer Objects</returns>
        public List<BL.Customer> Search(string firstName, string lastName)
        {
            //generate code that searches db by name
            List<BL.Customer> customerFound = new List<BL.Customer>();
            using var context = GetContext();
            switch (Validate(firstName, lastName))
            {
                case 0:
                    throw new BL.CustomerException("Invalid name");

                case 1:
                    //first name valid, last name unknown
                    foreach (Customer c in context.Customer)
                    {
                        if (c.FirstName == firstName) customerFound.Add(ParseCustomer(c));
                    }
                    if (customerFound == null) throw CustomerNotFoundException("Customer not found");
                    break;

                case 2:
                    //last name valid, first name unknown
                    foreach (Customer c in context.Customer)
                    {
                        if (c.LastName == lastName) customerFound.Add(ParseCustomer(c));
                    }
                    if (customerFound == null) throw CustomerNotFoundException("Customer not found");
                    break;

                case 3:
                    //full name valid;
                    foreach (Customer c in context.Customer)
                    {
                        if (c.LastName == lastName && c.FirstName == firstName) customerFound.Add(ParseCustomer(c));
                    }
                    if (customerFound == null) throw CustomerNotFoundException("Customer not found");
                    break;
                    
            }
            return customerFound;
        }
        /// <summary>
        /// Exception generated when a customer was not found in db records
        /// </summary>
        /// <param name="v"></param>
        /// <returns>NotImplementedException</returns>
        public Exception CustomerNotFoundException(string v)
        {
            throw new NotImplementedException(v);
        }
        /// <summary>
        /// Method that validates the format of names the user inputted
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
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
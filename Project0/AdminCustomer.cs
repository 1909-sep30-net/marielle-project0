using Project0.BusinessLogic;
using Project0.DataAccess;
using System;
using System.Collections.Generic;

namespace Project0.App
{
    public class AdminCustomer
    {
        public void MainMenu()
        {
            Console.WriteLine("Welcome to the Customer Records! \n What would you like to do?");
            Console.WriteLine(" [1] Add Customers \n [2] Search Customers \n [3] Go back to Main Menu \n [4] Exit");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddCustomerMenu();
                    break;
                case "2":
                    SearchCustomerMenu();
                    break;
                case "3":
                    //go back to Main Menu
                    AdminMenu main = new AdminMenu();
                    main.Welcome();
                    break;
                case "4":
                    //go to exit
                    ExitMenu exit = new ExitMenu();
                    exit.Exit();
                    break;

                default:
                    //error handling
                    ErrorHandler err = new ErrorHandler();
                    err.InvalidInputMsg();
                    MainMenu();
                    break;
            }
        }
        public Customer AddNewCustomer()
        {
            //code to add customers;
            //adds customer info
            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter Street:");
            string street = Console.ReadLine();
            Console.WriteLine("Enter City:");
            string city = Console.ReadLine();

            Console.WriteLine("Enter State:");
            string inputState = Console.ReadLine();

            Console.WriteLine("Enter Zipcode:");
            string zip = Console.ReadLine();
            try
            {
                States state = (States)Enum.Parse(typeof(States), inputState, true);
                int zipcode = int.Parse(zip);
                Address custAddress = new Address()
                {
                    Street = street,
                    City = city,
                    State = state,
                    Zipcode = zipcode
                };

                Customer c = new Customer()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    CustAddress = custAddress
                };
                CustomerHandler ch = new CustomerHandler();
                ch.AddCustomer(c);
                Console.WriteLine("Customer added!");
                return c;

            }
            catch (CustomerException ex)
            {
                throw ex;
            }
            catch (ArgumentException e)
            {
                throw e;
            }
            catch (FormatException e)
            {
                throw e;
            }
            catch (InvalidAddressException e)
            {
                throw e;
            }

        }
        public void AddCustomerMenu()
        {
            
            try
            {

                _ = AddNewCustomer();
                MainMenu();
                
            }
            catch (CustomerException ex)
            {
                Console.WriteLine(ex.Message);
                TryAgain(AddCustomerMenu);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Invalid State");
                TryAgain(AddCustomerMenu);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Invalid Zipcode");
                TryAgain(AddCustomerMenu);
            }
            catch (InvalidAddressException e)
            {
                Console.WriteLine(e.Message);
                TryAgain(AddCustomerMenu);
            }
        }
        public List<Customer> SearchCustomer() {
            Console.WriteLine("Enter name in fields that apply, if unknown, leave blank");
            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string lastName = Console.ReadLine();

            try
            {
                CustomerHandler ch = new CustomerHandler();
                List<Customer> c = ch.Search(firstName, lastName);
                if (c.Count > 0)
                {
                    Console.WriteLine(c.Count + " customers found");
                    foreach (Customer cust in c)
                    {
                        Console.WriteLine("Name: " + cust.FirstName + " " + cust.LastName + " City: " + cust.CustAddress.City);
                    }
                }
                return c;
            }
            catch (CustomerException ex)
            {

                throw ex;

            }
            catch (NotImplementedException ex)
            {
                throw ex;
            }
        }

        public void SearchCustomerMenu()
        {
            
            try
            {
                _ = SearchCustomer();
                Console.WriteLine("[1] Back to main menu? \n[2] Customer Menu?\n[3] Exit?");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AdminMenu am = new AdminMenu();
                        am.Welcome();
                        break;
                    case "2":
                        MainMenu();
                        break;
                    case "3":
                        ExitMenu exit = new ExitMenu();
                        exit.Exit();
                        break;
                    default:
                        ErrorHandler err = new ErrorHandler();
                        err.InvalidInputMsg();
                        ExitMenu ex = new ExitMenu();
                        ex.Exit();
                        break;
                }

            }
            catch (CustomerException ex)
            {

                Console.WriteLine(ex.Message);
                TryAgain(SearchCustomerMenu);

            }
            catch (NotImplementedException ex) 
            {
                Console.WriteLine(ex.Message);
                TryAgain(SearchCustomerMenu);
            }
        }


        private void TryAgain(Action last)
        {
            Console.WriteLine("Try again? \n Y^(YES) N^(NO)");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "Y":
                    last();
                    break;
                case "N":
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    TryAgain(last);
                    break;
            }
        }
        
    }
}
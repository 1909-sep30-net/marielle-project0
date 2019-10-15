using Project0.BusinessLogic;
using Project0.DataAccess;
using Serilog;
using System;
using System.Collections.Generic;

namespace Project0.App
{
    /// <summary>
    /// UI for Customer Operations
    /// </summary>
    public class AdminCustomer
    {
        ///<summary>Main Menu for customer operations</summary>
        public void MainMenu()
        {
            string input;
            do
            {
                Console.WriteLine("Welcome to the Customer Records! \n What would you like to do?");
                Console.WriteLine(" [0] Add Customers \n [1] Search Customers \n [2] Get Customer History \n [3] Go back to Main Menu \n [4] Exit");
                input = Console.ReadLine();
            } while (ErrorHandler.InvalidIntInput(input));

            switch (input)
            {
                case "0":
                    //Go to Add Customer UI
                    AddCustomerMenu();
                    break;

                case "1":
                    //Go to Search Customer UI
                    SearchCustomerMenu();
                    break;

                case "2":
                    //Go to Customer History UI
                    AdminOrder ao = new AdminOrder();
                    ao.ViewCustomerOrderHistory();
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
                    Log.Error("Invalid Input");
                    MainMenu();
                    break;
            }
        }

        ///<summary>Adds customer information through user input and passes to handler class to validate and add to db</summary>
        public Customer AddNewCustomer()
        {
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
                Log.Information($"Customer {firstName} {lastName} added");
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

        ///<summary>Add Customer UI that returns to Main Customer Menu</summary>
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
                Log.Error(ex.Message);
                TryAgain(AddCustomerMenu);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Invalid State");
                Log.Error(e.Message);
                TryAgain(AddCustomerMenu);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Invalid Zipcode");
                Log.Error(e.Message);
                TryAgain(AddCustomerMenu);
            }
            catch (InvalidAddressException e)
            {
                Console.WriteLine(e.Message);
                Log.Error(e.Message);
                TryAgain(AddCustomerMenu);
            }
        }

        ///<summary>Searches customer by passing Business Logic customer object to handler class and printing result fom db</summary>
        public List<Customer> SearchCustomer()
        {
            Console.WriteLine("Enter name in fields that apply, if unknown, leave blank");
            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string lastName = Console.ReadLine();

            try
            {
                CustomerHandler ch = new CustomerHandler();
                List<Customer> c = ch.Search(firstName, lastName);
                Log.Information($"Search customer with name: {firstName} {lastName}");
                if (c.Count > 0)
                {
                    Console.WriteLine(c.Count + " customers found");
                    int i = 0;
                    foreach (Customer cust in c)
                    {
                        Console.WriteLine("[" + i + "] Name: " + cust.FirstName + " " + cust.LastName + " City: " + cust.CustAddress.City);
                        i++;
                    }
                    Log.Information(c.Count + " customers found");
                }
                else
                {
                    throw new CustomerNotFoundException("No customer found");
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
            catch (CustomerNotFoundException ex)
            {
                throw ex;
            }
        }

        ///<summary>Search customer UI that returns to main customer menu when finished </summary>
        public void SearchCustomerMenu()
        {
            try
            {
                _ = SearchCustomer();
                string input;
                do
                {
                    Console.WriteLine("Where would you like to go? \n [0] Back to main menu? \n [1] Customer Menu?\n [2] Exit?");
                    input = Console.ReadLine();
                } while (ErrorHandler.InvalidIntInput(input));

                switch (input)
                {
                    case "0":
                        AdminMenu am = new AdminMenu();
                        am.Welcome();
                        break;

                    case "1":
                        MainMenu();
                        break;

                    case "2":
                        ExitMenu exit = new ExitMenu();
                        exit.Exit();
                        break;

                    default:
                        ErrorHandler err = new ErrorHandler();
                        err.InvalidInputMsg();
                        Log.Error("Invalid Input");
                        ExitMenu ex = new ExitMenu();
                        ex.Exit();
                        break;
                }
            }
            catch (CustomerException ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error(ex.Message);
                TryAgain(SearchCustomerMenu);
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error(ex.Message);
                TryAgain(SearchCustomerMenu);
            }
            catch (CustomerNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error(ex.Message);
                TryAgain(SearchCustomerMenu);
            }
        }

        ///<summary>Method that asks the user if it wants to retry a failed operation</summary>
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
                    Log.Error("Invalid Input");
                    TryAgain(last);
                    break;
            }
        }
    }
}
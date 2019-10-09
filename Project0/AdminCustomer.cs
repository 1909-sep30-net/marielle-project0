﻿using Project0.BusinessLogic;
using Project0.DataAccess;
using System;

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

        private void AddCustomerMenu()
        {
            //code to add customers;
            //adds customer info
            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            string lastName = Console.ReadLine();

            //Adding Username
            //Console.WriteLine("Enter User Name:");
            //string userName = Console.ReadLine();

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
                   // UserName = userName,
                    CustAddress = custAddress
                };
                CustomerHandler ch = new CustomerHandler();
                ch.AddCustomer(c);
                Console.WriteLine("Customer added!");
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

        public void SearchCustomerMenu()
        {
            Console.WriteLine("Enter name in fields that apply, if unknown, leave blank");
            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string lastName = Console.ReadLine();
            try
            {
                CustomerHandler ch = new CustomerHandler();
                ch.Search(firstName, lastName);

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
            Console.WriteLine("Try again?");
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
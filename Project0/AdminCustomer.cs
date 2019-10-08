using Project0.BusinessLogic;
using Project0.DataAccess;
using System;

namespace Project0.App
{
    public class AdminCustomer
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to the Customer Records! \n What would you like to do?");
            Console.WriteLine("[1] Add Customers \n[2] View Customers \n[3] Exit");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    //code to add customers;
                    //adds customer info
                    Console.WriteLine("Enter First Name:");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Enter Last Name:");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Enter User Name:");
                    string userName = Console.ReadLine();

                    Console.WriteLine("Enter Street:");
                    string street= Console.ReadLine();
                    Console.WriteLine("Enter City:");
                    string city= Console.ReadLine();

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
                            UserName = userName,
                            CustAddress = custAddress
                        };
                        CustomerHandler ch = new CustomerHandler();
                        ch.AddCustomer(c);
                    }
                    catch (CustomerException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Menu();
                    }
                    catch (ArgumentException e) 
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Invalid State");
                        Menu();
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                        Menu();
                    }
                    break;
                case "2":
                    //code to view customers;
                    break;
                case "3":
                    //go to exit
                    ExitMenu exit = new ExitMenu();
                    exit.Exit();
                    break;
                default:
                    //error handling
                    ErrorHandler err = new ErrorHandler();
                    err.InvalidInputMsg();
                    Menu();
                    break;
            }
        }
    }
}
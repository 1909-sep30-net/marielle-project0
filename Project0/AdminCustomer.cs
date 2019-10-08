using Project0.BusinessLogic;
using System;

namespace Project0.App
{
    internal class AdminCustomer
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
                    SignUpMenu sm = new SignUpMenu();
                    sm.SignupMenu();

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
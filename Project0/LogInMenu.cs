using System;
using System.Collections.Generic;
using System.Text;
using Project0.DataAccess;


namespace Project0.App
{
    class LogInMenu
    {
        public void LoginMenu()
        {
            Console.WriteLine("Enter your username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();
            CustomerHandler ch = new CustomerHandler();
            OrderMenu om = new OrderMenu();
            ExitMenu ex = new ExitMenu();
            ErrorHandler err = new ErrorHandler();
            if (ch.Verify(username, password))
            {
               // om.Ordermenu();
            }
            else
            {
                Console.WriteLine("Unable to verify account");
                Console.WriteLine("Try again? \n Y^(Yes) N^(No)");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "Y":
                        LoginMenu();
                        break;
                    case "N":
                        ex.Exit();
                        LoginMenu();
                        break;
                    default:
                        err.InvalidInputMsg();
                        break;
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.App
{
    public class Menu
    {
        public void welcome()
        {
            
            Console.WriteLine("Welcome! To the Bare Bones Bookstore");
        
            Console.WriteLine("Are you a new customer?");
            Console.WriteLine("Input Y^(Yes) or N^(No)");
            string input = Console.ReadLine();
            switch (input)
            {
                case "Y":
                    Console.WriteLine("Please sign up before continuing");
                    signuupMenu();
                    break;
                case "N":
                    Console.WriteLine("Nice to see you again! Please log in to continue");
                    loginMenu();
                    break;
                default:
                    InvalidInputMsg();
                    welcome();
                    break;
            }
        }

        private void loginMenu()
        {
           Console.WriteLine("Enter your username: ");
           string username = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();
            if(verify(username, password))
            {
                orderMenu();
            } else
            {
                Console.WriteLine("Unable to verify account");
                Console.WriteLine("Try again? \n Y^(Yes) N^(No)");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "Y":
                        loginMenu();
                        break;
                    case "N":
                        exit(loginMenu);
                        break;
                    default:
                        InvalidInputMsg();
                        loginMenu();
                        break;
                }
            }
           
        }

        private void InvalidInputMsg()
        {
            Console.WriteLine("Invalid Input");
        }

        private void exit(Action last)
        {
            //exit application
            Console.WriteLine("Exit? \n Y^(Yes) N^(No)");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "N":
                    last();
                    break;
                case "Y":
                    System.Environment.Exit(1);
                    break;
                default:
                    InvalidInputMsg();
                    exit(last);
                    break;
            }

        }

        private void orderMenu()
        {
            //generate order menu
        }

        private bool verify(string username, string password)
        {
            //verify username and password
            return false;
        }

        private void signuupMenu()
        {
            //for new customers signing up
            Console.WriteLine("Enter Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();

        }
    }
}

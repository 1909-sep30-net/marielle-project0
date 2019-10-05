using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.App
{   /// <summary>
/// main menu class
/// </summary>
    public class MainMenu
    {
        public void Welcome()
        {
            
            Console.WriteLine("Welcome! To the Bare Bones Bookstore");
        
            Console.WriteLine("Are you a new customer?");
            Console.WriteLine("Input Y^(Yes) or N^(No)");
            string input = Console.ReadLine();
            SignUpMenu signup = new SignUpMenu();
            switch (input)
            {
                case "Y":
                    Console.WriteLine("Please sign up before continuing");
                    signup.SignupMenu();
                    break;
                case "N":
                    Console.WriteLine("Nice to see you again! Please log in to continue");
                    LogInMenu login = new LogInMenu();
                    login.LoginMenu();
                    break;
                default:
                    ErrorHandler err = new ErrorHandler();
                    err.InvalidInputMsg();
                    break;
            }
        }

        

        

       
        

       

        

        
    }
}

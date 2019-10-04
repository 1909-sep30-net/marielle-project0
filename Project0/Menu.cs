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
        top:
            Console.WriteLine("Are you a new customer?");
            Console.WriteLine("Input Y^(Yes) or N^(No)");
            string input = Console.ReadLine();
            switch (input)
            {
                case "Y":
                    Console.WriteLine("Please sign up before continuing");
                    break;
                case "N":
                    Console.WriteLine("Nice to see you again! Please log in to continue");
                    break;
                default:
                    Console.WriteLine("Input invalid");
                    goto top;
                    break;
            }
        }
    }
}

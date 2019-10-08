using System;

namespace Project0.App
{
    public class AdminProducts
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to the Product Records! \nWhat would you like to do?");
            Console.WriteLine("[1] Add Product \n[2] View Products \n[3] Exit");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    //Code to add product
                    break;
                case "2":
                    //code to view product
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
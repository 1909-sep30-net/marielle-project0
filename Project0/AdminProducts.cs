using System;

namespace Project0.App
{
    public class AdminProducts
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to the Product Records! \nWhat would you like to do?");
            Console.WriteLine("[1] Add Product [2] View Products");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    //Code to add product
                    break;
                case "2":
                    //code to view product
                    break;
                default:
                    //error handling
                    break;
            }
        }
    }
}
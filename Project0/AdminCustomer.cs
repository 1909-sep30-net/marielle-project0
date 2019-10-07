using System;

namespace Project0.App
{
    internal class AdminCustomer
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to the Customer Records! \n What would you like to do?");
            Console.WriteLine("[1] Add Customers [2] View Customers");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    //code to add customers;
                    break;
                case "2":
                    //code to view customers;
                    break;
                default:
                    //error handling
                    break;
            }
        }
    }
}
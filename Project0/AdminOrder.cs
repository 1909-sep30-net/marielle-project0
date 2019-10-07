using System;

namespace Project0.App
{
    public class AdminOrder
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to Order UI! \n What would you like to do?");
            Console.WriteLine("[1] Add Order \n[2] View Order");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    //code to add order
                    break;
                case "2":
                    //code to view order
                    break;
                default:
                    //Error Handling
                    break;
            }
        }
    }
}
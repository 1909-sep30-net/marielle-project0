using System;

namespace Project0.App
{
    internal class AdminLocation
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to Location UI! \n What would you like to do?");
            Console.WriteLine("[1] Add Location [2] View Location Inventory");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    //code to add a location
                    break;
                case "2":
                    //code to view location inventory
                    break;
                default:
                    //error handling
                    break;
            }
        }
    }
}
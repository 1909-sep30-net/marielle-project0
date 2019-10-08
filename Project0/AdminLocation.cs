using System;

namespace Project0.App
{
    internal class AdminLocation
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to Location UI! \n What would you like to do?");
            Console.WriteLine("[1] Add Location \n[2] View Location Inventory \n[3] Exit");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    //code to add a location
                    break;
                case "2":
                    //code to view location inventory
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
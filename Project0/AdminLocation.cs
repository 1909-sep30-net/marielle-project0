using Project0.BusinessLogic;
using Project0.DataAccess;
using System;
using System.Collections.Generic;

namespace Project0.App
{
    internal class AdminLocation
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to Location UI! \n What would you like to do?");
            Console.WriteLine("[1] View Order History of Location \n [2] View Location Inventory \n [3] Go back to Main Menu \n [4] Exit");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    //code to view orderhistory of location
                    AdminOrder ao = new AdminOrder();
                    ao.ViewLocationOrderHistory();
                    break;
                case "2":
                    //code to view location inventory
                    ViewLocationInventory();
                    break;
                case "3":
                    //go back to Main Menu
                    AdminMenu main = new AdminMenu();
                    main.Welcome();
                    break;
                case "4":
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

        private void ViewLocationInventory()
        {
            //code to View Inventory of Chosen Location
            Console.WriteLine("Choose Branch");
            LocationHandler lh = new LocationHandler();
            List<Location> locations = lh.GetLocations();
            int i = 0;
            foreach(Location l in locations)
            {
                Console.WriteLine($"[{i}] {l.BranchName}");
                i++;
            }
            string input = Console.ReadLine();
            List<Inventory> storeInventory = lh.GetInventory(locations[int.Parse(input)]);
            foreach(Inventory inv in storeInventory) 
            {
                Console.WriteLine("Product: " + inv.Prod.Name + " \n Stock: " + inv.Stock);
            }

        }
    }
}
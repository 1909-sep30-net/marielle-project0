using Project0.BusinessLogic;
using Project0.DataAccess;
using Serilog;
using System;
using System.Collections.Generic;

namespace Project0.App
{
    /// <summary>
    /// UI for Location Operations
    /// </summary>
    internal class AdminLocation
    {
        ///<summary>Main menu for location operations</summary>
        public void Menu()
        {
            Console.WriteLine("Welcome to Location UI! \n What would you like to do?");
            Console.WriteLine(" [0] View Order History of Location \n [1] View Location Inventory \n [2] Go back to Main Menu \n [3] Exit");
            string input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    //code to view orderhistory of location
                    AdminOrder ao = new AdminOrder();
                    ao.ViewLocationOrderHistory();
                    break;

                case "1":
                    //code to view location inventory
                    ViewLocationInventory();
                    break;

                case "2":
                    //go back to Main Menu
                    AdminMenu main = new AdminMenu();
                    main.Welcome();
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

        ///<summary>Method to View Inventory of Chosen Location by passing business logic location object to data handler</summary>
        private void ViewLocationInventory()
        {
            LocationHandler lh = new LocationHandler();
            List<Location> locations = lh.GetLocations();
            int i = 0;
            foreach (Location l in locations)
            {
                Console.WriteLine($" [{i}] {l.BranchName}");
                i++;
            }
            string input;
            do
            {
                Console.WriteLine("Choose Branch");
                input = Console.ReadLine();
            } while (ErrorHandler.InvalidIntInput(input));
            try
            {
                List<Inventory> storeInventory = lh.GetInventory(locations[int.Parse(input)]);
                foreach (Inventory inv in storeInventory)
                {
                    Console.WriteLine("Product: " + inv.Prod.Name + " \n Stock: " + inv.Stock);
                }
                Log.Information($"Viewed inventory of {locations[int.Parse(input)].BranchName}");
                Menu();
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error(ex.Message);
                ViewLocationInventory();
            }
        }
    }
}
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.App
{/// <summary>
/// Main Menu
/// Root node of program navigation
/// </summary>
    class AdminMenu
    {
        public void Welcome() 
        {
            Console.WriteLine("Tindahan ni Aling Nena");
            Console.WriteLine("Welcome BacK! What would you like to view?");
            Console.WriteLine(" [1] Location \n [2] Customer  \n [3] Orders \n [4] Exit");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    //go to the Locations UI
                    AdminLocation al = new AdminLocation();
                    al.Menu();
                    break;
                case "2":
                    //go to customer UI
                    AdminCustomer ac = new AdminCustomer();
                    ac.MainMenu();
                    break;
                case "3":
                    //go to order UI
                    AdminOrder ao = new AdminOrder();
                    ao.Menu();
                    break;
                case "4":
                    //go to exit
                    ExitMenu exit = new ExitMenu();
                    exit.Exit();
                    break;
                default:
                    //error handler
                    ErrorHandler err = new ErrorHandler();
                    err.InvalidInputMsg();
                    Log.Error("Invalid Input.");
                    Welcome();
                    break;
            }

        }
    }
}

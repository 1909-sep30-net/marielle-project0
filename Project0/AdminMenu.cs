using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.App
{
    class AdminMenu
    {
        public void Welcome() 
        {
            Console.WriteLine("Welcome Back! What would you like to view?");
            Console.WriteLine(" [1] Location \n [2] Customer \n [3] Products \n [4] Orders \n [5] Exit");
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
                    ac.Menu();
                    break;
                case "3":
                    // go to products UI
                    AdminProducts ap = new AdminProducts();
                    ap.Menu();
                    break;
                case "4":
                    //go to order UI
                    AdminOrder ao = new AdminOrder();
                    ao.Menu();
                    break;
                case "5":
                    //go to exit
                    ExitMenu exit = new ExitMenu();
                    exit.Exit();
                    break;
                default:
                    //error handler
                    ErrorHandler err = new ErrorHandler();
                    err.InvalidInputMsg();
                    Welcome();
                    break;
            }

        }
    }
}

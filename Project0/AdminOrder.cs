using System;

namespace Project0.App
{
    public class AdminOrder
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to Order UI! \n What would you like to do?");
            Console.WriteLine(" [1] Place Order \n [2] View Order History of Customer \n [3] View Order History of Location\n [4] Exit");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    //code to add order
                    AddOrder();
                    break;
                case "2":
                    //code to view order history of customer
                    ViewCustomerOrderHistory();
                    break;
                case "3":
                    //code to view order history of location
                    ViewLocationOrderHistory();
                    break;
                case "4":
                    //go to exit
                    ExitMenu exit = new ExitMenu();
                    exit.Exit();
                    break;
                default:
                    //Error Handling
                    ErrorHandler err = new ErrorHandler();
                    err.InvalidInputMsg();
                    Menu();
                    break;
            }
        }

        private void ViewLocationOrderHistory()
        {
            //code to view location history
        }

        private void ViewCustomerOrderHistory()
        {
           //code to view customer history
        }

        private void AddOrder()
        {
            //code to place order


        }
    }
}
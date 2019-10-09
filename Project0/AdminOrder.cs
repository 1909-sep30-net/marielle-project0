﻿using Project0.BusinessLogic;
using Project0.DataAccess;
using System;
using System.Collections.Generic;

namespace Project0.App
{
    public class AdminOrder
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to Order UI! \n What would you like to do?");
            Console.WriteLine(" [1] Place Order \n [2] View Order History of Customer \n [3] View Order History of Location\n [4] Return to Main Menu \n [5] Exit");
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
                    //go back to Main Menu
                    AdminMenu main = new AdminMenu();
                    main.Welcome();
                    break;
                case "5":
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

        public void ViewLocationOrderHistory()
        {
            //code to view location history
            Location l = EnterLocationDetails();
            OrderHandler oh = new OrderHandler();
            List<Order> history = oh.GetLocationHistory(l);
            foreach(Order o in history)
            {
                Console.WriteLine(o.Date);
                foreach(Inventory i in o.CustOrder)
                {
                    Console.WriteLine(" Product: " + i.Prod.Name + " \n Quantity: " + i.Stock);
                    
                }
            }

        }

        private void ViewCustomerOrderHistory()
        {
            //code to view customer history
            Customer c = EnterCustomerDetails();
            OrderHandler oh = new OrderHandler();
            List<Order> history = oh.GetCustomerHistory(c);
            foreach(Order o in history)
            {
                Console.WriteLine(o.Date);
                foreach(Inventory i in o.CustOrder)
                {
                    Console.WriteLine(" Product: " + i.Prod.Name + "\n Quantity: " + i.Stock);
                    
                }

            }
        }

        private void AddOrder()
        {
            //code to place order

            OrderHandler oh = new OrderHandler();
            LocationHandler lh = new LocationHandler();
            Customer c = EnterCustomerDetails();
            Location l = EnterLocationDetails();
            string choice;
            List<Inventory> custOrder = new List<Inventory>();
            do
            {
                Console.WriteLine("Choose Product to Order:");
                List<Inventory> availInvent = lh.GetInventory(l);
                int j = 0;
                foreach (Inventory i in availInvent) 
                {
                    Console.WriteLine("["+ i+"] " + " Name: "+i.Prod.Name + " Price: " + i.Prod.Price + " Remaining Stock" + i.Stock);
                    j++;
                }
                string input = Console.ReadLine();
                Console.WriteLine("Enter Quantity: ");
                string amount = Console.ReadLine();
                custOrder.Add(new Inventory() { Prod = availInvent[int.Parse(input)].Prod, Stock = int.Parse(amount) }); 
                lh.UpdateInventory(custOrder[custOrder.Count - 1], l);

                Console.WriteLine("Would you like to order another product? \n Y^(Yes) N^(No)");
                choice = Console.ReadLine();

            } while (choice != "N");
            Order o = new Order()
            {
                Cust = c,
                Stor = l,
                Date = DateTime.Now,
                CustOrder = custOrder
            };
            oh.AddOrder(o);
            oh.PrintOrderDetails(o);
        }

        private Location EnterLocationDetails()
        {
            Console.WriteLine("Choose Branch:");
            LocationHandler lh = new LocationHandler();
            List<Location> local = lh.GetLocations();
            int i = 0;
            foreach (Location l in local) 
            {
                Console.WriteLine("[" + i + "] " + l.BranchName);
                i++;
            }
            string choice = Console.ReadLine();
            return local[int.Parse(choice)];
        }

        private Customer EnterCustomerDetails()
        {
            Console.WriteLine("Enter name in fields that apply, if unknown, leave blank");
            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string lastName = Console.ReadLine();
            try
            {
                CustomerHandler ch = new CustomerHandler();
                return ch.Search(firstName, lastName);

            }
            catch (CustomerException ex)
            {

                Console.WriteLine(ex.Message);
                EnterCustomerDetails();
            }
            catch (NotImplementedException ex) 
            {
                Console.WriteLine(ex.Message);
                EnterCustomerDetails();
            }
            return new Customer();
        }
    }
}
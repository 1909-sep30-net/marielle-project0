using Project0.BusinessLogic;
using Project0.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.App
{
    class OrderMenu
    {
        public void Ordermenu(Customer c)
        {
            //generate order menu
            OrderHandler oh = new OrderHandler();
            Customer cust = c;
            CustomerHandler ch = new CustomerHandler();
            LocationHandler lh = new LocationHandler();
            //gets the store locations in the same city or state
            List<string> nearLoc = lh.GetNearestStore(c.CustAddress);
            Console.WriteLine(@"There are {nearLoc.length} near you \n please choose branch name");
            int ctr = 0;
            foreach (string s in nearLoc) 
            {
                Console.WriteLine(ctr + " " + s);
            }
            Console.WriteLine("Please input which branch you'd like to shop from: ");
            int input = int.Parse(Console.ReadLine());
            Location choice = new Location()
            {
                BranchName = nearLoc[input],
                StoreAddress = lh.GetAddress(nearLoc[input]),
                StoreInventory = lh.GetInventory(nearLoc[input])
            };
            Console.WriteLine("Welcome to the " + nearLoc[input] + " branch \n What would you like to buy?");
            //Add code to print out inventory and to take orders
            //Use orderHandler
            //After taking orders create new order object
            Order custorder = new Order()
            {
                Cust = c,
                Num = 0,
                Prod = null,
                Stor = choice
            };
            Console.WriteLine("Finished Ordering? \n Y^(Yes) N^(No)");
            CheckOut chck = new CheckOut();
            chck.CheckOutMenu(c, choice, custorder);
            
            
            
        }
    }
}

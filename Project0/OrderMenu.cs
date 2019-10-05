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
            Location l = new Location();
            Customer cust = c;
            CustomerHandler ch = new CustomerHandler();
            LocationHandler lh = new LocationHandler();
            //gets the store locations in the same city or state
            List<string> nearLoc = lh.GetNearestStore(c.CustAddress);
            Console.WriteLine(@"There are {nearLoc.length} near you \n please choose branch name");
            int ctr = 0;
            foreach (string s in nearLoc) 
            {
                Console.WriteLine(ctr + s);
            }
            Console.WriteLine("Please input whic branch you'd like to shop from: ");
            string input = Console.ReadLine();
            
            
        }
    }
}

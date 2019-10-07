using Project0.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.App
{
    /// <summary>
    /// For checkout
    /// </summary>
    class CheckOut
    {
        public void CheckOutMenu(Customer c, Location l, Order o) 
        {
            Console.WriteLine("Thank you for your patronage");
            ExitMenu ex = new ExitMenu();
            ex.Exit();
        }
    }
}

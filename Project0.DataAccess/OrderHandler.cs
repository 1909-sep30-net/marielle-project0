using System;
using System.Collections.Generic;
using Project0.BusinessLogic;
using Project0.DummyData;
namespace Project0.DataAccess
{
    /// <summary>
    /// Handles the orders of the customer
    /// Gets orders and updates inventory
    /// </summary>
    public class OrderHandler
    {
        
        public void AddOrder(Orders o)
        {
            //code to add order in db
            //Adding order to dummy list
            DummyOrder.DOrder.Add(o);
        }

        public List<Orders> GetCustomerHistory(Customer c)
        {
            //get customer order history
            List<Orders> output = new List<Orders>();
            foreach (Orders o in DummyOrder.DOrder) 
            {
                if (c.FirstName == o.Cust.FirstName && c.LastName == o.Cust.LastName) output.Add(o); 
            }
            return output;
        }

        public List<Orders> GetLocationHistory(Location l)
        {
            List<Orders> output = new List<Orders>();
            foreach(Orders o in DummyOrder.DOrder)
            {
                if (l.BranchName == o.Stor.BranchName) output.Add(o);
            }
            return output;
        }

        public void PrintOrderDetails(Orders o)
        {
            Console.WriteLine("Order placed!");
            Console.WriteLine($"Customer Name: {o.Cust.FirstName} {o.Cust.LastName} \nBranchname: {o.Stor.BranchName}");
            foreach(Inventory i in o.CustOrder)
            {
                Console.WriteLine($"Product: {i.Prod.Name} \n Price (per unit): {i.Prod.Price} \n Quantity: {i.Stock}");
               
            }
            Console.WriteLine($"Order Total: {o.Total}");
            
        }
    }
}

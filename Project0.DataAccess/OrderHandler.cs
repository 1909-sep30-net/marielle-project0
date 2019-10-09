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
        public List<Product> GetProducts()
        {
            return DummyProduce.DProduce;
        }

        public void AddOrder(Order o)
        {
            //code to add order in db
        }
    }
}

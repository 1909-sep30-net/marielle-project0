using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.BusinessLogic
{/// <summary>
/// Order format of the program
/// UI interacts with this format of the Order
/// </summary>
     public class Orders
    {
        private List<Inventory> custOrder;
        private Customer cust;
        private Location stor;
        private DateTime date;
        private decimal total;
        public List<Inventory> CustOrder { get; set; }
        public Customer Cust { get; set; }
        public Location Stor { get; set; }

        public DateTime Date { get; set; }
        public decimal Total
        {
            get

            {
                total = 0;
                foreach (Inventory i in CustOrder)
                {
                    total += i.Stock * i.Prod.Price;
                }
                return total;
            }
            set 
            {
            }
        }


    }
}

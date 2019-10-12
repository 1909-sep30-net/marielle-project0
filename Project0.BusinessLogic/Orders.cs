using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.BusinessLogic
{
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
                foreach (Inventory i in CustOrder)
                {
                    total += i.Stock * i.Prod.Price;
                }
                return total;
            }
            set
            {
                foreach (Inventory i in CustOrder)
                {
                    total += i.Stock * i.Prod.Price;
                }
            }
        }


    }
}

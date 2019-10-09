using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.BusinessLogic
{
     public class Order
    {
        private List<Inventory> custOrder;
        private Customer cust;
        private Location stor;
        private DateTime date;
        public List<Inventory> CustOrder { get; set; }
        public Customer Cust { get; set; }
        public Location Stor { get; set; }

        public DateTime Date { get; set; }


    }
}

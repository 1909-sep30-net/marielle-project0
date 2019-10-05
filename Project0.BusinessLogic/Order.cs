using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.BusinessLogic
{
     public class Order
    {
        private List<Product> prod;
        private Customer cust;
        private Location stor;
        private List<int> quantity; //quantity of products ordered
        private int orderNum;

        public List<Product> Prod { get; set; }
        public Customer Cust { get; set; }
        public Location Stor { get; set; }

        public int Num { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.library
{
     public class Order
    {
        private Product prod;
        private Customer cust;
        private Location stor;
        private int num; //number of items of a product
        private int orderNum;

        public Product Prod { get; set; }
        public Customer Cust { get; set; }
        public Location Stor { get; set; }

        public int Num { get; set; }


    }
}

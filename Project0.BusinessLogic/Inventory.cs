using System.Collections.Generic;

namespace Project0.BusinessLogic
{/// <summary>
/// Defines what is in inventory
/// Object UI uses in location inventory and customer order
/// </summary>
    public class Inventory
    {
       
        private int stock;
        public Product Prod { get; set; }
        public int Stock 
        { 
            get => stock;
            set 
            {
                if (value < 1) throw new InvalidStockException("Invalid Quantity. Please input quantity greater than 0");
                stock = value;
            } 
        }
    }
}
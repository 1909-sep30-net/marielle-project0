using System.Collections.Generic;

namespace Project0.BusinessLogic
{/// <summary>
/// Defines what is in inventory
/// Order UI uses in location inventory and customer order
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
                stock = value;
            } 
        }
    }
}
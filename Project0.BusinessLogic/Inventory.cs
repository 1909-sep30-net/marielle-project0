using System.Collections.Generic;

namespace Project0.BusinessLogic
{
    public class Inventory
    {
        //Define what is in inventory
        public List<Product> Products { get; set; }
        public List<int> Stock { get; set; }
    }
}
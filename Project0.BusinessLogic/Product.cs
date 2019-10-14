using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.BusinessLogic
{/// <summary>
/// Product format of program
/// UI interacts with this format of the Product
/// </summary>
    public class Product
    {
        private decimal price;
        private string name;
        private string desc;
        private int productID;

        public decimal Price { get; set; }
        public string Name { get; set; }

    }
}

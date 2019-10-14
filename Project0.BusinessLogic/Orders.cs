using System;
using System.Collections.Generic;

namespace Project0.BusinessLogic
{
    /// <summary>
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

        /// <summary>
        /// List of products with their corresponding quantities that a customer ordered
        /// </summary>
        public List<Inventory> CustOrder { get; set; }

        /// <summary>
        /// Customer who placed the order
        /// </summary>
        public Customer Cust { get; set; }

        /// <summary>
        /// Location where order was placed
        /// </summary>
        public Location Stor { get; set; }

        /// <summary>
        /// Time and Date when order was placed
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Total of an order
        /// </summary>
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
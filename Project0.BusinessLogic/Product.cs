namespace Project0.BusinessLogic
{
    /// <summary>
    /// Product format of program
    /// UI interacts with this format of the Product
    /// </summary>
    public class Product
    {
        private decimal price;
        private string name;
        private string desc;
        private int productID;

        /// <summary>
        /// Price of the Product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Name of the Product
        /// </summary>
        public string Name { get; set; }
    }
}
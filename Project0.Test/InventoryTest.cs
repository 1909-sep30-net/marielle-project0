using Project0.BusinessLogic;
using Xunit;

namespace Project0.Test
{
    public class InventoryTest
    {
       

        public void InventoryShouldAddStock(int n)
        {
            try
            {
                new Inventory()
                {
                    Stock = n
                };
            }
            catch (InvalidStockException)
            {

                Assert.True(false);
            }
        }
    }
}
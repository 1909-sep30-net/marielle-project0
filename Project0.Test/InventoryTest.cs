using Project0.BusinessLogic;
using Xunit;

namespace Project0.Test
{
    public class InventoryTest
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void StockShouldAlwaysBePositive(int input)
        {
            try
            {
                new Inventory()
                {
                    Stock = input
                };
            }
            catch (InvalidStockException)
            {

                Assert.True(true);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]

        public void InventoryShouldAddPositiveStock(int n)
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
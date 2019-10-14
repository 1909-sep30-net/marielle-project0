using Project0.BusinessLogic;
using System.Collections.Generic;
using Xunit;

namespace Project0.Test
{
    public class OrderTest
    {
        [Fact]
        public void OrdersShouldReturnValidTotal()
        {
            Orders o = new Orders()
            {
                CustOrder = new List<Inventory>()
                {
                    new Inventory()
                    {
                      Prod =  new Product()
                        {
                            Price = 100
                        },
                       Stock = 1
                    },
                    new Inventory()
                    {
                      Prod =  new Product()
                        {
                            Price = 200
                        },
                       Stock = 1
                    }
                }
            };
            Assert.Equal(300, o.Total);
        }
    }
}
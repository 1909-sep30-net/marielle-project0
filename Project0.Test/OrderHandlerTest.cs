using Project0.BusinessLogic;
using Project0.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project0.Test
{
    public class OrderHandlerTest
    {
        [Fact]
        public void AddOrderShouldAddOrder()
        {
            Orders o = new Orders() 
            {
                Cust = new Customer(),
                Stor = new Location(),
                Date = DateTime.Now
            };
            OrderHandler oh = new OrderHandler();
            oh.AddOrder(o);
            Assert.NotNull(@object: DummyData.DummyOrder.DOrder);
            
        }
        [Fact]

        public void GetCustomerHistoryShouldGetHistory()
        {
            OrderHandler oh = new OrderHandler();
            Orders o = new Orders()
            {
                Cust = new Customer()
                {
                    FirstName = "Marielle",
                    LastName = "Nolasco"
                },
                Date = DateTime.Now
            };
            oh.AddOrder(o);
            oh.AddOrder(o);
            oh.AddOrder(o);
            List<Customer> cust = DummyData.DummyCustomer.DCustomer;
            foreach(Customer c in cust)
            {
                Assert.True(oh.GetCustomerHistory(c) != null);
            }


        }

        [Fact]
        public void GetLocationHistoryShouldReturnHistory()
        {
            OrderHandler oh = new OrderHandler();
            Orders o = new Orders()
            {
                Cust = new Customer(),
                Stor = new Location() { BranchName = "Flagship" },
                Date = DateTime.Now
            };
            oh.AddOrder(o);
            oh.AddOrder(o);
            oh.AddOrder(o);
            List<Location> location = DummyData.DummyLocations.DLocation;
            foreach (Location l in location)
            {
                Assert.True(oh.GetLocationHistory(l) != null);
            }
        }

        
    }
}

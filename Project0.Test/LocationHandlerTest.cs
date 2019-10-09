using Project0.BusinessLogic;
using Project0.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project0.Test
{
    public class LocationHandlerTest
    {
        [Fact]
        public void GetLocationsShouldReturnLocations()
        {
            LocationHandler lh = new LocationHandler();
            Assert.Equal<List<Location>>(DummyData.DummyLocations.DLocation, lh.GetLocations());
        }

        [Fact]
        public void InventoryShouldReturnInventory()
        {
            LocationHandler lh = new LocationHandler();
            foreach(Location l in DummyData.DummyLocations.DLocation)
            {
                Assert.NotNull(lh.GetInventory(l));
            }
        }

        [Fact]
        public void UpdateInventoryShouldUpdate()
        {
            LocationHandler lh = new LocationHandler();
            int origStock = DummyData.DummyLocations.DLocation[0].StoreInventory[0].Stock;
            lh.UpdateInventory(DummyData.DummyProduce.DInventory[0], DummyData.DummyLocations.DLocation[0]);
            int newStock = DummyData.DummyLocations.DLocation[0].StoreInventory[0].Stock;
            Assert.False(origStock == newStock);
        }
    }
}

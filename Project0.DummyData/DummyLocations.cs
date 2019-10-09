using Project0.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.DummyData
{
    public class DummyLocations
    {
        public static List<Location> DLocation = new List<Location>()
        {
            new Location()
            {
                BranchName = "Flagship",
                StoreAddress = new Address()
                {
                    Street = "123 Main",
                    City = "Arlington",
                    State = States.TX,
                    Zipcode = 70610
                },
                StoreInventory = DummyProduce.DInventory
            },
             new Location()
            {
                BranchName = "Branch1",
                StoreAddress = new Address()
                {
                    Street = "1 Branch",
                    City = "Arlington",
                    State = States.TX,
                    Zipcode = 70610
                },
                StoreInventory = DummyProduce.DInventory
            },
              new Location()
            {
                BranchName = "Branch2",
                StoreAddress = new Address()
                {
                    Street = "2 Branch",
                    City = "Arlington",
                    State = States.TX,
                    Zipcode = 70610
                },
                StoreInventory = DummyProduce.DInventory
            }
        };
    }
}

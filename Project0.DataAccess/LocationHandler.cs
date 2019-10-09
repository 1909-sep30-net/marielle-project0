using System;
using System.Collections.Generic;
using System.Text;
using Project0.BusinessLogic;
using Project0.DummyData;

namespace Project0.DataAccess
{
    public class LocationHandler
    {
        public List<string> GetNearestStore(Address custAddress)
        {
            //add code to get nearest store location
            return null;
        }

        public Address GetAddress(string branchname)
        {
            //code that gets address from database
            return null;

        }

        public Inventory GetInventory(string v)
        {
            //returns location inventory
            return null;
        }

        public List<Location> GetLocations()
        {
            return DummyLocations.DLocation;
        }

        public Inventory GetInventory(Location location)
        {
            foreach(Location l in DummyLocations.DLocation)
            {
                if (l == location) return l.StoreInventory;
            }
            return null;
        }

        public void UpdateInventory(Product product, int v, Location local)
        {
            //updates store inventory
            foreach (var l in DummyLocations.DLocation)
            {
                if(l == local)
                {
                    int i = 0;
                    foreach(Product p in local.StoreInventory.Products)
                    {
                        if(p == product)
                        {
                            local.StoreInventory.Stock[i] = local.StoreInventory.Stock[i] - v;
                        }
                        i++;
                    }
                }
            }
        }
    }
}

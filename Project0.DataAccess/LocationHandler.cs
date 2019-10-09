using System;
using System.Collections.Generic;
using System.Text;
using Project0.BusinessLogic;
using Project0.DummyData;

namespace Project0.DataAccess
{
    public class LocationHandler
    {
        //public List<string> GetNearestStore(Address custAddress)
        //{
        //    //add code to get nearest store location
        //    return null;
        //}

        //public Address GetAddress(string branchname)
        //{
        //    //code that gets address from database
        //    return null;

        //}

        public List<Location> GetLocations()
        {
            return DummyLocations.DLocation;
        }

        public List<Inventory> GetInventory(Location location)
        {
            foreach(Location l in DummyLocations.DLocation)
            {
                if (l.BranchName == location.BranchName) return l.StoreInventory;
            }
            return null;
        }

        public void UpdateInventory(Inventory inv, Location local)
        {
            //updates store inventory
            foreach (var l in DummyLocations.DLocation)
            {
                if(l.BranchName == local.BranchName)
                {
                    foreach(Inventory i in l.StoreInventory)
                    {
                        if(i.Prod.Name == inv.Prod.Name)
                        {
                            i.Stock = i.Stock - inv.Stock;
                        }
                    }
                }
            }
        }
    }
}

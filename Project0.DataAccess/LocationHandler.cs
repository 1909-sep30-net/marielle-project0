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
    }
}

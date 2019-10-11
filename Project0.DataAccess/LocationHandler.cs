using System;
using System.Collections.Generic;
using System.Text;
using Project0.BusinessLogic;
using Project0.DummyData;

namespace Project0.DataAccess
{/// <summary>
/// Handles data access to locations
/// </summary>
    public class LocationHandler
    {
       

        public List<Location> GetLocations()
        {
            return DummyLocations.DLocation;
        }
        public List<Inventory> GetInventory(Location location)
        {
            foreach (Location l in DummyLocations.DLocation)
            {
                if (l.BranchName == location.BranchName)
                {

                    return l.StoreInventory;
                }
            }
            return new List<Inventory>();
        }
        public List<Inventory> GetAvailInventory(Location location)
        {
            //gets inventory from location in db
            List<Inventory> availInventory = new List<Inventory>();
            foreach(Location l in DummyLocations.DLocation)
            {
                if (l.BranchName == location.BranchName)
                {
                    foreach(Inventory i in l.StoreInventory)
                    {
                        if (i.Stock > 0) availInventory.Add(i);
                    }
                    return availInventory;
                }
            }
            return availInventory;
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
                            if (inv.Stock > i.Stock) throw new InsufficientStockException("Stock Insufficient");
                            i.Stock = i.Stock - inv.Stock;
                        }
                    }
                }
            }
        }
    }
}

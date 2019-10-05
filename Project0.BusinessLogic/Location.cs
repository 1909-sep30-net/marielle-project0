using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.BusinessLogic
{
    public class Location
    {
        private Address storeAddress;
        private Inventory storeInventory;
        private int storeID;
        private string branchName;
        public Address StoreAddress { get; set; }
        public Inventory StoreInventory { get; set; }

        public string BranchName { get; set; }
    }
}

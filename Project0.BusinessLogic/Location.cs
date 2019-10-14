using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Project0.BusinessLogic
{/// <summary>
/// Location format of the program
/// UI interacts with this format of location
/// </summary>
    public class Location
    {
        private Address storeAddress;
        private List<Inventory> storeInventory;
        private int storeID;
        private string branchName;
        public Address StoreAddress { get; set; }
        public List<Inventory> StoreInventory { get; set; }

        public string BranchName
        {
            get => branchName;
            set
            {
                if (value == null) throw new InvalidLocationException("Invalid Branch Name");
                else if (Regex.Match(value, @"\s*[A-z0-9]+\s*").Success) branchName = value;
                else throw new InvalidLocationException("Invalid Branch Name");
            }
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Project0.DataAccess.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using BL = Project0.BusinessLogic;

namespace Project0.DataAccess
{/// <summary>
/// Converts the DB version of Locations and Inventory to Business Logic Version and vice versa
/// Handles data access to locations
/// </summary>
    public class LocationHandler
    {
        /// <summary>
        /// Method that returns available locations to order from
        /// </summary>
        /// <returns>List of Business Logic Locations</returns>
        public List<BL.Location> GetLocations()
        {
            using var context = GetContext();
            List<BL.Location> local = new List<BL.Location>();
            foreach (Location l in context.Location)
            {
                local.Add(ParseLocation(l));
            }
            return local;
        }

        /// <summary>
        /// Method that returns inventory of a certain branch
        /// </summary>
        /// <param name="location"></param>
        /// <returns>List of Business Logic Inventories</returns>
        public List<BL.Inventory> GetInventory(BL.Location location)
        {
            using var context = GetContext();
            List<Inventory> getInvent = context.Inventory.Where(i => i.Location.BranchName == location.BranchName).ToList();
            List<BL.Inventory> theInvent = new List<BL.Inventory>();
            foreach (Inventory i in getInvent)
            {
                theInvent.Add(ParseInventory(i));
            }
            return theInvent;
        }

        /// <summary>
        /// Method that returns available inventory of a certain branch
        /// </summary>
        /// <param name="location"></param>
        /// <returns>List of Business Logic Inventories</returns>
        public List<BL.Inventory> GetAvailInventory(BL.Location location)
        {
            //gets inventory from location in db
            using var context = GetContext();
            List<BL.Inventory> availInventory = new List<BL.Inventory>();
            List<Inventory> getInvent = context.Inventory.Where(i => i.Location.BranchName == location.BranchName).ToList();
            foreach (Inventory i in getInvent)
            {
                if (i.Stock > 0) availInventory.Add(ParseInventory(i));
            }
            return availInventory;
        }

        /// <summary>
        /// Method that updates the inventory in DB
        /// </summary>
        /// <param name="inv"></param>
        /// <param name="local"></param>
        public void UpdateInventory(BL.Inventory inv, BL.Location local)
        {
            //updates store inventory and also rejects orders with too high quantity
            using var context = GetContext();
            if (inv.Stock < 1) throw new BL.InvalidStockException("Quantity should be greater than 0");
            List<Inventory> tocheck = context.Inventory.Where(i => i.LocationId == context.Location.Single(l => l.BranchName == local.BranchName).LocationId).ToList();
            foreach (Inventory item in tocheck)
            {
                if (item.ProductId == context.Product.First(p => p.Name == inv.Prod.Name).ProductId)
                {
                    if (inv.Stock > item.Stock) throw new InsufficientStockException("Stock Insufficient");
                    item.Stock = item.Stock - inv.Stock;
                }
            }
            context.SaveChanges();
            Log.Information("Inventory Updated");
        }

        /// <summary>
        /// Method that converts Data Access Location object to a Business Logic Location object for interacting with UI
        /// </summary>
        /// <param name="location"></param>
        /// <returns>Business Logic Location</returns>
        internal BL.Location ParseLocation(Location location)
        {
            BL.Location local = new BL.Location()
            {
                BranchName = location.BranchName,
                StoreAddress = new BL.Address()
                {
                    Street = location.Street,
                    City = location.City,
                    State = (BL.States)Enum.Parse(typeof(BL.States), location.State, true),
                    Zipcode = int.Parse(location.ZipCode)
                },
                StoreInventory = GetParsedStoreInventory(location)
            };
            return local;
        }

        /// <summary>
        /// Method that converts Business Logic Location objects to Data Access Location objects for DB interaction
        /// </summary>
        /// <param name="location"></param>
        /// <returns>Data Access Location</returns>
        internal Location ParseLocation(BL.Location location)
        {
            Location local = new Location()
            {
                BranchName = location.BranchName,
                Street = location.StoreAddress.Street,
                City = location.StoreAddress.City,
                State = location.StoreAddress.State.ToString(),
                ZipCode = location.StoreAddress.Zipcode.ToString()
            };
            return local;
        }

        /// <summary>
        /// Method that converts Data Access Inventory List to Business Logic Inventory List for interacting with UI
        /// </summary>
        /// <param name="local"></param>
        /// <returns>Business Logic Inventory List</returns>
        public List<BL.Inventory> GetParsedStoreInventory(Location local)
        {
            using var context = GetContext();
            List<BL.Inventory> inv = new List<BL.Inventory>();
            List<Inventory> result = context.Inventory.Where(i => i.LocationId == local.LocationId).ToList();
            foreach (Inventory i in result)
            {
                inv.Add(ParseInventory(i));
            }
            return inv;
        }

        /// <summary>
        /// Method that converts Data Access Inventory object to a Business Logic Inventory object for interacting with UI
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns>Business Logic Inventory</returns>

        private BL.Inventory ParseInventory(Inventory inventory)
        {
            using var context = GetContext();
            BL.Inventory i = new BL.Inventory()
            {
                Stock = inventory.Stock,
                Prod = ParseProduct(context.Product.Single(p => p.ProductId == inventory.ProductId))
            };
            return i;
        }

        /// <summary>
        /// Method that converts Data Access Product object to a Business Logic Product object for interacting with UI
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Business Logic Product</returns>
        public BL.Product ParseProduct(Product product)
        {
            BL.Product p = new BL.Product()
            {
                Name = product.Name,
                Price = product.Price
            };
            return p;
        }

        /// <summary>
        /// Method that converts Business Logic Inventory Object to Data Access Inventory Object for DB interaction
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns>Data Access Inventory</returns>
        private Inventory ParseInventory(BL.Inventory inventory)
        {
            using var context = GetContext();
            Inventory i = new Inventory
            {
                Stock = inventory.Stock,
                Product = context.Product.First(p => p.Name == inventory.Prod.Name)
            };
            return i;
        }

        /// <summary>
        /// Method that sets up connection with db
        /// </summary>
        /// <returns>DBContext</returns>
        public Project0DBContext GetContext()
        {
            string connectionString = SecretConfiguration.ConnectionString;

            DbContextOptions<Project0DBContext> options = new DbContextOptionsBuilder<Project0DBContext>()
                .UseSqlServer(connectionString).UseLoggerFactory(SQLLogger.AppLoggerFactory).Options;

            return new Project0DBContext(options);
        }
    }
}
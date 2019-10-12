using System;
using System.Collections.Generic;
using System.Text;
using BL = Project0.BusinessLogic;
using Project0.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Project0.DataAccess
{/// <summary>
/// Handles data access to locations
/// </summary>
    public class LocationHandler
    {
        private readonly ILoggerFactory AppLoggerFactory;

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
        public List<BL.Inventory> GetInventory(BL.Location location)
        {
            using var context = GetContext();
            List<Inventory> getInvent = context.Inventory.Where(i => i.Location.BranchName == location.BranchName).ToList();
            List<BL.Inventory> theInvent = new List<BL.Inventory>();
            foreach(Inventory i in getInvent)
            {
                theInvent.Add(ParseInventory(i));
            }
            return theInvent;

        }
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

        public void UpdateInventory(BL.Inventory inv, BL.Location local)
        {
            //updates store inventory and also rejects orders with too high quantity
            using var context = GetContext();
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
        }

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

        public List<BL.Inventory> GetParsedStoreInventory(Location local)
        {
            using var context = GetContext();
            List<BL.Inventory> inv = new List<BL.Inventory>();
            List<Inventory> result =  context.Inventory.Where(i => i.LocationId == local.LocationId).ToList();
            foreach (Inventory i in result)
            {
                inv.Add(ParseInventory(i));
            }
            return inv;
        }

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

        public BL.Product ParseProduct(Product product)
        {
            BL.Product p = new BL.Product() 
            { 
                Name = product.Name,
                Price = product.Price
            };
            return p;
        }

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

        public Project0DBContext GetContext()
        {
            string connectionString = SecretConfiguration.ConnectionString;

            DbContextOptions<Project0DBContext> options = new DbContextOptionsBuilder<Project0DBContext>()
                .UseSqlServer(connectionString)
                .UseLoggerFactory(AppLoggerFactory).Options;

            return new Project0DBContext(options);
        }
    }
}


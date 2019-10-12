using System;
using System.Collections.Generic;
using BL = Project0.BusinessLogic;
using Project0.DummyData;
using Project0.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Project0.DataAccess
{
    /// <summary>
    /// Handles the orders of the customer
    /// Gets orders and updates inventory
    /// </summary>
    public class OrderHandler
    {
        private readonly ILoggerFactory AppLoggerFactory;

        public Project0DBContext GetContext()
        {
            string connectionString = SecretConfiguration.ConnectionString;

            DbContextOptions<Project0DBContext> options = new DbContextOptionsBuilder<Project0DBContext>()
                .UseSqlServer(connectionString)
                .UseLoggerFactory(AppLoggerFactory).Options;

            return new Project0DBContext(options);
        }
        public void AddOrder(BL.Orders o)
        {
            CustomerHandler ch = new CustomerHandler();
            LocationHandler lh = new LocationHandler();
            Orders order = new Orders()
            {
                Cust = ch.ParseCustomer(o.Cust),
                Location = lh.ParseLocation(o.Stor),
                CustOrder = ParseCustOrder(o.CustOrder),
                Total = o.Total,
                OrderDate = DateTime.Now
            };
            using var context = GetContext();
            context.Orders.Add(order);
            context.SaveChanges();

        }

        public List<BL.Orders> GetCustomerHistory(BL.Customer c)
        {
            //get customer order history
            using var context = GetContext();
            CustomerHandler ch = new CustomerHandler();
            List<BL.Orders> output = new List<BL.Orders>();
            List<Orders> dbOrd = context.Orders.Where(o => o.Cust == ch.ParseCustomer(c)).ToList();
            foreach (Orders o in dbOrd)
            {
                output.Add(ParseOrder(o));
            }
            return output;
        }

        public List<BL.Orders> GetLocationHistory(BL.Location l)
        {
            using var context = GetContext();
            List<BL.Orders> output = new List<BL.Orders>();
            List<Orders> dbOrd = context.Orders.Where(o => o.Location.BranchName == l.BranchName).ToList();
            foreach (Orders o in dbOrd)
            {
                output.Add(ParseOrder(o));
            }
            return output;
        }

        public void PrintOrderDetails(BL.Orders o)
        {
            Console.WriteLine("Order placed!");
            Console.WriteLine($"Customer Name: {o.Cust.FirstName} {o.Cust.LastName} \nBranchname: {o.Stor.BranchName}");
            foreach (BL.Inventory i in o.CustOrder)
            {
                Console.WriteLine($"Product: {i.Prod.Name} \n Price (per unit): {i.Prod.Price} \n Quantity: {i.Stock}");

            }
            Console.WriteLine($"Order Total: {o.Total}");

        }

        public ICollection<CustOrder> ParseCustOrder(List<BL.Inventory> custOrder)
        {
            ICollection<CustOrder> custOrd = new List<CustOrder>();
            foreach (BL.Inventory cu in custOrder)
            {
                custOrd.Add(
                    new CustOrder()
                    {
                        Product = new Product()
                        {
                            Name = cu.Prod.Name,
                            Price = cu.Prod.Price
                        },
                        Quantity = cu.Stock
                    }
                    );
            }
            return custOrd;
        }
        public BL.Orders ParseOrder(Orders o)
        {
            CustomerHandler ch = new CustomerHandler();
            LocationHandler lh = new LocationHandler();
            BL.Orders ord = new BL.Orders()
            {
                Date = o.OrderDate,
                Cust = ch.ParseCustomer(o.Cust),
                Stor = lh.ParseLocation(o.Location),
                CustOrder = ParseCustOrder(o.CustOrder),
                Total = o.Total,
            };
            return ord;
        }


        private List<BL.Inventory> ParseCustOrder(ICollection<CustOrder> custOrder)
        {
            List<BL.Inventory> custOrd = new List<BL.Inventory>();
            foreach (CustOrder cu in custOrder)
            {
                custOrd.Add(new BL.Inventory() { Prod = new BL.Product() { Name = cu.Product.Name, Price = cu.Product.Price }, Stock = cu.Quantity });
            }
            return custOrd;
        }


    }
}

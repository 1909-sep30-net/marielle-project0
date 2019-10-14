using Microsoft.EntityFrameworkCore;
using Project0.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using BL = Project0.BusinessLogic;

namespace Project0.DataAccess
{
    /// <summary>
    /// Handles the orders of the customer
    /// Gets orders and updates inventory
    /// Connects program to database
    /// Converts the DB versions of the Orders to the Business Logic Versions and Vice versa
    /// </summary>
    public class OrderHandler
    {
        /// <summary>
        /// Method that sets up connection with db
        /// </summary>
        /// <returns>DBContext</returns>
        public Project0DBContext GetContext()
        {
            string connectionString = SecretConfiguration.ConnectionString;

            DbContextOptions<Project0DBContext> options = new DbContextOptionsBuilder<Project0DBContext>()
                .UseSqlServer(connectionString)
                .UseLoggerFactory(SQLLogger.AppLoggerFactory).Options;

            return new Project0DBContext(options);
        }
        /// <summary>
        /// Method that adds order a customer placed on the DB
        /// </summary>
        /// <param name="o"></param>
        public void AddOrder(BL.Orders o)
        {
            using var context = GetContext();
            CustomerHandler ch = new CustomerHandler();
            LocationHandler lh = new LocationHandler();
            Orders order = new Orders()
            {
                Cust = context.Customer.First(c => c.FirstName == o.Cust.FirstName && c.LastName == o.Cust.LastName),
                Location = context.Location.First(l => l.BranchName == o.Stor.BranchName),
                CustOrder = ParseCustOrder(o.CustOrder),
                Total = o.Total,
                OrderDate = DateTime.Now
            };
            context.Orders.Add(order);
            context.SaveChanges();
        }
        /// <summary>
        /// Method that gets customer's order history based on their first and last name
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public List<BL.Orders> GetCustomerHistory(BL.Customer c)
        {
            //get customer order history
            using var context = GetContext();
            CustomerHandler ch = new CustomerHandler();
            List<BL.Orders> output = new List<BL.Orders>();
            List<Orders> dbOrd = context.Orders.Where(o => o.Cust.FirstName == c.FirstName && o.Cust.LastName == c.LastName).ToList();
            foreach (Orders o in dbOrd)
            {
                output.Add(ParseOrder(o));
            }
            return output;
        }
        /// <summary>
        /// Method that gets location's order history based on the branch name 
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Method that prints order details after placing an order
        /// </summary>
        /// <param name="o"></param>
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
        /// <summary>
        /// Method that converts Business Logic(BL) Inventory object (Customer Order) to a Data Access CustOrder object for interacting with db
        /// </summary>
        /// <param name="custOrder"></param>
        /// <returns>Data Access CustOrder Collection</returns>
        public ICollection<CustOrder> ParseCustOrder(List<BL.Inventory> custOrder)
        {
            ICollection<CustOrder> custOrd = new List<CustOrder>();
            using var context = GetContext();
            foreach (BL.Inventory cu in custOrder)
            {
                custOrd.Add(
                    new CustOrder()
                    {
                        ProductId = context.Product.Single(p => p.Name == cu.Prod.Name).ProductId,
                        Quantity = cu.Stock
                    }
                    );
            }
            return custOrd;
        }
        /// <summary>
        /// Method that converts Data Access Order objects to Business Logic Order Object for UI interaction
        /// </summary>
        /// <param name="o"></param>
        /// <returns>Business Logic Order</returns>
        public BL.Orders ParseOrder(Orders o)
        {
            using var context = GetContext();
            CustomerHandler ch = new CustomerHandler();
            LocationHandler lh = new LocationHandler();
            BL.Orders ord = new BL.Orders()
            {
                Date = o.OrderDate,
                Cust = ch.ParseCustomer(context.Customer.Single(c => c.CustId == o.CustId)),
                Stor = lh.ParseLocation(context.Location.Single(l => l.LocationId == o.LocationId)),
                CustOrder = ParseCustOrder(context.CustOrder.Where(c => c.OrderId == o.OrderId).ToList()),
                Total = o.Total,
            };
            return ord;
        }
        /// <summary>
        /// Method that transforms Data Access CustOrder Colection to a Business Logic Inventory List
        /// </summary>
        /// <param name="custOrder"></param>
        /// <returns>Business Logic Inventory List</returns>
        private List<BL.Inventory> ParseCustOrder(ICollection<CustOrder> custOrder)
        {
            using var context = GetContext();
            LocationHandler lh = new LocationHandler();
            List<BL.Inventory> custOrd = new List<BL.Inventory>();
            foreach (CustOrder cu in custOrder)
            {
                custOrd.Add(new BL.Inventory() { Prod = lh.ParseProduct(context.Product.Single(p => p.ProductId == cu.ProductId)), Stock = cu.Quantity });
            }
            return custOrd;
        }
    }
}
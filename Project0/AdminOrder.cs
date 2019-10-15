using Project0.BusinessLogic;
using Project0.DataAccess;
using Serilog;
using System;
using System.Collections.Generic;

namespace Project0.App
{
    /// <summary>
    /// UI for Order Operations
    /// </summary>
    public class AdminOrder
    {
        ///<summary>Main menu for Order Operations</summary>
        public void Menu()
        {
            Console.WriteLine("Welcome to Order UI! \n What would you like to do?");
            Console.WriteLine(" [1] Place Order \n [2] View Order History of Customer \n [3] View Order History of Location\n [4] Return to Main Menu \n [5] Exit");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    //code to add order
                    AddOrder();
                    break;

                case "2":
                    //code to view order history of customer
                    ViewCustomerOrderHistory();
                    break;

                case "3":
                    //code to view order history of location
                    ViewLocationOrderHistory();
                    break;

                case "4":
                    //go back to Main Menu
                    AdminMenu main = new AdminMenu();
                    main.Welcome();
                    break;

                case "5":
                    //go to exit
                    ExitMenu exit = new ExitMenu();
                    exit.Exit();
                    break;

                default:
                    //Error Handling
                    ErrorHandler err = new ErrorHandler();
                    err.InvalidInputMsg();
                    Menu();
                    break;
            }
        }

        ///<summary>Method to view history of a location by passing a business logic location object to data handler</summary>
        public void ViewLocationOrderHistory()
        {
            Location l = EnterLocationDetails();
            OrderHandler oh = new OrderHandler();
            List<Orders> history = oh.GetLocationHistory(l);
            if(history.Count > 0)
            {
                history = GetOrderPreference(history);
                Console.WriteLine($"{l.BranchName}'s Order History");
                PrintHistory(history);
            }
            else
            {
                Console.WriteLine($"{l.BranchName} has no order history. No orders have been placed in this branch yet");
            }
            
            Log.Information($"View Order History of {l.BranchName}");
            Menu();
        }

        ///<summary>Method to view customer history by passing business logic customer object to data handler</summary>
        public void ViewCustomerOrderHistory()
        {
            Customer c = EnterCustomerDetails();
            OrderHandler oh = new OrderHandler();
            List<Orders> history = oh.GetCustomerHistory(c);
            if (history.Count > 0)
            {
                history = GetOrderPreference(history);
                Console.WriteLine($"Customer {c.FirstName} {c.LastName}'s Order History");
                PrintHistory(history);
            }
            else
            {
                Console.WriteLine($"Customer {c.FirstName} {c.LastName} has no order history because they haven't placed any orders yet.");
            }
            Log.Information($"View Order History of {c.FirstName} {c.LastName}");
            Menu();
        }

        /// <summary>
        /// Method that prints Order History based on conditions inputted by user
        /// </summary>
        /// <param name="history"></param>
        public void PrintHistory(List<Orders> history)
        {
            foreach (Orders o in history)
            {
                Console.WriteLine($"Date and Time: {o.Date}");
                foreach (Inventory i in o.CustOrder)
                {
                    Console.WriteLine("  Product: " + i.Prod.Name + " \n  Quantity: " + i.Stock);
                }
                Console.WriteLine($" Total: {o.Total}");
            }
        }

        /// <summary>
        /// Method that gets sorting preference of the user for the order history
        /// </summary>
        /// <param name="history"></param>
        /// <returns></returns>
        private List<Orders> GetOrderPreference(List<Orders> history)
        {
            OrderHandler oh = new OrderHandler();
            do
            {
                Console.WriteLine("How would you like the order history to be ordered?");
                Console.WriteLine(" [1] Earliest First (Default) \n [2] Latest First \n [3] Cheapest First \n [4] Most Expensive First ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        history = oh.EarliestFirst(history);
                        return history;

                    case "2":
                        history = oh.LatestFirst(history);
                        return history;

                    case "3":
                        history = oh.CheapestFirst(history);
                        return history;

                    case "4":
                        history = oh.MostExpensiveFirst(history);
                        return history;

                    default:
                        Console.WriteLine("Invalid Input");
                        Log.Error("Invalid Input");
                        break;
                }
            } while (true);
        }

        ///<summary>
        ///Method to place order by passing business logic order object to data handler
        ///</summary>
        private void AddOrder()
        {
            OrderHandler oh = new OrderHandler();
            LocationHandler lh = new LocationHandler();
            Customer c = new Customer();
            Console.WriteLine("New Customer? \n Y^(YES) N^(NO))");
            string input = Console.ReadLine();

            switch (input)
            {
                case "Y":
                    AdminCustomer ac = new AdminCustomer();
                    c = ac.AddNewCustomer();
                    break;

                case "N":
                    c = EnterCustomerDetails();
                    break;

                default:
                    ErrorHandler err = new ErrorHandler();
                    err.InvalidInputMsg();
                    AddOrder();
                    break;
            }

            Location l = EnterLocationDetails();
            string choice;
            List<Inventory> custOrder = new List<Inventory>();
            do
            {
                Console.WriteLine("Choose Product to Order (Enter Index Number):");
                List<Inventory> availInvent = lh.GetAvailInventory(l);
                int j = 0;
                foreach (Inventory i in availInvent)
                {
                    Console.WriteLine("[" + j + "] " + " Name: " + i.Prod.Name + "\n Price: " + i.Prod.Price + "\n Remaining Stock: " + i.Stock);
                    j++;
                }
                input = Console.ReadLine();
                Console.WriteLine("Enter Quantity: ");
                string amount = Console.ReadLine();
                try
                {
                    lh.UpdateInventory(new Inventory() { Prod = availInvent[int.Parse(input)].Prod, Stock = int.Parse(amount) }, l);
                }
                catch (InsufficientStockException ex)
                {
                    Console.WriteLine(ex.Message);
                    choice = "";
                    Log.Error("Insufficient Stock Exception. User tried to buy products more than available inventory");
                    continue;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    choice = "";
                    Log.Error("Format Exception. User tried to input invalid format");
                    continue;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    choice = "";
                    Log.Error(ex.Message);
                    continue;
                }
                catch (InvalidStockException ex)
                {
                    Console.WriteLine(ex.Message);
                    choice = "";
                    Log.Error(ex.Message);
                    continue;
                }
                custOrder.Add(new Inventory() { Prod = availInvent[int.Parse(input)].Prod, Stock = int.Parse(amount) });
                do
                {
                    Console.WriteLine("Would you like to order another product? \n N^(NO) Y^(YES)");
                    choice = Console.ReadLine();
                } while (ErrorHandler.InvalidInput(choice));
            } while (choice != "N");
            Orders o = new Orders()
            {
                Cust = c,
                Stor = l,
                Date = DateTime.Now,
                CustOrder = custOrder
            };
            oh.AddOrder(o);
            oh.PrintOrderDetails(o);
            Log.Information("Order Added");
            Log.Information($"Order was made by customer {c.FirstName} {c.LastName} at {l.BranchName} store");
            Menu();
        }

        ///<summary>
        ///Method that returns a location based on user input
        ///The location is validated by taking valid locations via data handler classes and asking the user to choose among them
        /// </summary>
        private Location EnterLocationDetails()
        {
            Console.WriteLine("Choose Branch:");
            LocationHandler lh = new LocationHandler();
            List<Location> local = lh.GetLocations();
            int i = 0;
            foreach (Location l in local)
            {
                Console.WriteLine("[" + i + "] " + l.BranchName);
                i++;
            }
            string choice = Console.ReadLine();
            try
            {
                return local[int.Parse(choice)];
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                ErrorHandler err = new ErrorHandler();
                err.InvalidInputMsg();
                Log.Error(ex.Message);
                EnterLocationDetails();
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error(ex.Message);
                EnterLocationDetails();
            }
            return new Location();
        }

        ///<summary>
        ///Method that returns a customer based on user input
        /// The customer is validated by taking valid customers via data handler that match conditions given by the user and asking the user to choose among them
        ///</summary>
        private Customer EnterCustomerDetails()
        {
            string choice;
            try
            {
                AdminCustomer ac = new AdminCustomer();
                List<Customer> choices = ac.SearchCustomer();
                do
                {
                    Console.WriteLine("Choose customer ");
                    choice = Console.ReadLine();
                } while (ErrorHandler.InvalidIntInput(choice));

                return choices[int.Parse(choice)];
            }
            catch (CustomerException ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error(ex.Message);
                EnterCustomerDetails();
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error(ex.Message);
                EnterCustomerDetails();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error(ex.Message);
                EnterCustomerDetails();
            }
            catch (CustomerNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error(ex.Message);
                Menu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error(ex.Message);
                string input;
                do
                {
                    Console.WriteLine("Try Again? \n Y^(Yes) N^(No)");
                    input = Console.ReadLine();
                } while (ErrorHandler.InvalidInput(input));
                switch (input)
                {
                    case "Y":
                        EnterCustomerDetails();
                        break;

                    case "N":
                        Menu();
                        break;

                    default:
                        break;
                }
            }
            return new Customer();
        }
    }
}
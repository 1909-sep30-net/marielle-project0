using Project0.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Project0.BusinessLogic;

namespace Project0.App
{/// <summary>
/// Class that contains the signup menu
/// </summary>
    class SignUpMenu
    {
        public void SignupMenu()
        {
            //for new customers signing up
            CustomerHandler ch = new CustomerHandler();
            ErrorHandler err = new ErrorHandler();
            
            uname:
            Console.WriteLine("Enter Username: ");
            string username = Console.ReadLine();

            if (ch.CheckUserName(username))
            {
                goto uname;
            }

            pass:
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();

            if (err.VerifyPassword(password) == false)
            {
                err.InvalidInputMsg();
                goto pass;
            }

            name:
            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string lastName = Console.ReadLine();

            if(err.VerifyName(firstName, lastName) == false)
            {
                err.InvalidInputMsg();
                goto name;
            }

            addin:
            Console.WriteLine("Enter Address: ");
            Console.WriteLine("Street: ");
            string street = Console.ReadLine();
            Console.WriteLine("City: ");
            string city = Console.ReadLine();
            Console.WriteLine("State: ");
            string state = Console.ReadLine();
            Console.WriteLine("Zipcode: ");
            string zipcode = Console.ReadLine();

            if(err.VerifyAddress(street, city, state, zipcode) == false)
            {
                err.InvalidInputMsg();
                goto addin;
            }
            Address custAdd = new Address {
                Street = street,
                City = city,
                State = state,
                Zipcode = zipcode

            };
            ch.AddCustomer(firstName, lastName, username, password, custAdd);
            Customer c = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = username,
                CustAddress = custAdd
            };

            OrderMenu om = new OrderMenu();
            om.Ordermenu(c);
            

        }
    }
}

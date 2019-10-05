using System;
using System.Collections.Generic;
using System.Text;
using Project0.BusinessLogic;

namespace Project0.DataAccess
{
    public class CustomerHandler
    {
        public bool Verify(string username, string password)
        {
            //verify username and password
            return false;
        }

        

        public bool CheckUserName(string username)
        {
           ///<summary>
           ///Checks if username is being used
           /// </summary>
            return true;
        }

       

        public void AddCustomer(string firstName, string lastName, string username, string password, Address custAdd)
        {
            //code to add customer to database

        }
        public int GetCustomerID()
        {
            //code to get customer ID;
            return 0;
        }
        
    }
}

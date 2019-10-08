using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.App
{
    /// <summary>
    /// This handles input errors and before the data handling
    ///
    /// </summary>
    /// <remarks>
    /// need to add logging feature
    /// </remarks>
    class ErrorHandler
    {
        public void InvalidInputMsg()
        {
            //prints out invalid input message and brings user back to last menu
            Console.WriteLine("Invalid Input");
            
        }
        //public bool VerifyAddress(string street, string city, string state, string zipcode)
        //{
        //    ///<summary>
        //    ///Verify address format
        //    /// </summary>
        //    return false;
        //}

        //internal bool VerifyPassword(string password)
        //{
        //    switch (password)
        //    {
        //        case null:
        //            return false;
        //            break;
        //        case " ":
        //            return false;
        //            break;
        //        case "\n":
        //            return false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return true;
        //}

        //internal bool VerifyName(string firstName, string lastName)
        //{
        //    switch (firstName)
        //    {
        //        case null:
        //            return false;
        //            break;
        //        case " ":
        //            return false;
        //            break;
        //        case "":
        //            return false;
        //            break;
        //        case "\n":
        //            return false;
        //            break;
        //        default:
        //            break;
        //    }
        //    switch (lastName)
        //    {
        //        case null:
        //            return false;
        //            break;
        //        case " ":
        //            return false;
        //            break;
        //        case "":
        //            return false;
        //            break;
        //        case "\n":
        //            return false;
        //            break;
        //        default:
        //            break;
        //    }
        //    return true;
        //}
    }
}

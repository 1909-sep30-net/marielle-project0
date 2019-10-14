using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Project0.App
{
    /// <summary>
    /// This handles input errors and before the data handling
    ///
    /// </summary>

    class ErrorHandler
    {
        public void InvalidInputMsg()
        {
            //prints out invalid input message and brings user back to last menu
            Console.WriteLine("Invalid Input");
            
        }
        public static bool InvalidIntInput(string choice)
        {
            if (Regex.Match(choice, @"\s*\d\s*").Success) return false;
            Console.WriteLine("Invalid Input. Input must be integer");
            Log.Error("Invalid Input. Input must be integer");
            return true;
        }

        public static bool InvalidInput(string choice)
        {
            switch (choice)
            {
                case "Y":
                    return false;
                case "N":
                    return false;
                default:
                    Console.WriteLine("Invalid input.");
                    Log.Error("Invalid Input");
                    return true;
            }
        }

    }
}

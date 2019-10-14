using Serilog;
using System;
using System.Text.RegularExpressions;

namespace Project0.App
{
    /// <summary>
    /// This handles input errors and before the data handling
    ///
    /// </summary>

    internal class ErrorHandler
    {
        ///<summary> Prints out invalid input message</summary>
        public void InvalidInputMsg()
        {
            Console.WriteLine("Invalid Input");
        }

        ///<summary>Method that verifies if a user input is a valid int or not</summary>
        public static bool InvalidIntInput(string choice)
        {
            if (Regex.Match(choice, @"\s*\d\s*").Success) return false;
            Console.WriteLine("Invalid Input. Input must be integer");
            Log.Error("Invalid Input. Input must be integer");
            return true;
        }

        ///<summary>Method that verifies if a user input is a Y or N</summary>
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
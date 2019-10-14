using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.App
{/// <summary>
/// Exit option of program
/// </summary>
    class ExitMenu
    {
        /// <summary>
        /// Method that queries a user if it wants to exit
        /// </summary>
        public void Exit()
        {
            //exit application
            Console.WriteLine("Exit? \n Y^(Yes) N^(No)");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "N":
                    break;
                case "Y":
                    Log.Information("Exit Program");
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    Exit();
                    break;
            }

        }
    }
}

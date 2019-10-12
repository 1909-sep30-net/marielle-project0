using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project0.App;
using Project0.DataAccess.Entities;
using System;

namespace Project0
{
    class Program
    {
        private static readonly ILoggerFactory AppLoggerFactory;

        static void Main(string[] args)
        {
            
            AdminMenu begin = new AdminMenu();
            begin.Welcome();
        }
    }
}

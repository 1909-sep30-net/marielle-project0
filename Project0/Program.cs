using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project0.App;
using Project0.DataAccess.Entities;
using System;
using Serilog;

namespace Project0
{
    class Program
    {
        private static readonly ILoggerFactory AppLoggerFactory;

        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File(@"C:\revature\marielle-project0\Project0-Log\Log.txt").CreateLogger();
            AdminMenu begin = new AdminMenu();
            begin.Welcome();
        }
    }
}

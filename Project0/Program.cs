using Project0.App;
using Serilog;

namespace Project0
{
    internal class Program
    {
        /// <summary>
        /// Main Program that calls the head node that starts up the navigation throughout the program
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File(@"C:\revature\marielle-project0\Project0-Log\Log.txt").CreateLogger();
            Log.Information("Begin Program");
            AdminMenu begin = new AdminMenu();
            begin.Welcome();
        }
    }
}
using Microsoft.Extensions.Logging;

namespace Project0.DataAccess
{
    internal class SQLLogger
    {
        public static readonly ILoggerFactory AppLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter("Microsoft", LogLevel.Warning)
                .AddFilter("System", LogLevel.Warning)
                .AddConsole();
        }
        );
    }
}
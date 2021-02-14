using CoreWebApi.HostBuilders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CoreWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            ILogger<Program> logger = (ILogger<Program>)host.Services.GetService(typeof(ILogger<Program>));
            logger.LogInformation("Start Program");
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .AddConfiguration()
            .AddServices()
            .ConfigureLogging(logging =>
            {
                logging.SetMinimumLevel(LogLevel.Information);
                logging.AddEventLog(eventLogSettings =>
                {
                    eventLogSettings.SourceName = "CoreWebApiLogs";
                });
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                //webBuilder.UseKestrel();
                webBuilder.UseStartup<Startup>();
            });
    }
}

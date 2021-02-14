using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace CoreWebApi.HostBuilders
{
    public static class ConfigurationHostBuilderExtensions
    {
        public static IHostBuilder AddConfiguration(this IHostBuilder host)
        {
            return host.ConfigureAppConfiguration(c =>
            {
                c.AddJsonFile("databasesettings.json");
                c.AddEnvironmentVariables();
            });
        }
    }
}

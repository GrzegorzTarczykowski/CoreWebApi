using CoreWebApi.Services;
using CoreWebApi.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreWebApi.HostBuilders
{
    public static class ServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            return host.ConfigureServices(services =>
            {
                services.AddScoped<IOrderStatusService, OrderStatusService>();
            });
        }
    }
}

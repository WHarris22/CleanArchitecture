#nullable enable

using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Core.HealthChecks;
using CleanArchitecture.Core.StockMarkets;

namespace CleanArchitecture.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IHealthCheckService, HealthCheckService>();
            services.AddScoped<IStockMarketService, StockMarketService>();

            return services;
        }
    }
}

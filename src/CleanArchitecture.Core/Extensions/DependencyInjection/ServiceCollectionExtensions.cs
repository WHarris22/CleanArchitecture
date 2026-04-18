using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Core.HealthChecks;
using CleanArchitecture.Core.StockMarkets;

namespace CleanArchitecture.Core.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IHealthCheckService, HealthCheckService>();
            services.AddScoped<IStockMarketService, StockMarketService>();

            return services;
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Core.HealthChecks;
using CleanArchitecture.Core.StockMarkets;

namespace CleanArchitecture.Core.Extensions.DependencyInjection
{
    /// <summary>
    /// Provides extension methods for registering core services.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds core service registrations to the service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IHealthCheckService, HealthCheckService>();
            services.AddScoped<IStockMarketService, StockMarketService>();

            return services;
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure.Repository;

namespace CleanArchitecture.Infrastructure.Extensions.DependencyInjection
{
    /// <summary>
    /// Provides extension methods for registering infrastructure services.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds infrastructure service registrations to the service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<StockMarketContext>(options =>
                options.UseInMemoryDatabase("StockMarketDemo"));

            services.AddScoped<IStockQuoteRepository, StockQuoteRepository>();
            services.AddTransient<StockMarketSeeder>();

            return services;
        }
    }
}
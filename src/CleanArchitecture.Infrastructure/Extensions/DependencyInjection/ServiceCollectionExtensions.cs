#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure.Repository;

namespace CleanArchitecture.Infrastructure.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
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
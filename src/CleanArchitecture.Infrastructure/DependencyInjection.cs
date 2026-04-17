#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure.Repository;

namespace CleanArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<StockMarketContext>(options =>
                options.UseInMemoryDatabase("StockMarketDemo"));

            services.AddScoped<IStockQuoteRepository, StockQuoteRepository>();

            return services;
        }
    }
}

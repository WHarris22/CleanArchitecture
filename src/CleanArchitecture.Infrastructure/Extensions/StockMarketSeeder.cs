#nullable enable

using CleanArchitecture.Infrastructure.Repository;

namespace CleanArchitecture.Infrastructure.Extensions
{
    public class StockMarketSeeder
    {
        private readonly StockMarketContext _context;

        public StockMarketSeeder(StockMarketContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.EnsureSeedData();
        }
    }
}
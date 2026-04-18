using CleanArchitecture.Infrastructure.Repository;

namespace CleanArchitecture.Infrastructure.Extensions
{
    public class StockMarketSeeder(StockMarketContext context)
    {
        private readonly StockMarketContext _context = context;

        public void Seed()
        {
            _context.EnsureSeedData();
        }
    }
}
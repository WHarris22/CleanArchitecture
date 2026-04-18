using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;

namespace CleanArchitecture.Infrastructure.Repository
{
    internal class StockQuoteRepository(StockMarketContext context) : IStockQuoteRepository
    {
        private readonly StockMarketContext _context = context;

        public async Task<IEnumerable<StockQuote>> GetAllAsync()
        {
            return await _context.StockQuotes
                .AsNoTracking()
                .OrderBy(q => q.Symbol)
                .ToListAsync();
        }

        public async Task<StockQuote> GetBySymbolAsync(string symbol)
        {
            return await _context.StockQuotes
                .AsNoTracking()
                .FirstOrDefaultAsync(q => q.Symbol == symbol.ToUpperInvariant());
        }

        public async Task AddAsync(StockQuote quote)
        {
            await _context.StockQuotes.AddAsync(quote);
            await _context.SaveChangesAsync();
        }
    }
}

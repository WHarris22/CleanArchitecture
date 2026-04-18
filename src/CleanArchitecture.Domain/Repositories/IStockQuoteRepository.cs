using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Repositories
{
    public interface IStockQuoteRepository
    {
        Task<IEnumerable<StockQuote>> GetAllAsync();

        Task<StockQuote> GetBySymbolAsync(string symbol);

        Task AddAsync(StockQuote quote);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Utilities.Results;

namespace CleanArchitecture.Core.StockMarkets
{
    public interface IStockMarketService
    {
        Task<Result<IEnumerable<StockQuote>>> GetAllQuotesAsync();

        Task<Result<StockQuote>> GetQuoteBySymbolAsync(string symbol);

        Task<Result<StockQuote>> AddQuoteAsync(StockQuote quote);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Utilities.Results;

namespace CleanArchitecture.Core.StockMarkets
{
    /// <summary>
    /// Provides business operations for stock market quote retrieval and persistence.
    /// </summary>
    public interface IStockMarketService
    {
        /// <summary>
        /// Retrieves all available stock quotes.
        /// </summary>
        /// <returns>An asynchronous operation that returns a result containing a sequence of <see cref="StockQuote"/>.</returns>
        Task<Result<IEnumerable<StockQuote>>> GetAllQuotesAsync();

        /// <summary>
        /// Retrieves the stock quote for a specific symbol.
        /// </summary>
        /// <param name="symbol">The stock ticker symbol to look up.</param>
        /// <returns>An asynchronous operation that returns a result containing the requested <see cref="StockQuote"/>.</returns>
        Task<Result<StockQuote>> GetQuoteBySymbolAsync(string symbol);

        /// <summary>
        /// Adds a new stock quote to the market service.
        /// </summary>
        /// <param name="quote">The stock quote entity to add.</param>
        /// <returns>An asynchronous operation that returns the created <see cref="StockQuote"/> result.</returns>
        Task<Result<StockQuote>> AddQuoteAsync(StockQuote quote);
    }
}

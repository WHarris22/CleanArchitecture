using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Repositories
{
    /// <summary>
    /// Defines repository operations for managing stock quote entities.
    /// </summary>
    public interface IStockQuoteRepository
    {
        /// <summary>
        /// Retrieves all stored stock quotes.
        /// </summary>
        /// <returns>An asynchronous operation that returns the full set of <see cref="StockQuote"/> values.</returns>
        Task<IEnumerable<StockQuote>> GetAllAsync();

        /// <summary>
        /// Retrieves a single stock quote by its symbol.
        /// </summary>
        /// <param name="symbol">The stock ticker symbol to search for.</param>
        /// <returns>An asynchronous operation that returns the matching <see cref="StockQuote"/> if found, or null if not found.</returns>
        Task<StockQuote> GetBySymbolAsync(string symbol);

        /// <summary>
        /// Adds a new stock quote to the repository.
        /// </summary>
        /// <param name="quote">The stock quote entity to add.</param>
        /// <returns>An asynchronous operation that completes when the quote has been stored.</returns>
        Task AddAsync(StockQuote quote);
    }
}

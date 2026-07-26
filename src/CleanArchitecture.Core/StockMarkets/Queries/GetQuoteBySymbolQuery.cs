using CleanArchitecture.Core.Mediator;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Utilities.Results;

namespace CleanArchitecture.Core.StockMarkets.Queries
{
    /// <summary>
    /// Query to retrieve a stock quote by symbol.
    /// </summary>
    /// <remarks>
    /// Initialises a new instance of the <see cref="GetQuoteBySymbolQuery"/> class.
    /// </remarks>
    public class GetQuoteBySymbolQuery(string symbol) : IQuery<Result<StockQuote>>
    {
        /// <summary>
        /// Gets the stock symbol to retrieve.
        /// </summary>
        public string Symbol { get; } = symbol;
    }
}

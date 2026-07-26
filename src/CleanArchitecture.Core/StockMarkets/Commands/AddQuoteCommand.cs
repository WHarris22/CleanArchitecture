using CleanArchitecture.Core.Mediator;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Utilities.Results;

namespace CleanArchitecture.Core.StockMarkets.Commands
{
    /// <summary>
    /// Command to add a new stock quote.
    /// </summary>
    /// <remarks>
    /// Initialises a new instance of the <see cref="AddQuoteCommand"/> class.
    /// </remarks>
    public class AddQuoteCommand(string symbol,
        string companyName,
        decimal lastPrice,
        decimal changePercent) : ICommand<Result<StockQuote>>
    {
        /// <summary>
        /// Gets the stock symbol.
        /// </summary>
        public string Symbol { get; } = symbol;

        /// <summary>
        /// Gets the company name.
        /// </summary>
        public string CompanyName { get; } = companyName;

        /// <summary>
        /// Gets the stock price.
        /// </summary>
        public decimal LastPrice { get; } = lastPrice;

        /// <summary>
        /// Gets the change percentage.
        /// </summary>
        public decimal ChangePercent { get; } = changePercent;
    }
}

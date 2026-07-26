using CleanArchitecture.Core.Mediator;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Utilities.Results;

namespace CleanArchitecture.Core.StockMarkets.Commands
{
    /// <summary>
    /// Command to add a new stock quote.
    /// </summary>
    public class AddQuoteCommand : ICommand<Result<StockQuote>>
    {
        /// <summary>
        /// Gets the stock symbol.
        /// </summary>
        public string Symbol { get; }

        /// <summary>
        /// Gets the company name.
        /// </summary>
        public string CompanyName { get; }

        /// <summary>
        /// Gets the stock price.
        /// </summary>
        public decimal LastPrice { get; }

        /// <summary>
        /// Gets the change percentage.
        /// </summary>
        public decimal ChangePercent { get; }

        /// <summary>
        /// Initialises a new instance of the <see cref="AddQuoteCommand"/> class.
        /// </summary>
        public AddQuoteCommand(string symbol, string companyName, decimal lastPrice, decimal changePercent)
        {
            Symbol = symbol;
            CompanyName = companyName;
            LastPrice = lastPrice;
            ChangePercent = changePercent;
        }
    }
}

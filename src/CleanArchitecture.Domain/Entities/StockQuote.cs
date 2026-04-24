using System;
using CleanArchitecture.Utilities.Results;

namespace CleanArchitecture.Domain.Entities
{
    /// <summary>
    /// Represents a stock quote entity.
    /// </summary>
    public class StockQuote
    {
        /// <summary>
        /// Gets the database identifier for the stock quote.
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Gets the stock symbol.
        /// </summary>
        public string Symbol { get; private set; } = string.Empty;

        /// <summary>
        /// Gets the company name.
        /// </summary>
        public string CompanyName { get; private set; } = string.Empty;

        /// <summary>
        /// Gets the latest stock price.
        /// </summary>
        public decimal LastPrice { get; private set; }

        /// <summary>
        /// Gets the percentage change from the previous close.
        /// </summary>
        public decimal ChangePercent { get; private set; }

        /// <summary>
        /// Gets the UTC timestamp when the quote was last updated.
        /// </summary>
        public DateTime LastUpdated { get; private set; }

        /// <summary>
        /// Initializes a new instance of <see cref="StockQuote"/> for persistence.
        /// </summary>
        private StockQuote() { }

        /// <summary>
        /// Initializes a new instance of <see cref="StockQuote"/> with a full set of values.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="symbol">The stock ticker symbol.</param>
        /// <param name="companyName">The company name.</param>
        /// <param name="lastPrice">The latest price.</param>
        /// <param name="changePercent">The change percentage.</param>
        /// <param name="lastUpdated">The last updated timestamp.</param>
        public StockQuote(int id, string symbol, string companyName, decimal lastPrice, decimal changePercent, DateTime lastUpdated)
        {
            if (string.IsNullOrWhiteSpace(symbol))
                throw new ArgumentException("Symbol cannot be null or empty", nameof(symbol));
            if (string.IsNullOrWhiteSpace(companyName))
                throw new ArgumentException("CompanyName cannot be null or empty", nameof(companyName));
            if (lastPrice < 0m)
                throw new ArgumentException("LastPrice cannot be negative", nameof(lastPrice));

            ID = id;
            Symbol = symbol.ToUpperInvariant();
            CompanyName = companyName;
            LastPrice = lastPrice;
            ChangePercent = changePercent;
            LastUpdated = lastUpdated;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="StockQuote"/> with symbol, company, price, and status.
        /// </summary>
        /// <param name="symbol">The stock ticker symbol.</param>
        /// <param name="companyName">The company name.</param>
        /// <param name="lastPrice">The latest price.</param>
        /// <param name="changePercent">The change percentage.</param>
        /// <param name="lastUpdated">The last updated timestamp.</param>
        public StockQuote(string symbol, string companyName, decimal lastPrice, decimal changePercent, DateTime lastUpdated)
            : this(0, symbol, companyName, lastPrice, changePercent, lastUpdated)
        {
        }

        /// <summary>
        /// Updates the price and change percentage for the stock quote.
        /// </summary>
        /// <param name="newPrice">The new stock price.</param>
        /// <param name="newChangePercent">The new change percentage.</param>
        /// <returns>A <see cref="Result"/> indicating whether the update succeeded.</returns>
        public Result UpdatePrice(decimal newPrice, decimal newChangePercent)
        {
            if (newPrice < 0m)
                return Result.Invalid("Price must be positive");

            LastPrice = newPrice;
            ChangePercent = newChangePercent;
            LastUpdated = DateTime.UtcNow;
            return Result.Success();
        }
    }
}

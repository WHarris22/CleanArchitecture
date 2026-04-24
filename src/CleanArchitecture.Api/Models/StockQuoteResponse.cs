using System;

namespace CleanArchitecture.Api.Models
{
    /// <summary>
    /// Represents the response data for a stock quote.
    /// </summary>
    public sealed record StockQuoteResponse
    {
        /// <summary>
        /// Gets the stock symbol.
        /// </summary>
        public string Symbol { get; init; } = string.Empty;

        /// <summary>
        /// Gets the company name.
        /// </summary>
        public string CompanyName { get; init; } = string.Empty;

        /// <summary>
        /// Gets the latest stock price.
        /// </summary>
        public decimal LastPrice { get; init; }

        /// <summary>
        /// Gets the percentage change from the previous price.
        /// </summary>
        public decimal ChangePercent { get; init; }

        /// <summary>
        /// Gets the UTC timestamp when the quote was last updated.
        /// </summary>
        public DateTime LastUpdated { get; init; }
    }
}

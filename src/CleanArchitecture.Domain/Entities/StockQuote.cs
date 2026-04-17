#nullable enable

using System;
using CleanArchitecture.Utilities.Results;

namespace CleanArchitecture.Domain.Entities
{
    public class StockQuote
    {
        public int ID { get; private set; }

        public string Symbol { get; private set; } = string.Empty;

        public string CompanyName { get; private set; } = string.Empty;

        public decimal LastPrice { get; private set; }

        public decimal ChangePercent { get; private set; }

        public DateTime LastUpdated { get; private set; }

        private StockQuote() { }

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

        public StockQuote(string symbol, string companyName, decimal lastPrice, decimal changePercent, DateTime lastUpdated)
            : this(0, symbol, companyName, lastPrice, changePercent, lastUpdated)
        {
        }

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

using System;

namespace CleanArchitecture.Api.Models
{
    public sealed record StockQuoteResponse
    {
        public string Symbol { get; init; } = string.Empty;

        public string CompanyName { get; init; } = string.Empty;

        public decimal LastPrice { get; init; }

        public decimal ChangePercent { get; init; }

        public DateTime LastUpdated { get; init; }
    }
}

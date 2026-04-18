#nullable enable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Utilities.Results;

namespace CleanArchitecture.Core.StockMarkets
{
    public class StockMarketService(IStockQuoteRepository repository) : IStockMarketService
    {
        private readonly IStockQuoteRepository _repository = repository;

        public async Task<Result<IEnumerable<StockQuote>>> GetAllQuotesAsync()
        {
            try
            {
                var quotes = await _repository.GetAllAsync();
                return new Result<IEnumerable<StockQuote>>(ResultStatus.Success, quotes);
            }
            catch (Exception ex)
            {
                return new Result<IEnumerable<StockQuote>>(ResultStatus.InternalError, ex.Message);
            }
        }

        public async Task<Result<StockQuote>> GetQuoteBySymbolAsync(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol))
                return new Result<StockQuote>(ResultStatus.Invalid, "Symbol is required.");

            try
            {
                var quote = await _repository.GetBySymbolAsync(symbol.Trim());
                return quote is null
                    ? new Result<StockQuote>(ResultStatus.NotFound, "Stock quote not found.")
                    : new Result<StockQuote>(ResultStatus.Success, quote);
            }
            catch (Exception ex)
            {
                return new Result<StockQuote>(ResultStatus.InternalError, ex.Message);
            }
        }

        public async Task<Result<StockQuote>> AddQuoteAsync(StockQuote quote)
        {
            if (quote is null)
                return new Result<StockQuote>(ResultStatus.Invalid, "Quote must be provided.");

            try
            {
                await _repository.AddAsync(quote);
                return new Result<StockQuote>(ResultStatus.Created, quote);
            }
            catch (Exception ex)
            {
                return new Result<StockQuote>(ResultStatus.InternalError, ex.Message);
            }
        }
    }
}

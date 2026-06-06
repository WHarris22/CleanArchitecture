using System;
using System.Threading.Tasks;
using CleanArchitecture.Core.Mediator;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Utilities.Results;

namespace CleanArchitecture.Core.StockMarkets.Queries
{
    /// <summary>
    /// Handler for the GetQuoteBySymbolQuery.
    /// </summary>
    public class GetQuoteBySymbolQueryHandler : IQueryHandler<GetQuoteBySymbolQuery, Result<StockQuote>>
    {
        private readonly IStockQuoteRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetQuoteBySymbolQueryHandler"/> class.
        /// </summary>
        public GetQuoteBySymbolQueryHandler(IStockQuoteRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Handles the GetQuoteBySymbolQuery by retrieving the quote from the repository.
        /// </summary>
        public async Task<Result<StockQuote>> HandleAsync(GetQuoteBySymbolQuery query)
        {
            if (query == null)
                return new Result<StockQuote>(ResultStatus.Invalid, "Query is required.");

            if (string.IsNullOrWhiteSpace(query.Symbol))
                return new Result<StockQuote>(ResultStatus.Invalid, "Symbol is required.");

            try
            {
                var quote = await _repository.GetBySymbolAsync(query.Symbol.Trim());
                return quote is null
                    ? new Result<StockQuote>(ResultStatus.NotFound, "Stock quote not found.")
                    : new Result<StockQuote>(ResultStatus.Success, quote);
            }
            catch (Exception ex)
            {
                return new Result<StockQuote>(ResultStatus.InternalError, ex.Message);
            }
        }
    }
}

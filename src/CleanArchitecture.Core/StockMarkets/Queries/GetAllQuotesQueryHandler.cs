using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Core.Mediator;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Utilities.Results;

namespace CleanArchitecture.Core.StockMarkets.Queries
{
    /// <summary>
    /// Handler for the GetAllQuotesQuery.
    /// </summary>
    public class GetAllQuotesQueryHandler : IQueryHandler<GetAllQuotesQuery, Result<IEnumerable<StockQuote>>>
    {
        private readonly IStockQuoteRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllQuotesQueryHandler"/> class.
        /// </summary>
        public GetAllQuotesQueryHandler(IStockQuoteRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Handles the GetAllQuotesQuery by retrieving all quotes from the repository.
        /// </summary>
        public async Task<Result<IEnumerable<StockQuote>>> HandleAsync(GetAllQuotesQuery query)
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
    }
}

using System.Collections.Generic;
using CleanArchitecture.Core.Mediator;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Utilities.Results;

namespace CleanArchitecture.Core.StockMarkets.Queries
{
    /// <summary>
    /// Query to retrieve all stock quotes.
    /// </summary>
    public class GetAllQuotesQuery : IQuery<Result<IEnumerable<StockQuote>>>
    {
    }
}

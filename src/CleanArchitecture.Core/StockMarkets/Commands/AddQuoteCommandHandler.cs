using System;
using System.Threading.Tasks;
using CleanArchitecture.Core.Mediator;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Utilities.Results;

namespace CleanArchitecture.Core.StockMarkets.Commands
{
    /// <summary>
    /// Handler for the AddQuoteCommand.
    /// </summary>
    public class AddQuoteCommandHandler : ICommandHandler<AddQuoteCommand, Result<StockQuote>>
    {
        private readonly IStockQuoteRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddQuoteCommandHandler"/> class.
        /// </summary>
        public AddQuoteCommandHandler(IStockQuoteRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Handles the AddQuoteCommand by validating and persisting the quote.
        /// </summary>
        public async Task<Result<StockQuote>> HandleAsync(AddQuoteCommand command)
        {
            if (command == null)
                return new Result<StockQuote>(ResultStatus.Invalid, "Command is required.");

            if (string.IsNullOrWhiteSpace(command.Symbol))
                return new Result<StockQuote>(ResultStatus.Invalid, "Symbol is required.");

            if (string.IsNullOrWhiteSpace(command.CompanyName))
                return new Result<StockQuote>(ResultStatus.Invalid, "Company name is required.");

            if (command.LastPrice < 0m)
                return new Result<StockQuote>(ResultStatus.Invalid, "Price must be non-negative.");

            try
            {
                var quote = new StockQuote(
                    command.Symbol,
                    command.CompanyName,
                    command.LastPrice,
                    command.ChangePercent,
                    DateTime.UtcNow);

                await _repository.AddAsync(quote);
                return new Result<StockQuote>(ResultStatus.Created, quote);
            }
            catch (ArgumentException ex)
            {
                return new Result<StockQuote>(ResultStatus.Invalid, ex.Message);
            }
            catch (Exception ex)
            {
                return new Result<StockQuote>(ResultStatus.InternalError, ex.Message);
            }
        }
    }
}

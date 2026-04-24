using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Api.Models;
using CleanArchitecture.Core.StockMarkets;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Utilities.Results;

namespace CleanArchitecture.Api.Controllers
{
    /// <summary>
    /// Exposes stock quote API endpoints.
    /// </summary>
    /// <param name="stockMarketService">The stock market service used to handle quote operations.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class StockQuotesController(IStockMarketService stockMarketService) : ControllerBase
    {
        private readonly IStockMarketService _stockMarketService = stockMarketService;

        /// <summary>
        /// Retrieves all stock quotes.
        /// </summary>
        /// <returns>Returns a list of <see cref="StockQuoteResponse"/> objects.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockQuoteResponse>>> Get()
        {
            var result = await _stockMarketService.GetAllQuotesAsync();
            return result.StatusCode == ResultStatus.Success
                ? Ok(result.Content!.Select(ToResponse))
                : Problem(detail: string.Join("; ", result.Messages ?? new[] { "Unable to read stock quotes." }), statusCode: 500);
        }

        /// <summary>
        /// Retrieves a single stock quote by symbol.
        /// </summary>
        /// <param name="symbol">The symbol of the requested stock quote.</param>
        /// <returns>Returns the matching <see cref="StockQuoteResponse"/> or an appropriate error result.</returns>
        [HttpGet("{symbol}")]
        public async Task<ActionResult<StockQuoteResponse>> Get(string symbol)
        {
            var result = await _stockMarketService.GetQuoteBySymbolAsync(symbol);
            return result.StatusCode switch
            {
                ResultStatus.Success => Ok(ToResponse(result.Content!)),
                ResultStatus.NotFound => NotFound(result.Messages ?? new[] { "Stock quote not found." }),
                ResultStatus.Invalid => BadRequest(result.Messages),
                _ => Problem(detail: string.Join("; ", result.Messages ?? new[] { "Unable to read stock quote." }), statusCode: 500)
            };
        }

        /// <summary>
        /// Creates a new stock quote.
        /// </summary>
        /// <param name="request">The request payload containing stock quote details.</param>
        /// <returns>Returns the created <see cref="StockQuoteResponse"/> or a validation/error response.</returns>
        [HttpPost]
        public async Task<ActionResult<StockQuoteResponse>> Post([FromBody] StockQuoteRequest request)
        {
            if (request is null)
                return BadRequest("Request body is required.");

            try
            {
                var quote = new StockQuote(
                    request.Symbol,
                    request.CompanyName,
                    request.LastPrice,
                    request.ChangePercent,
                    DateTime.UtcNow);

                var result = await _stockMarketService.AddQuoteAsync(quote);
                return result.StatusCode switch
                {
                    ResultStatus.Created => CreatedAtAction(nameof(Get), new { symbol = result.Content!.Symbol }, ToResponse(result.Content)),
                    ResultStatus.Invalid => BadRequest(result.Messages),
                    _ => Problem(detail: string.Join("; ", result.Messages ?? new[] { "Unable to add stock quote." }), statusCode: 500)
                };
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Maps entity data to API response DTO.
        /// </summary>
        /// <param name="quote">The entity to map.</param>
        /// <returns>The created <see cref="StockQuoteResponse"/>.</returns>
        private static StockQuoteResponse ToResponse(StockQuote quote)
        {
            return new StockQuoteResponse
            {
                Symbol = quote.Symbol,
                CompanyName = quote.CompanyName,
                LastPrice = quote.LastPrice,
                ChangePercent = quote.ChangePercent,
                LastUpdated = quote.LastUpdated
            };
        }
    }
}

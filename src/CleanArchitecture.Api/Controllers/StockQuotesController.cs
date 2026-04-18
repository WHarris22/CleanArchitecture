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
    [Route("api/[controller]")]
    [ApiController]
    public class StockQuotesController(IStockMarketService stockMarketService) : ControllerBase
    {
        private readonly IStockMarketService _stockMarketService = stockMarketService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockQuoteResponse>>> Get()
        {
            var result = await _stockMarketService.GetAllQuotesAsync();
            return result.StatusCode == ResultStatus.Success
                ? Ok(result.Content!.Select(ToResponse))
                : Problem(detail: string.Join("; ", result.Messages ?? new[] { "Unable to read stock quotes." }), statusCode: 500);
        }

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

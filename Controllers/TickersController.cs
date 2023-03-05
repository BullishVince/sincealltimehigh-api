using Microsoft.AspNetCore.Mvc;
using SinceAllTimeHigh.Clients.Models.YahooFinanceClient;
using SinceAllTimeHigh.Config.Models;
using SinceAllTimeHigh.Services;
using static SinceAllTimeHigh.Constants;

namespace SinceAllTimeHigh.Controllers;

[ApiController]
[Route("[controller]")]
public class TickersController : ControllerBase
{
    private readonly ILogger<TickersController> _logger;
    private readonly ITickersService _tickersService;
    public TickersController(
        ILogger<TickersController> logger,
        ITickersService tickersService)
    {
        _logger = logger;
        _tickersService = tickersService;
    }
    [HttpGet]
    public async Task<IMessage<IEnumerable<string>>> GetTickers([FromQuery] string? exchanges)
    {
        var result = await _tickersService.GetAllTickersForAnExchange(exchanges);
        return ResponseMessage<IEnumerable<string>>.Success(ResponseInformation.Success, result);
    }

    [HttpGet("{ticker}")]
    public async Task<IMessage<YahooFinancePrice>> GetLatestDailyPriceForTicker([FromRoute] string ticker)
    {
        var result = await _tickersService.GetLatestDailyPriceForTicker(ticker);
        return ResponseMessage<YahooFinancePrice>.Success(ResponseInformation.Success, result);
    }
}

using Microsoft.AspNetCore.Mvc;
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
        var tickers = await _tickersService.GetAllTickersForAnExchange(exchanges);

        return ResponseMessage<IEnumerable<string>>.Success(ResponseInformation.Success, tickers);
    }
}

using Microsoft.AspNetCore.Mvc;
using SinceAllTimeHigh.Config.Models;
using SinceAllTimeHigh.Services;

namespace SinceAllTimeHigh.Controllers;

[ApiController]
[Route("[controller]")]
public class DiscoverController : ControllerBase
{
    private ITickersService _tickersService;

    private readonly ILogger<DiscoverController> _logger;

    public DiscoverController(ILogger<DiscoverController> logger, ITickersService tickersService)
    {
        _logger = logger;
        _tickersService = tickersService;
    }

    [HttpGet]
    public IMessage<string> Get()
    {
        
        return ResponseMessage<string>.Success("", null);
    }
}

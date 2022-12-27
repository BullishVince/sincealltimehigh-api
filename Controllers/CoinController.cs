using Microsoft.AspNetCore.Mvc;
using SinceAllTimeHigh.Infrastructure.Models;

namespace SinceAllTimeHigh.Controllers;

[ApiController]
[Route("[controller]")]
public class CoinController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<CoinController> _logger;

    public CoinController(ILogger<CoinController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{coinName}")]
    public IMessage Get([FromRoute] string coinName)
    {
        return new ResponseMessage.Success();
    }
}

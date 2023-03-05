using Microsoft.AspNetCore.Mvc;
using SinceAllTimeHigh.Config.Models;

namespace SinceAllTimeHigh.Controllers;

[ApiController]
[Route("[controller]")]
public class ForexController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<ForexController> _logger;

    public ForexController(ILogger<ForexController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{coinName}")]
    public IMessage<string> Get([FromRoute] string coinName)
    {
        return ResponseMessage<string>.Success(coinName, null);
    }
}

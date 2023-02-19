using Microsoft.AspNetCore.Mvc;
using SinceAllTimeHigh.Infrastructure.Models;

namespace SinceAllTimeHigh.Controllers;

[ApiController]
[Route("[controller]")]
public class AssetController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<AssetController> _logger;

    public AssetController(ILogger<AssetController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{coinName}")]
    public IMessage<string> Get([FromRoute] string coinName)
    {
        return ResponseMessage<string>.Success(coinName, null);
    }
}

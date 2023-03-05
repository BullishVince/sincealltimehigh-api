using Microsoft.AspNetCore.Mvc;
using SinceAllTimeHigh.Config.Models;

namespace SinceAllTimeHigh.Controllers;

[ApiController]
[Route("[controller]")]
public class TrendingController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<TrendingController> _logger;

    public TrendingController(ILogger<TrendingController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IMessage<string> Get()
    {
        return ResponseMessage<string>.Success("", null);
    }
}

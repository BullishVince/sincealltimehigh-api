using Microsoft.AspNetCore.Mvc;
using SinceAllTimeHigh.Config.Models;

namespace SinceAllTimeHigh.Controllers;

[ApiController]
[Route("[controller]")]
public class ExchangesController : ControllerBase
{
    private readonly ILogger<ExchangesController> _logger;
    public ExchangesController(ILogger<ExchangesController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public IMessage<string> GetExchanges()
    {
        return ResponseMessage<string>.Success(string.Empty, string.Empty);
    }
}

using SinceAllTimeHigh.Clients;
using SinceAllTimeHigh.Config.Models;

namespace SinceAllTimeHigh.Services;
public interface ITickersService {
public Task<IEnumerable<string>> GetAllTickersForAnExchange(string exchange);
}

public class TickersService : ITickersService
{
    public IDumbStockApiClient _client { get; set; }
    public TickersService(IDumbStockApiClient client)
    {
        _client = client;
    }
    public async Task<IEnumerable<string>> GetAllTickersForAnExchange(string exchange) => await _client.GetAllTickersForAnExchange(exchange);
}
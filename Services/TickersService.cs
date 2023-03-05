using SinceAllTimeHigh.Clients;
using SinceAllTimeHigh.Clients.Models.YahooFinanceClient;

namespace SinceAllTimeHigh.Services;
public interface ITickersService {
public Task<IEnumerable<string>> GetAllTickersForAnExchange(string exchange);
public Task<YahooFinancePrice> GetLatestDailyPriceForTicker(string ticker);
}

public class TickersService : ITickersService
{
    public IDumbStockApiClient _dumbStockApiClient { get; set; }
    public IYahooFinanceClient _yahooFinanceClient { get; set; }
    public TickersService(
        IDumbStockApiClient dumbStockApiClient,
        IYahooFinanceClient yahooFinanceClient)
    {
        _dumbStockApiClient = dumbStockApiClient;
        _yahooFinanceClient = yahooFinanceClient;
    }
    public async Task<IEnumerable<string>> GetAllTickersForAnExchange(string exchange) => await _dumbStockApiClient.GetAllTickersForAnExchange(exchange);
    public async Task<YahooFinancePrice> GetLatestDailyPriceForTicker(string ticker) => await _yahooFinanceClient.GetLatestDailyPriceForTicker(ticker);
}
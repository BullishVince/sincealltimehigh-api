using System.Text.Json;
using SinceAllTimeHigh.Clients.Models.DumbStockApiClient;

namespace SinceAllTimeHigh.Clients;
public interface IDumbStockApiClient {
    public Task<IEnumerable<string>> GetAllTickersForAnExchange(string exchange);
}

public class DumbStockApiClient : IDumbStockApiClient
{
    private HttpClient _httpClient { get; set; }
    public DumbStockApiClient(string baseAddress)
    {
        _httpClient = new HttpClient(){
            BaseAddress = new Uri(baseAddress)
        };
    }
    public async Task<IEnumerable<string>> GetAllTickersForAnExchange(string exchange)
    {
        var url = $"{_httpClient.BaseAddress}stock";
        if (exchange.Length > 0) {
            url += "?exchange=" + exchange;
        }
        
        var response = await _httpClient.GetAsync(url);
        var result = await response.Content.ReadFromJsonAsync<IEnumerable<Ticker>>(new JsonSerializerOptions{
            PropertyNameCaseInsensitive = true
        }) ?? new List<Ticker>().AsEnumerable();

        return result.Select(x => x.TickerSymbol);
    }
}
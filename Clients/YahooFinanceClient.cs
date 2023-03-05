using System.Text.Json;
using SinceAllTimeHigh.Clients.Models.YahooFinanceClient;

namespace SinceAllTimeHigh.Clients;
public interface IYahooFinanceClient {
    public Task<YahooFinancePrice> GetLatestDailyPriceForTicker(string exchange);
}

public class YahooFinanceClient : IYahooFinanceClient
{
    private HttpClient _httpClient { get; set; }
    public YahooFinanceClient(string baseAddress)
    {
        _httpClient = new HttpClient(){
            BaseAddress = new Uri(baseAddress)
        };
    }
    // public async Task<IEnumerable<string>> GetHistoricalDataForTicker(string ticker)
    // {
    //     //https://query1.finance.yahoo.com/v7/finance/download/WSR?period1=1282780800&period2=1677888000&interval=1d&events=history&includeAdjustedClose=true
    //     var url = $"{_httpClient.BaseAddress}finance/download/{ticker}?period1=1282780800&period2=1677888000&interval=1d&events=history&includeAdjustedClose=true";
        
    //     var response = await _httpClient.GetAsync(url);
    //     var result = await response.Content.ReadFromJsonAsync<IEnumerable<Ticker>>(new JsonSerializerOptions{
    //         PropertyNameCaseInsensitive = true
    //     }) ?? new List<Ticker>().AsEnumerable();

    //     return result.Select(x => x.TickerSymbol);
    // }

    public async Task<YahooFinancePrice> GetLatestDailyPriceForTicker(string ticker)
    {
        //https://query1.finance.yahoo.com/v7/finance/download/WSR?period1=1282780800&period2=1677888000&interval=1d&events=history&includeAdjustedClose=true
        var url = $"{_httpClient.BaseAddress}finance/download/{ticker}?interval=1d";
        
        var response = await _httpClient.GetAsync(url);
        var result = await response.Content.ReadFromJsonAsync<YahooFinancePrice>(new JsonSerializerOptions{
            PropertyNameCaseInsensitive = true
        });

        return result;
    }
}
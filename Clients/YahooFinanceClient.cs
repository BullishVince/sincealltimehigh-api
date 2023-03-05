using SinceAllTimeHigh.Clients.Models.YahooFinanceClient;
using CsvHelper;
using System.Net.Http.Headers;
using System.Globalization;

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
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/csv"));
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
        var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}finance/download/{ticker}?interval=1d");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"HTTP request failed with status code {response.StatusCode}");
        }

        var stream = await response.Content.ReadAsStreamAsync();

        using (var reader = new StreamReader(stream))
        {
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csvReader.GetRecords<YahooFinancePrice>().Select(x => new YahooFinancePrice(){
                    AdjustedClose = x.AdjustedClose,
                    Close = x.Close,
                    Date = x.Date,
                    High = x.High,
                    Low = x.Low,
                    Open = x.Open,
                    Ticker = ticker,
                    Volume = x.Volume
                }).ToList();
                return records.FirstOrDefault();
            }
        }
        return null;
    }
}
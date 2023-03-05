using System.Text.Json.Serialization;

namespace SinceAllTimeHigh.Clients.Models.DumbStockApiClient;
public class Ticker {
    [JsonPropertyName("ticker")]
    public string TickerSymbol { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("is_etf")]
    public bool? IsETF { get; set; }
    [JsonPropertyName("exchange")]
    public string Exchange { get; set; }
}
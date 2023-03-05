using CsvHelper.Configuration.Attributes;

namespace SinceAllTimeHigh.Clients.Models.YahooFinanceClient;
public class YahooFinancePrice {
//     Date,Open,High,Low,Close,Adj Close,Volume
// 2023-03-03,9.400000,9.760000,9.250000,9.540000,9.540000,3042800

    public DateTime Date { get; set; }
    public decimal Open { get; set; }
    public decimal High { get; set; }
    public decimal Low { get; set; }
    public decimal Close { get; set; }
    [Name("Adj Close")]
    public decimal AdjustedClose { get; set; }
    public decimal Volume { get; set; }
    [Ignore]
    public string Ticker { get; set; }
}
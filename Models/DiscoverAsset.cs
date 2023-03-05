namespace SinceAllTimeHigh.Models;
public class DiscoverAsset {
    //https://companiesmarketcap.com/img/company-logos/256/MSFT.webp <-- Here we can fetch the logo for a company
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal AthPrice { get; set; }
    public decimal PercentageToAth { get; set; }
    public decimal PercentageSinceAtl { get; set; }

}
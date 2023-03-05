using SinceAllTimeHigh.Clients;
using SinceAllTimeHigh.Services;
// using SinceAllTimeHigh.Domain.Repository;

namespace SinceAllTimeHigh.Config;
public static class ServiceBootstrapper {
    public static IServiceCollection AddServices(this IServiceCollection services, ApplicationSettings settings) {
        //Inject ApplicationSettings
        services.AddSingleton<ApplicationSettings>(settings);

        //Add transient services below + services which needs mandatory parameters in constructor
        //services.AddTransient<IDummyAdapter>(s => new DummyAdapter(string.Empty));
        services.AddTransient<ITickersService, TickersService>();
        
        //Add scoped service below
        // services.AddScoped<IAssetPairRepository, AssetPairRepository>();
        services.AddScoped<IDumbStockApiClient>(x => new DumbStockApiClient(settings.DumbStockApiUrl));
        services.AddScoped<IYahooFinanceClient>(x => new YahooFinanceClient(settings.YahooFinanceUrl));
        
        return services;
    }
}
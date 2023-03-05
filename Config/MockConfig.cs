using Serilog;
using SinceAllTimeHigh.Config.Mocks;

namespace SinceAllTimeHigh.Config;
public static class MockConfig {
    public static IServiceCollection AddMocks(this IServiceCollection services, ApplicationSettings applicationSettings) {
    if (applicationSettings.UseMocks) {
        Log.Information("Initiating mocks");

        //Add mocks below
        services.AddSingleton(DumbStockApiClientMock.Get());
    }
    return services;
    }
}
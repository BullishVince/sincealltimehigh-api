using Bogus;
using FakeItEasy;
using SinceAllTimeHigh.Clients;

namespace SinceAllTimeHigh.Config.Mocks;
public static class DumbStockApiClientMock {
    public static IDumbStockApiClient Get() {
        var faker = new Faker();
        var fakeService = A.Fake<IDumbStockApiClient>();
        A.CallTo(() => fakeService.GetAllTickersForAnExchange(A<string>._))
            .ReturnsLazily(() => new List<string> { "NIO","MSFT","TSLA","AAPL"});

        return fakeService;
    }
}
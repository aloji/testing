using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace TodoApi.Tests.WeatherForecastControllerTests
{
    [Collection(nameof(TodoApiCollection))]
    public class GetTests
    {
        readonly IForecastService iForecastService;
        readonly HttpClient httpClient;

        public GetTests(TodoApiMockWebApplicationFactory factory)
        {
            _ = factory ?? throw new ArgumentNullException(nameof(factory));
            factory.Mocks.Clear();

            this.iForecastService = factory.Mocks.Get<IForecastService>(); 
            this.httpClient = factory.CreateDefaultClient();
        }

        [Fact]
        public async Task Should_Return_Ok()
        {
            var expected = new List<WeatherForecast> 
            {
                new WeatherForecast
                {
                    Date = DateTime.UtcNow,
                    Summary = "Summary Test",
                    TemperatureC = 20
                }
            };
            this.iForecastService.Get().Returns(expected);

            var actual = await httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("/WeatherForecast");

            Assert.NotNull(actual);
            Assert.Equal(expected.Count, actual.Count());
            Assert.Equal(expected.First().Date, actual.First().Date);
            Assert.Equal(expected.First().Summary, actual.First().Summary);
            Assert.Equal(expected.First().TemperatureC, actual.First().TemperatureC);
        }
    }
}

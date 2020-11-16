using System.Collections.Generic;

namespace TodoApi.Tests.Mocks.Options
{
    public class ForecastServiceOptions
    {
        public const string SectionKey = "ForecastServiceOptions";
        public IEnumerable<WeatherForecast> Get { get; set; }
    }
}

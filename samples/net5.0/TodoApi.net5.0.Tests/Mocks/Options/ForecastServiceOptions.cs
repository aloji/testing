using System.Collections.Generic;
using TodoApi.net5._0;

namespace TodoApi.Tests.net5._0.Mocks.Options
{
    public class ForecastServiceOptions
    {
        public const string SectionKey = "ForecastServiceOptions";
        public IEnumerable<WeatherForecast> Get { get; set; }
    }
}

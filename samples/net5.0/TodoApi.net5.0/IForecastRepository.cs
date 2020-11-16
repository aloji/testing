using System.Collections.Generic;

namespace TodoApi.net5._0
{
    public interface IForecastRepository
    {
        IEnumerable<WeatherForecast> Get();
    }
}

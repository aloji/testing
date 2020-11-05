using System.Collections.Generic;

namespace TodoApi
{
    public interface IForecastService
    {
        IEnumerable<WeatherForecast> Get();
    }
}

using System.Collections.Generic;

namespace TodoApi
{
    public interface IForecastRepository
    {
        IEnumerable<WeatherForecast> Get();
    }
}

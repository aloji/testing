using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace TodoApi.net5._0.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IForecastRepository iForecastrepository;

        public WeatherForecastController(IForecastRepository iForecastrepository)
        {
            this.iForecastrepository = iForecastrepository
                ?? throw new ArgumentNullException(nameof(iForecastrepository));
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return this.iForecastrepository.Get();
        }
    }
}

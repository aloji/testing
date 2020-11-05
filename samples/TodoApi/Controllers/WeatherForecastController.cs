using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IForecastService iForecastService;

        public WeatherForecastController(IForecastService iForecastService)
        {
            this.iForecastService = iForecastService 
                ?? throw new ArgumentNullException(nameof(iForecastService));
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return this.iForecastService.Get();
        }
    }
}

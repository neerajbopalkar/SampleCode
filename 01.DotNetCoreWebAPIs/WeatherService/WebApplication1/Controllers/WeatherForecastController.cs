using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            //URI - http://localhost:53143/weatherforecast
            _logger.LogInformation("In Get method");

            return _weatherService.GetWeatherList();          
          
        }

        private IEnumerable<WeatherForecast> GetWeatherList()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// Method using status codes
        /// return Ok(); // Http status code 200
        ///return Created(); // Http status code 201
        ///return NoContent(); // Http status code 204
        ///return BadRequest(); // Http status code 400
        ///return Unauthorized(); // Http status code 401
        ///return Forbid(); // Http status code 403
        ///return NotFound(); // Http status code 404
        /// </summary>
        /// <param name="summary"></param>
        /// <returns></returns>
        [HttpGet("api/weather/{summary}")]
        public IActionResult Get(string summary)
        {
            //URI - http://localhost:53143/weatherforecast/api/weather/cool

            var rng = new Random();
            var WeatherList = GetWeatherList();

            var ret = WeatherList.FirstOrDefault(entry => entry.Summary.ToUpper() == summary.ToUpper());
            if (ret == null)
                //Return 404
                return NotFound();

            return new JsonResult(ret);
        }

        /// <summary>
        /// Usage of frombody & IActionResult, validation
        /// </summary>
        /// <param name="forecast"></param>
        /// <returns></returns>
        [HttpPost("api/weather/forecast")]
        public IActionResult CreateForecast([FromBody] WeatherForecast forecast)
        {
            if (forecast == null)
                return BadRequest();

            var WeatherList = GetWeatherList().ToList();

            if (!ModelState.IsValid)
                return BadRequest();

            WeatherList.Add(forecast);

            return Created("api/weather/forecast", forecast);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace petshop.Controllers
{
  // Attributes
  // ApiController tells Dotnet register this class as a controller
  [ApiController]
  // super() : Route  ("[controller]") injects the name of the Controller 
  // ex: WeatherForecastController injects as WeatherForecast
  [Route("/api/[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    // JUNK CODE FOR DEMO PURPOSES
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    // JUNK CODE FOR DEMO PURPOSES
    private readonly ILogger<WeatherForecastController> _logger;
    // JUNK CODE FOR DEMO PURPOSES
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
      _logger = logger;
    }



    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
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
  }
}

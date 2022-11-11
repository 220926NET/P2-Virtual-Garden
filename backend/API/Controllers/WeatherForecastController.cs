using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo1.Controllers;

// The controller is the entrypoint of your .NET API

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase // must inherit ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast"), Authorize]
    public IEnumerable<WeatherForecast> Get()
    {
        string? value = User?.FindFirst("userId")?.Value;
        Console.WriteLine(value);
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpPost]
    public string retreiveNumber(int num)
    {
        return num.ToString();
    }
}

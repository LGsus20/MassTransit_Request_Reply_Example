using MassTransit;
using Microsoft.AspNetCore.Mvc;
using MyClasses.WeatherContracts;

namespace WeatherAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    IRequestClient<CheckWeatherCountry> _client;
    public TimeSpan ttl = TimeSpan.FromSeconds(45);
    public WeatherForecastController(IRequestClient<CheckWeatherCountry> client)
    {
        _client = client;
    }

    [HttpGet("{Country}")]
    public async Task<IActionResult> Get(string Country)
    {
        var payload = new { Country };
        var response = await _client.GetResponse<WeatherResponse>(payload, timeout: ttl);

        return Ok(response.Message);
    }

}


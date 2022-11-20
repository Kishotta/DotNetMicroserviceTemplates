using Microservice.Application.WeatherForecasts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace Microservice.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ApiController
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController (ISender sender, ILogger<WeatherForecastController> logger) 
        : base (sender)
        => _logger = logger;

    [HttpOptions]
    public IActionResult Options ()
    {
        HttpContext.Response.Headers.AppendCommaSeparatedValues(
            HeaderNames.Allow,
            HttpMethods.Options,
            HttpMethods.Head,
            HttpMethods.Get
            );
        return Ok ();
    }
    
    [HttpHead (Name = "HeadWeatherForecast")]
    [HttpGet (Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get (CancellationToken cancellationToken)
    {
        _logger.LogInformation ("WeatherForecastController.Get() called at {Time}",
                                DateTime.UtcNow);

        var query = new GetWeatherForecastQuery ();

        var response = await Sender.Send (query, cancellationToken);

        return response.IsSuccess ? Ok (response.Value) : NotFound (response.Error);
    }
}
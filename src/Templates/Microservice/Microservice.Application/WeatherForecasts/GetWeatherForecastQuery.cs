namespace Microservice.Application.WeatherForecasts;

public sealed record GetWeatherForecastQuery : IQuery<IEnumerable<WeatherForecastResponse>>;
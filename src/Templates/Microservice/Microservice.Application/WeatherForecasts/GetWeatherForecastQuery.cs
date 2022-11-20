using Microservice.Application.Abstractions;

namespace Microservice.Application.WeatherForecasts;

public record GetWeatherForecastQuery : IQuery<IEnumerable<WeatherForecastResponse>>;
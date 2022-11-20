namespace Microservice.Application.WeatherForecasts;

public sealed record WeatherForecastResponse(DateTime Date, int TemperatureC, int TemperatureF, string? Summary);
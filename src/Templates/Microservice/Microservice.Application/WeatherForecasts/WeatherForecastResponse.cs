namespace Microservice.Application.WeatherForecasts;

public record WeatherForecastResponse(DateTime Date, int TemperatureC, int TemperatureF, string? Summary);
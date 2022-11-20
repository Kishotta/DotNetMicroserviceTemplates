using Microservice.Domain.Entities;

namespace Microservice.Domain.Repositories;

public interface IWeatherForecastRepository
{
    Task<List<WeatherForecast>> GetWeatherForecastsAsync (CancellationToken cancellationToken = default);
}
using Microservice.Domain.Entities;

namespace Microservice.Domain.IRepositories;

public interface IWeatherForecastRepository
{
    Task<List<WeatherForecast>> GetWeatherForecastsAsync (CancellationToken cancellationToken = default);
}
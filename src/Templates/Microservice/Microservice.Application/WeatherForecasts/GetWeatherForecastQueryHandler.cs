using Microservice.Application.Abstractions;
using Microservice.Domain.IRepositories;
using Microservice.Domain.Shared;

namespace Microservice.Application.WeatherForecasts;

public class GetWeatherForecastQueryHandler : IQueryHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecastResponse>>
{
    private readonly IWeatherForecastRepository _weatherForecastRepository;

    public GetWeatherForecastQueryHandler (IWeatherForecastRepository weatherForecastRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
    }
    
    public async Task<Result<IEnumerable<WeatherForecastResponse>>> Handle (GetWeatherForecastQuery request, CancellationToken cancellationToken)
    {
        var weatherForecasts = await _weatherForecastRepository.GetWeatherForecastsAsync(cancellationToken);
        
        return weatherForecasts.Select (forecast 
                                        => new WeatherForecastResponse (
                                            forecast.Date, 
                                            forecast.TemperatureC,
                                            forecast.TemperatureF,
                                            forecast.Summary))
                               .ToList ();
    }
}
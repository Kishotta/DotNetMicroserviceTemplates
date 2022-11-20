using Microservice.Domain.Entities;
using Microservice.Domain.IRepositories;

namespace Microservice.Infrastructure.Services;

public class WeatherForecastService : IWeatherForecastRepository
{
    private static readonly string[] Summaries = { 
                                                     "Freezing",
                                                     "Bracing", 
                                                     "Chilly",
                                                     "Cool", 
                                                     "Mild",
                                                     "Warm", 
                                                     "Balmy",
                                                     "Hot",
                                                     "Sweltering",
                                                     "Scorching"
                                                 };
    
    public async Task<List<WeatherForecast>> GetWeatherForecastsAsync (CancellationToken cancellationToken = default)
    {
        var result =
        Enumerable.Range(1, 5)
                  .Select(index => WeatherForecast.Create(
                              DateTime.Now.AddDays(index),
                              Random.Shared.Next(-20, 55),
                              Summaries[Random.Shared.Next(Summaries.Length)])
                   )
                  .ToArray();
        return await Task.FromResult (result.ToList ());
    }
}
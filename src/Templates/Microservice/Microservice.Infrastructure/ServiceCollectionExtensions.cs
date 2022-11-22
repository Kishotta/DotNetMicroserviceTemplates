using Microservice.Domain.Repositories;
using Microservice.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices (this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastRepository, WeatherForecastService> ();
        return services;
    }
}
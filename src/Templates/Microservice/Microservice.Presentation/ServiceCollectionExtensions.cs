using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Presentation;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationServices (this IServiceCollection services)
    {
        services.AddControllers()
                .AddNewtonsoftJson();
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
}
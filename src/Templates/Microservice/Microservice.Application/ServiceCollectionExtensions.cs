using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(AssemblyReference.Assembly);
        return services;
    }
}
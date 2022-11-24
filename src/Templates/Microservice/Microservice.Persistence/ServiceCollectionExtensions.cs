using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseInMemoryDatabase(configuration.GetConnectionString("DefaultConnection") ?? "In Memory Database");
        });

        return services;
    }
}
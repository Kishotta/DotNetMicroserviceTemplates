using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;

namespace Microservice.Presentation;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationServices (this IServiceCollection services)
    {
        services.AddControllers()
                .AddNewtonsoftJson();
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc ("v1",
                                new OpenApiInfo
                                {
                                    Title = "Microservice",
                                    Version = "v1",
                                    Description = "Microservice API Documentation Description",
                                    Contact = new OpenApiContact
                                    {
                                        Name = "John Doe",
                                        Email = "jdoe@example.com"
                                    },
                                });
            
            var xmlFile = $"{AssemblyReference.Assembly.GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
            options.EnableAnnotations();
        });
        return services;
    }
}
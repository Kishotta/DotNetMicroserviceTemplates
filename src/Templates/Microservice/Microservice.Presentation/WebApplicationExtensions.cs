using Microsoft.AspNetCore.Builder;

namespace Microservice.Presentation;

public static class WebApplicationExtensions
{
    public static IApplicationBuilder AddApiDocumentation (this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Microservice API v1");
        });

        app.UseReDoc (options =>
        {
            options.DocumentTitle = "Microservice API Documentation";
            options.SpecUrl       = "/swagger/v1/swagger.json";
        });

        return app;
    }

    public static IApplicationBuilder AddMvcControllers (this WebApplication app)
    {
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
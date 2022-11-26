using Microservice.Application;
using Microservice.Infrastructure;
using Microservice.Persistence;
using Microservice.Presentation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices ();
builder.Services.AddInfrastructureServices ();
builder.Services.AddPersistenceServices (builder.Configuration);
builder.Services.AddPresentationServices ();

var app = builder.Build();

app.AddApiDocumentation ();
app.AddMvcControllers ();

// Run database migrations
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DatabaseContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

app.Run();

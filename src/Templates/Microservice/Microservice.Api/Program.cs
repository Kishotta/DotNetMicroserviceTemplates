using Microservice.Application;
using Microservice.Infrastructure;
using Microservice.Persistence;
using Microservice.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices ();
builder.Services.AddInfrastructureServices ();
builder.Services.AddPersistenceServices (builder.Configuration);
builder.Services.AddPresentationServices ();

var app = builder.Build();

app.AddApiDocumentation ();
app.AddMvcControllers ();

app.Run();

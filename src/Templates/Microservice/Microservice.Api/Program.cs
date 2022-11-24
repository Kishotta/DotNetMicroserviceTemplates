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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using MediatR;
using Microservice.Domain.Repositories;
using Microservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
       .AddScoped<IWeatherForecastRepository, WeatherForecastService> ();

builder.Services
       .AddMediatR(Microservice.Application.AssemblyReference.Assembly);

builder.Services
       .AddControllers()
       .AddApplicationPart(Microservice.Presentation.AssemblyReference.Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

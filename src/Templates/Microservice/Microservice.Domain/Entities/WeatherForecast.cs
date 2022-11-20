using Microservice.Domain.Primitives;

namespace Microservice.Domain.Entities;

public class WeatherForecast : Entity
{
    public DateTime Date         { get; private set; }
    public int      TemperatureC { get; private set; }
    public string?  Summary      { get; private set; }
    public int      TemperatureF => (int)(TemperatureC / 0.5556) + 32;
    public int      TemperatureK => TemperatureC                 + 273;
    
    private WeatherForecast() { }
    
    private WeatherForecast (DateTime date, int temperatureC, string? summary)
    {
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }
    
    public static WeatherForecast Create(DateTime date, int temperatureC, string? summary)
    {
        return new WeatherForecast(date, temperatureC, summary);
    }
}
namespace weather_forecast.Configs;

public class WeatherForecastOptions
{
    public ICollection<string> Cities { get; set; } = new List<string>();
}
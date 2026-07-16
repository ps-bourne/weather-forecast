namespace weather_forecast.Models;

public class CityWeatherDto
{
    public string City { get; set; } = string.Empty;

    public double? TemperatureCelcius { get; set; }

    public double? TemperatureFahrenheit => TemperatureCelcius.HasValue ? (TemperatureCelcius.Value * 9 / 5) + 32 : null;

    public DateTime? ForcastDateTime { get; set; }
}


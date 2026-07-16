using Microsoft.Extensions.Options;
using weather_forecast.Configs;
using weather_forecast.Models;

namespace weather_forecast.Services;

public class WeatherForecastService
{
    private readonly ILogger<WeatherForecastService> _logger;

    private readonly ICollection<string> _cities;

    public WeatherForecastService(ILogger<WeatherForecastService> logger, IOptions<WeatherForecastOptions> options)
    {
        _logger = logger;
        _cities = options.Value.Cities;
    }

    public IEnumerable<CityWeatherDto> GetCityWeather()
    {
        _logger.LogInformation("Executing {method}: Fetch weather forecast for configured cities.", nameof(GetCityWeather));

        if (_cities == null || !_cities.Any())
        {
            _logger.LogWarning("No cities configured for weather forecast.");
            return [];
        }

        DateTime forecastDate = DateTime.Now.AddDays(1);
        var random = new Random(forecastDate.Nanosecond);

        var cityWeathers = _cities.Select(city => new CityWeatherDto
        {
            City = city,
            TemperatureCelcius = random.Next(0, 500) / 10.0,
            ForcastDateTime = forecastDate
        }).ToList();

        return cityWeathers;
    }
}

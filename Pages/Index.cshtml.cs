using Microsoft.AspNetCore.Mvc.RazorPages;
using weather_forecast.Models;
using weather_forecast.Services;

namespace weather_forecast.Pages;

public class IndexModel : PageModel
{
    #region public properties

    public List<CityWeatherDto> CityWeathers { get; } = [];

    #endregion

    private readonly WeatherForecastService _weatherForecastService;


    public IndexModel(WeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }

    public void OnGet()
    {
        CityWeathers.Clear();

        var cityWeathers = _weatherForecastService.GetCityWeather();

        CityWeathers.AddRange(cityWeathers);
    }
}

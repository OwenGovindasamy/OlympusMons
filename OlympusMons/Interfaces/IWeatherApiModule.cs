using OlympusMons.Models;

namespace OlympusMons.Interfaces
{
    public interface IWeatherApiModule
    {
        Task<WeatherReport> GetWeatherForecastAsync(string City, string CountryCode);
        string CleanJson(string text);
    }
}
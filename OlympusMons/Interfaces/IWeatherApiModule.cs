using OlympusMons.Models;
using OlympusMons.ViewModels;

namespace OlympusMons.Interfaces
{
    public interface IWeatherApiModule
    {
        Task<WeatherReport> GetWeatherForecastAsync(WeatherQueryPropsVM Vm);
        string CleanJson(string text);
    }
}
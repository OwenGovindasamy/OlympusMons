using OlympusMons.ViewModels;

namespace OlympusMons.Interfaces
{
    public interface IHelpers
    {
        string GetHost();
        string GetHostLink();
        string Getkey();
        string GetkeyLink();
        string GetJsonContent();
        WeatherQueryPropsVM PopulateWeatherPropsVM_SampleData();
        string GetRapid_WeatherEndpoint();
    }
}
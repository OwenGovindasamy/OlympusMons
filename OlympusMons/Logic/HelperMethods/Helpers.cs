using OlympusMons.Interfaces;
using OlympusMons.ViewModels;

namespace OlympusMons.Logic.HelperMethods
{ // get values from appsetting.json
    public class Helpers : IHelpers
    {// values placed in appsetting.json file can be edited on the fly(while the app is deployed to production)
        private readonly IConfiguration _mySettings;
        public Helpers(IConfiguration mySettings)
        {
            _mySettings = mySettings;
        }
        public string GetHost()
        {
            return _mySettings.GetValue<string>("RapidApiConfig:host");
        }
        public string GetHostLink()
        {
            return _mySettings.GetValue<string>("RapidApiConfig:hostLink");
        }
        public string Getkey()
        {
            return _mySettings.GetValue<string>("RapidApiConfig:key");
        }
        public string GetkeyLink()
        {
            return _mySettings.GetValue<string>("RapidApiConfig:keyLink");
        }
        public string GetJsonContent()
        {
            return _mySettings.GetValue<string>("GeneralConfig:JsonContent");
        }
        public WeatherQueryPropsVM PopulateWeatherPropsVM_SampleData()
        {
            return new WeatherQueryPropsVM() { Id = 2172797, City = "Durban", CountryCode = "za", Latitude = "0", Longitude = "0", Callback = "test", Language = "null", Units = "metric", Mode = "xml" };
        }
        public string GetRapid_WeatherEndpoint()
        {
            return _mySettings.GetValue<string>("Endpoints:Rapid_Weather");
        }
    }
}

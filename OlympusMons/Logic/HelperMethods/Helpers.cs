using OlympusMons.Interfaces;

namespace OlympusMons.Logic.HelperMethods
{ // get values from appsetting.json
    public class Helpers : IHelpers
    {
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
    }
}

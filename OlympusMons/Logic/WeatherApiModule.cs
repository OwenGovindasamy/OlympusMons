using Newtonsoft.Json;
using OlympusMons.Interfaces;
using OlympusMons.Models;
using OlympusMons.ViewModels;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace OlympusMons.Logic
{
    public class WeatherApiModule : IWeatherApiModule
    {
        #region Dependency Injection
        private readonly IHelpers _helpers;
        public WeatherApiModule(IHelpers helpers)
        {
            _helpers = helpers;
        }
        #endregion Dependency Injection

        public async Task<WeatherReport> GetWeatherForecastAsync(WeatherQueryPropsVM Vm)
        {// values placed in appsetting.json file can be edited on the fly(while the app is deployed to production)
            string apiUrl = _helpers.GetRapid_WeatherEndpoint();

            using HttpClient client = new();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_helpers.GetJsonContent()));
            client.DefaultRequestHeaders.Add(_helpers.GetHost(), _helpers.GetHostLink());
            client.DefaultRequestHeaders.Add(_helpers.Getkey(), _helpers.GetkeyLink());

            HttpResponseMessage response = new();

            try
            {
                response = await client.GetAsync(BuildWeatherQueryString(Vm));

                if (response.IsSuccessStatusCode)
                {
                    var result = CleanJson(await response.Content.ReadAsStringAsync());
                    
                    return JsonConvert.DeserializeObject<WeatherReport>(result) ?? new();
                }
                return new();
            }
            catch (Exception ex)
            {
                //TODO: log ex
                Debug.WriteLine(ex);
                return new();
            }
        }

        public string CleanJson(string text)
        {// cleaning the Json obj before Deserializing because it comes from rapidapi encapsulated with "test( )" for some reason and this renders the json invalid so it cannot be deserialized
            text = text.Replace("test(", "").Replace(")", "");
            return text;
        }

        public string BuildWeatherQueryString(WeatherQueryPropsVM Vm)
        {// creating url string to be getted. there's plenty of other ways to do this ie. using a dictionary etc. but I've chosen the easiest way for this project.  
            return string.Format("?q={0}%2C{1}&lat={2}&lon={3}&callback={4}&id={5}&lang={6}&units={7}&mode={8}", Vm.City, Vm.CountryCode, Vm.Latitude, Vm.Longitude, Vm.Callback, Vm.Id, Vm.Language, Vm.Units, Vm.Mode);
        }
    }
}

//https://rapidapi.com/community/api/open-weather-map/  <-------WEATHER API FROM
//https://codepen.io/icebob/pen/yNpgqR                  <-------WEATHER UI FROM 
//https://bootsnipp.com/snippets/vl4R7#comments         <-------LOGIN DESIGN FROM
//https://codepen.io/mdbootstrap/pen/Yrdjwr/            <-------WEATHER FORM from
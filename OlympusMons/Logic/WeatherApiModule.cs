using Newtonsoft.Json;
using OlympusMons.Interfaces;
using OlympusMons.Models;
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

        public async Task<WeatherReport> GetWeatherForecastAsync(string City, string CountryCode)
        {
            string apiUrl = "https://community-open-weather-map.p.rapidapi.com/weather?q=" + City + "%2C" + CountryCode + "&lat=0&lon=0&callback=test&id=2172797&lang=null&units=imperial&mode=xml";

            using HttpClient client = new();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_helpers.GetJsonContent()));

            client.DefaultRequestHeaders.Add(_helpers.GetHost(), _helpers.GetHostLink());
            client.DefaultRequestHeaders.Add(_helpers.Getkey(), _helpers.GetkeyLink());

            HttpResponseMessage response = new();

            try
            {
                response = await client.GetAsync(apiUrl);

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
    }
}

//https://rapidapi.com/community/api/open-weather-map/  <-------WEATHER API FROM
//https://codepen.io/icebob/pen/yNpgqR                  <-------UI FROM 
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace OlympusMons.Models
{
    
    public class Coordinates
    {
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }
    }
    public class Weather
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("main")]
        public string? Main { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        [JsonPropertyName("icon")]
        public string? Icon { get; set; }
    }
    public class Main
    {
        public double temp { get; set; }
        public double feelslike { get; set; }
        public double tempmin { get; set; }
        public double tempmax { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public int sealevel { get; set; }
        public int grnd_level { get; set; }
    }
    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
        public double gust { get; set; }
    }
    public class Clouds
    {
        public int all { get; set; }
    }
    public class System
    {
        public int type { get; set; }
        public int id { get; set; }
        public string? country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class WeatherReport
    {
        [JsonProperty("coord")]
        public Coordinates? Coordinates { get; set; }

        [JsonProperty("weather")]
        public List<Weather>? Weather { get; set; }

        [JsonProperty("base")]
        public string? Base { get; set; }

        [JsonProperty("main")]
        public Main? Main { get; set; }

        [JsonProperty("visibility")]
        public int Visibility { get; set; }

        [JsonProperty("wind")]
        public Wind? Wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds? Clouds { get; set; }

        [JsonProperty("dt")]
        public int Date { get; set; }

        [JsonProperty("sys")]
        public System? System { get; set; }

        [JsonProperty("timezone")]
        public int Timezone { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("cod")]
        public int Cod { get; set; }
    }

}

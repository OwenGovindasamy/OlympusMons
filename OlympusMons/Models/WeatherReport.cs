using Newtonsoft.Json;

namespace OlympusMons.Models
{
    
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string? main { get; set; }
        public string? description { get; set; }
        public string? icon { get; set; }
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

    public class Sys
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
        public Coord? coord { get; set; }

        [JsonProperty("weather")]
        public List<Weather>? weather { get; set; }

        [JsonProperty("base")]
        public string? dbase { get; set; }

        [JsonProperty("main")]
        public Main? main { get; set; }

        [JsonProperty("visibility")]
        public int visibility { get; set; }

        [JsonProperty("wind")]
        public Wind? wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds? clouds { get; set; }

        [JsonProperty("dt")]
        public int dt { get; set; }

        [JsonProperty("sys")]
        public Sys? sys { get; set; }

        [JsonProperty("timezone")]
        public int timezone { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string? name { get; set; }

        [JsonProperty("cod")]
        public int cod { get; set; }
    }

}

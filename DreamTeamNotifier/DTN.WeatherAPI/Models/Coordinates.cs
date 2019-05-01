using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DTN.WeatherAPI
{
    public class Coordinates
    {
        [JsonProperty(PropertyName = "lon")]
        public double Longitude { get; set; }
        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; set; }
    }
}
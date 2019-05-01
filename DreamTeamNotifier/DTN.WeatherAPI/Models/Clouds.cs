using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DTN.WeatherAPI
{
    public class Clouds
    {
        [JsonProperty(PropertyName = "all")]
        public int Cloudiness { get; set; }
    }
}
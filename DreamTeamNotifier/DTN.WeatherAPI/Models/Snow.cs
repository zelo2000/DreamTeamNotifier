using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DTN.WeatherAPI
{
    public class Snow
    {
        [JsonProperty(PropertyName = "1h")]
        public int Last1Hour { get; set; }
        
        [JsonProperty(PropertyName = "3h")]
        public int Last3Hours { get; set; }
    }
}
using Newtonsoft.Json;

namespace DTN.WeatherAPI
{
    public class Rain
    {
        [JsonProperty(PropertyName = "1h")]
        public int Last1Hour { get; set; }
        
        [JsonProperty(PropertyName = "3h")]
        public int Last3Hours { get; set; }
    }
}
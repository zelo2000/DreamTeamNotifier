using Newtonsoft.Json;

namespace DTN.WeatherAPI
{
    public class Response
    {
        [JsonProperty(PropertyName = "weather")]
        public Weather[] @Weather { get; set; }
        
        [JsonProperty(PropertyName = "main")]
        public Main @Main { get; set; }
        
        [JsonProperty(PropertyName = "clouds")]
        public Clouds @Clouds { get; set; }
        
//        [JsonProperty(PropertyName = "wind")]
//        public Wind

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
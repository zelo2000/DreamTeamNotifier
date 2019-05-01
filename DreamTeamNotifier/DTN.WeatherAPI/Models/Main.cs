using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DTN.WeatherAPI
{
    public class Main
    {
        [JsonProperty(PropertyName = "temp")]
        public double Temperature { get; set; }
        
        [JsonProperty(PropertyName = "pressure")]
        public int Pressure { get; set; }
        
        [JsonProperty(PropertyName = "humidity")]
        public int Humidity { get; set; }
        
        [JsonProperty(PropertyName = "temp_min")]
        public double MinTemperature { get; set; }
        
        [JsonProperty(PropertyName = "temp_max")]
        public double MaxTemperature { get; set; }
    }
}
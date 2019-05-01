using OpenWeatherMap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace DTN.Core.Utility
{
    /// <summary>
    /// Provide class for getting weather info
    /// </summary>
    public class WeatherRepository
    {
        private readonly WeatherAPI _weatherApi;

        public WeatherRepository()
        {
            _weatherApi = new WeatherAPI();
        }

        /// <summary>
        /// Get weather info
        /// </summary>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        /// <returns>weather info</returns>
        public dynamic GetWeather(double latitude, double longitude)
        {
            var url = _weatherApi.GeographicalWeatherRequest(latitude, longitude);
            var jsonResponse = Get(url);
            return JsonConvert.DeserializeObject(jsonResponse);
        }

        private string Get(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}

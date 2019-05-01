using System;
using System.Collections.Generic;
using System.Text;
using DTN.Core.Settings;

namespace DTN.Core.Utility
{
    /// <summary>
    /// Provide weather API
    /// </summary>
    public class WeatherAPI
    {
        private static readonly string apiUrl = "https://api.openweathermap.org/data/2.5/weather?";

        public string GeographicalWeatherRequest(double latitude, double longitude)
        {
            var request = apiUrl + "lat={0}&lon={1}&appid={2}";
            return string.Format(request, latitude, longitude, Constants.ApiKey);
        }
    }
}

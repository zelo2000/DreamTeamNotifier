using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DTN.WeatherAPI
{
    public class RequestData
    {
        public static async Task<Response> Request()
        {
            string baseUrl =
                "https://samples.openweathermap.org/data/2.5/weather?q=London,uk&appid=b6907d289e10d714a6e88b30761fae22";

            try
            {
                using (var client = new HttpClient())
                {
                    using (var res = await client.GetAsync(baseUrl))
                    {
                        using (var content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                Console.WriteLine(data);
                                //var serializer = new JsonSerializer();
                                Response response = JsonConvert.DeserializeObject<Response>(data);
                                return response;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return null;
        }
    }
}
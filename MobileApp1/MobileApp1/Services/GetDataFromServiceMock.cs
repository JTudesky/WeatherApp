using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Weather.Services
{
    class GetDataFromServiceMock
    {

        public static Task<Models.Weather> GetWeather()
        {

            var source = File.ReadAllText(@"c:\response.json");
            var parsed = JsonConvert.DeserializeObject<Dictionary<string, Models.Weather>>(source);

            return null;
        }
    }
}

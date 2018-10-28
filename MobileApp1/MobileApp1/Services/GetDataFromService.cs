using System.Threading.Tasks;

namespace Weather.Services
{
    public class GetDataFromService
    {

        public static async Task<Models.Weather> GetWeather()
        {
            string id = "499099";
            string key = "61bb9478df48720c027a9139a9197881";
            string queryString = "api.openweathermap.org/data/2.5/forecast?id="
                + id + "&appid=" + key + "&units=metric";

            //Make sure developers running this sample replaced the API key
            if (key == "YOUR API KEY HERE")
            {
                throw new System.ArgumentException("You must obtain an API key from openweathermap.org/appid and save it in the 'key' variable.");
            }

            dynamic results = await RequestData.GetDataFromService(queryString).ConfigureAwait(false);

            return null;
        }
    }

}



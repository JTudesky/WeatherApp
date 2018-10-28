using System.IO;
using System.Reflection;

namespace Weather.Services
{
    //Получаем Weather из файла weather.json (ответ от сервиса openweathermap)
    public class GetDataFromServiceMock
    {
        public Weather.Models.Weather GetWeather(Assembly assembly)
        {
            assembly = GetType().GetTypeInfo().Assembly;
            string[] resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            Stream stream = assembly.GetManifestResourceStream("App17_10.Resources.weather.txt");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            return Weather.Models.Weather.FromJson(text); ;
        }
    }
}

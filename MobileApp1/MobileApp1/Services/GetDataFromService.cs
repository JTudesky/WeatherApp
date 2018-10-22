using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Services
{
    class GetDataFromService
    {
        readonly static string id = "499099";
        public static async Task<Models.Weather> GetWeather()
        {
            string key = "61bb9478df48720c027a9139a9197881";
            string queryString = "api.openweathermap.org/data/2.5/forecast?id="
                + id + "&appid=" + key + "&units=metric";

            dynamic results = await RequestData.RequestHttp(queryString).ConfigureAwait(false);

            /*
            if (results["weather"] != null)
            {
                Models.Weather weather = new Models.Weather();
                weather.CityName = (string)results["name"];
                weather.TempMax = (string)results["main"]["temp_max"] + " C";
                weather.TempMax = (string)results["main"]["temp_min"] + " C";
                weather.Wind = (string)results["wind"]["speed"] + " m/s";
                weather.Humidity = (string)results["main"]["humidity"] + " %";
                //weather.Visibility = (string)results["weather"][0]["main"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                //weather.Sunrise = sunrise.ToString() + " UTC";
                //weather.Sunset = sunset.ToString() + " UTC";
                return weather;
            }
            else
            {*/
                return null;
            }
        }
    }


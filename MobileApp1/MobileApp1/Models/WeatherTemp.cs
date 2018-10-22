using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Models
{
    class WeatherTemp
    {
        public string CityName { get; set; }
        public string Data { get; set; }
        public string TempMax { get; set; }
        public string TempMin { get; set; }
        public string Main { get; set; }
        public string Humidity { get; set; }
        public string Pressure { get; set; }
        public string Wind { get; set; }
    }
}

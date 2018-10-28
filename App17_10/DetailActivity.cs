using Android.Support.V7.App;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace App17_10
{
    [Activity(Label ="Details", ParentActivity = typeof(MainActivity))]

    class DetailActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.detail_activity);

            TextView itemDate = FindViewById<TextView>(Resource.Id.date);
            TextView itemDescription = FindViewById<TextView>(Resource.Id.weather_description);
            TextView itemMaxTemperature = FindViewById<TextView>(Resource.Id.high_temperature);
            TextView itemHumidity = FindViewById<TextView>(Resource.Id.humidity);
            TextView itemPressure = FindViewById<TextView>(Resource.Id.pressure);
            TextView itemWind = FindViewById<TextView>(Resource.Id.wind);

            itemDate.Text = "Date: " + Intent.GetStringExtra("itemDate");
            itemDescription.Text = "WeatherDescription: " + Intent.GetStringExtra("itemWeatherDescription");
            itemMaxTemperature.Text = "MaxTemperature " + Intent.GetStringExtra("itemMaxTemperature");
            itemHumidity.Text = "Humidity: " + Intent.GetStringExtra("itemHumidity") + " %";
            itemPressure.Text = "Pressure: " + Intent.GetStringExtra("itemPressure") + " hPa";
            itemWind.Text = "Wind: " + Intent.GetStringExtra("itemWind") + " meter/sec";
        }
    }
}
using System;
using System.Globalization;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace App17_10
{
    class RecyclerViewAdapter : RecyclerView.Adapter
    {
            Context mContext;
            public event EventHandler<int> ItemClick;
            Weather.Models.Weather weather;

            //Конструктор адаптера
            public RecyclerViewAdapter(Context context, Weather.Models.Weather weatherSet)
            {
                weather = weatherSet;
                mContext = context;
            }
            
            //Метод переводит DateTime в наш часовой пояс (UTC +4)
            String DateTimeToStringTimeZone(int pos)
            {
                DateTime dt = weather.List[pos].Dt;
                DateTime dtInTimeZone = TimeZoneInfo.ConvertTimeFromUtc(dt, TimeZoneInfo.FindSystemTimeZoneById("Europe/Samara"));
                return dtInTimeZone.ToString("dddd dd MMMM \nHH:mmtt", CultureInfo.CreateSpecificCulture("en-US"));
            }


            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
                {
                    View itemView = LayoutInflater.From(parent.Context).
                                Inflate(Resource.Layout.forcast_list_item, parent, false);

                    WeatherViewHolder vh = new WeatherViewHolder(itemView, OnClick);
                    return vh;
                }

            // Устанавливаем значения из Weather
            public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                WeatherViewHolder vh = holder as WeatherViewHolder;

                vh.Data.Text = DateTimeToStringTimeZone(position);
                vh.WeatherDescription.Text = weather.List[position].Weather[0].Description;
                vh.LowTemperature.Text = string.Format ("{0:0}", weather.List[position].Main.TempMin) + "\u00b0";
                string WeatherDescriptionGeneral = weather.List[position].Weather[0].Main.ToString();

                //Устанавливаем icon в зависимости от значения в Weather
                switch (WeatherDescriptionGeneral)
                {
                    case "Clear":
                        vh.WeatherIcon.SetImageResource(Resource.Drawable.ic_clear);
                        break;

                    case "Clouds":
                        vh.WeatherIcon.SetImageResource(Resource.Drawable.ic_cloudy);
                        break;

                    case "Rain":
                        vh.WeatherIcon.SetImageResource(Resource.Drawable.ic_light_rain);
                        break;

                    default:
                        vh.WeatherIcon.SetImageResource(Resource.Drawable.ic_snow);
                        break;
                }
            }


            public override int ItemCount
            {
                get { return weather.List.Length; }
            }

            // Обрабатываем событие клика по элементу
            void OnClick(int position)
            {
                if (ItemClick != null)
                    ItemClick(this, position);


            var intent = new Intent(mContext, typeof(DetailActivity));
            intent.PutExtra("itemDate", DateTimeToStringTimeZone(position));
            intent.PutExtra("itemWeatherDescription", weather.List[position].Weather[0].Description);
            intent.PutExtra("itemMaxTemperature", weather.List[position].Main.TempMax.ToString());
            intent.PutExtra("itemHumidity", weather.List[position].Main.Humidity.ToString());
            intent.PutExtra("itemPressure", weather.List[position].Main.Pressure.ToString());
            intent.PutExtra("itemWind", weather.List[position].Wind.Speed.ToString());
            mContext.StartActivity(intent);
            }
    }

    // VIEW HOLDER ------------------------------------------------------
    public class WeatherViewHolder : RecyclerView.ViewHolder
    {
        public ImageView WeatherIcon { get; private set; }
        public TextView Data { get; private set; }
        public TextView WeatherDescription { get; private set; }
        public TextView HighTemperature { get; private set; }
        public TextView LowTemperature { get; private set; }

        // Get references to the views
        public WeatherViewHolder(View itemView, Action<int> listener)
            : base(itemView)
        {         
            WeatherIcon = itemView.FindViewById<ImageView>(Resource.Id.weather_icon);
            Data = itemView.FindViewById<TextView>(Resource.Id.date);
            WeatherDescription = itemView.FindViewById<TextView>(Resource.Id.weather_description);
            HighTemperature = itemView.FindViewById<TextView>(Resource.Id.high_temperature);
            LowTemperature = itemView.FindViewById<TextView>(Resource.Id.low_temperature);


            //Обрабатываем событие нажатия 
            itemView.Click += (sender, e) =>
            {
                listener(base.LayoutPosition);
            };
        }
    }
}
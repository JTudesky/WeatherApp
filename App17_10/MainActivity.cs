using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using System.IO;
using System.Reflection;
using Android.Content;

namespace App17_10
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        RecyclerViewAdapter recyclerViewAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.forecast_activity);

            //Получаем данные из мока 
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            string[] resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            Stream stream = assembly.GetManifestResourceStream("App17_10.Resources.weather.txt");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            var setOfWeather = Weather.Models.Weather.FromJson(text);




            //Запрос даты с api - есть проблемы с получением данных :(
            //Weather.Models.Weather weather = await Weather.Services.GetDataFromService.GetWeather();


            // Instantiate the adapter and pass in its data source:
            recyclerViewAdapter = new RecyclerViewAdapter(this, setOfWeather);

            // Get our RecyclerView layout:
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.weatherRecyclerView);

            // Plug the adapter into the RecyclerView:
            mRecyclerView.SetAdapter(recyclerViewAdapter);

            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.my_toolbar);
            SetSupportActionBar(toolbar);
        }

        void CreateDetailActivity (int position)
        {
            var intentDetailActivity = new Intent(this, typeof(DetailActivity));           
            StartActivity(intentDetailActivity);           
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_search)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}








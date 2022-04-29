using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using CRUDTareas.Activities;
using CRUDTareas.Services;

namespace CRUDTareas
{
    [Activity(Label = "Task app", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button btnAddTask = FindViewById<Button>(Resource.Id.btnAddTask);
            Button btnSearch = FindViewById<Button>(Resource.Id.btnSearch);

            btnSearch.Click += async delegate
            {
                try
                {
                    var services = new TaskServices();
                    var result = await services.GetTask(6);

                    if (!result.status)
                    {
                        Toast.MakeText(this, result.message, ToastLength.Short).Show();
                        return;
                    }

                    Toast.MakeText(this, result.data.title, ToastLength.Short).Show();
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
                }
            };

            //Open add activity
            btnAddTask.Click += delegate
            {
                StartActivity(typeof(AddActivity));
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
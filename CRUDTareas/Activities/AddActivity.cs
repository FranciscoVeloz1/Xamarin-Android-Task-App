using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using CRUDTareas.Entities;
using CRUDTareas.Services;

namespace CRUDTareas.Activities
{
    [Activity(Label = "Add task", Theme = "@style/AppTheme")]
    public class AddActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_add);

            Button btnSave = FindViewById<Button>(Resource.Id.btnSave);
            Button btnCancel = FindViewById<Button>(Resource.Id.btnCancel);
            EditText txtTitle = FindViewById<EditText>(Resource.Id.txtTitle);
            EditText txtDescription = FindViewById<EditText>(Resource.Id.txtDescription);

            btnSave.Click += async delegate
            {
                var services = new TaskServices();

                var task = new TaskEntity()
                {
                    title = txtTitle.Text,
                    description = txtDescription.Text
                };

                var result = await services.CreateTask(task);

                if (!result.status)
                {
                    Toast.MakeText(this, result.message, ToastLength.Short).Show();
                    return;
                }

                txtTitle.Text = "";
                txtDescription.Text = "";
                Toast.MakeText(this, "Task saved!", ToastLength.Short).Show();
            };

            //Returning view
            btnCancel.Click += delegate
            {
                Finish();
            };
        }
    }
}
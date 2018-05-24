using Android.App;
using Android.Widget;
using Android.OS;
using FirebaseConsole;
using System;

namespace FirebaseTest
{
    [Activity(Label = "FirebaseTest", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            Repo repo = new Repo();
            await repo.GetDataAsync();
            var name = FindViewById<EditText>(Resource.Id.editTextName);
            var surname = FindViewById<EditText>(Resource.Id.editTextSurname);
            var addButton = FindViewById<Button>(Resource.Id.buttonAddUser);
            var readButton = FindViewById<Button>(Resource.Id.buttonReadUsers);
            await repo.GetDataAsync();
            addButton.Click += async delegate (object sender, System.EventArgs e)
            {
                Console.WriteLine("Click Add");
                await repo.PostDataAsync(name.Text, surname.Text);
            };

            readButton.Click += async delegate (object sender, System.EventArgs e)
            {
                Console.WriteLine("Click Read");
                await repo.GetDataAsync();
            };
        }
    }
}


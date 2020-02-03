using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace LeakTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Button secondActivityButton = FindViewById<Button>(Resource.Id.SecondActivityButton);
            Button thirdActivityButton = FindViewById<Button>(Resource.Id.ThirdActivityButton);
            secondActivityButton.Click += SecondActivityButtonOnClick;
            thirdActivityButton.Click += ThirdActivityButtonOnClick;
        }

        private void SecondActivityButtonOnClick(object sender, EventArgs eventArgs)
        {
            var intent = new Intent(this, typeof(SecondActivity));
            StartActivity(intent);
        }


        private void ThirdActivityButtonOnClick(object sender, EventArgs eventArgs)
        {
            var intent = new Intent(this, typeof(ThirdActivity));
            StartActivity(intent);
        }

    }
}


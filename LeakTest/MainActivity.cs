using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using LeakTest.Resources;

namespace LeakTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {

        Button secondActivityButton;
        Button thirdActivityButton;
        Button fragmentButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            secondActivityButton = FindViewById<Button>(Resource.Id.SecondActivityButton);
            thirdActivityButton = FindViewById<Button>(Resource.Id.ThirdActivityButton);
            fragmentButton = FindViewById<Button>(Resource.Id.FragmentsButton);

            secondActivityButton.Click += SecondActivityButtonOnClick;
            thirdActivityButton.Click += ThirdActivityButtonOnClick;
            fragmentButton.Click += FragmentButton_Click;

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

        private void FragmentButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(FragActivity));

            StartActivity(intent);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            secondActivityButton.Click -= SecondActivityButtonOnClick;
            thirdActivityButton.Click -= ThirdActivityButtonOnClick;
            fragmentButton.Click -= FragmentButton_Click;

            secondActivityButton.Dispose();
            thirdActivityButton.Dispose();
            fragmentButton.Dispose();

            // Dispose the activity itself
            Dispose();
        }


    }
}


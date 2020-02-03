
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace LeakTest
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        Button openNextActivityButton;
        Button openPreviousActivityButtonClick;
        TextView labelTextView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.second_activity);

            openPreviousActivityButtonClick = FindViewById<Button>(Resource.Id.OpenPreviousActivityButtonClick);
            openNextActivityButton = FindViewById<Button>(Resource.Id.OpenNextActivityButton);
            labelTextView = FindViewById<TextView>(Resource.Id.LabelTextView);

            labelTextView.Text = "Hello Second Activity";
            openNextActivityButton.Text = "Go to third Activity";
            openNextActivityButton.Click += OpenNextActivityButtonClick;
            openPreviousActivityButtonClick.Click += OpenPreviousActivityButtonClick;
            //Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        private void OpenNextActivityButtonClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ThirdActivity));
            StartActivity(intent);
        }

        private void OpenPreviousActivityButtonClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"{System.Environment.TickCount}: {nameof(Connectivity_ConnectivityChanged)}");
        }

        protected override void OnStop()
        {
            base.OnStop();
        }

        protected override void OnDestroy()
        {
            // This does not fix the memory leak
            // Dispose all disposable members
            openNextActivityButton.Click -= OpenNextActivityButtonClick;
            openNextActivityButton.Dispose();

            openPreviousActivityButtonClick.Click -= OpenPreviousActivityButtonClick;
            openPreviousActivityButtonClick.Dispose();

            labelTextView.Dispose();

            base.OnDestroy();

            // Dispose the activity itself
            Dispose();
        }
    }
}

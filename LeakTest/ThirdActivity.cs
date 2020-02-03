
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

namespace LeakTest
{
    [Activity(Label = "ThirdActivity")]
    public class ThirdActivity : Activity
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

            labelTextView.Text = "Hello Third Activity. Hitting the OS Back Button should trigger a leak since we are not disposing.";
            openNextActivityButton.Text = "Go to Main Activity";
            openNextActivityButton.Click += OpenNextActivityButtonClick;
            openPreviousActivityButtonClick.Click += OpenPreviousActivityButtonClick;
        }

        private void OpenNextActivityButtonClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        private void OpenPreviousActivityButtonClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(SecondActivity));
            StartActivity(intent);
        }

        protected override void OnDestroy()
        {
            // This does not fix the memory leak
            // Dispose all disposable members
            //openNextActivityButton.Click -= OpenNextActivityButtonClick;
            //openNextActivityButton.Dispose();

            //openPreviousActivityButtonClick.Click -= OpenPreviousActivityButtonClick;
            //openPreviousActivityButtonClick.Dispose();

            //labelTextView.Dispose();

            base.OnDestroy();

            // Dispose the activity itself,
            // We are still required to dispose the event handlers and View References.
            Dispose();
        }
    }
}
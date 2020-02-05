using System;

using Android.App;
using Android.Content;
using Android.OS;
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
            // Dispose all disposable members

            // This fixes the following leak. However the leak only shows when the user hits the back button in the OS

            //Debug(3338) / LeakCanary: Signature: da39a3ee5e6b4bd3255bfef95601890afd879
            //Debug(3338) / LeakCanary: ┬───
            //Debug(3338) / LeakCanary: │ GC Root: Global variable in native code
            //Debug(3338) / LeakCanary: │
            //Debug(3338) / LeakCanary: ├─ android.widget.Button instance
            //Debug(3338) / LeakCanary: │    Leaking: YES(View.mContext references a destroyed activity)
            //Debug(3338) / LeakCanary: │    mContext instance of crc648ee606ad49166d9e.SecondActivity with mDestroyed = true
            //Debug(3338) / LeakCanary: │    View#mParent is set
            //Debug(3338) / LeakCanary: │    View#mAttachInfo is null (view detached)
            //Debug(3338) / LeakCanary: │    View.mID = R.id.OpenPreviousActivityButtonClick
            //Debug(3338) / LeakCanary: │    View.mWindowAttachCount = 1
            //Debug(3338) / LeakCanary: │    ↓ Button.mContext
            //Debug(3338) / LeakCanary: ╰→ crc648ee606ad49166d9e.SecondActivity instance
            //Debug(3338) / LeakCanary: ​     Leaking: YES(ObjectWatcher was watching this because crc648ee606ad49166d9e.SecondActivity received Activity#onDestroy() callback and Activity#mDestroyed is true)
            //Debug(3338) / LeakCanary: ​     key = e1162699 - 49f5 - 4d75 - 8785 - e79f8dca600e
            //Debug(3338) / LeakCanary: ​     watchDurationMillis = 3019
            //Debug(3338) / LeakCanary: ​     retainedDurationMillis = -1
            //Debug(3338) / LeakCanary: ====================================

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

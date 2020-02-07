using Android.App;
using Android.OS;
using Android.Support.V4.App;

namespace LeakTest.Resources
{
    [Activity(Label = "FragActivity")]
    public class FragActivity : FragmentActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.quote_activity);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            // Dispose the activity itself
            Dispose();
        }
    }
}

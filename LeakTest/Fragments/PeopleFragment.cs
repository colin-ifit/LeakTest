using System;
using Android.Content;
using Android.OS;
using Android.App;
using Android.Views;
using Android.Widget;
namespace LeakTest.Fragments
{
    public class PeopleFragment : ListFragment
    {
        int selectedQuoteId;

        public PeopleFragment()
        {
            // Being explicit about the requirement for a default constructor.
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            ListAdapter = new ArrayAdapter<String>(Activity, Android.Resource.Layout.SimpleListItemActivated1, Quotes.People);

            if (savedInstanceState != null)
            {
                selectedQuoteId = savedInstanceState.GetInt("current_quote_id", 0);
            }
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt("current_quote_id", selectedQuoteId);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            ShowQuote(position);
        }

        void ShowQuote(int quoteId)
        {
            var intent = new Intent(Activity, typeof(QuoteActivity));
            intent.PutExtra("current_quote_id",quoteId);
            StartActivity(intent);
        }

        public override void OnDestroy()
        {

            base.OnDestroy();


            //Debug(23613) / LeakCanary: ┬───
            //Debug(23613) / LeakCanary: │ GC Root: Global variable in native code
            //Debug(23613) / LeakCanary: │
            //Debug(23613) / LeakCanary: │    Leaking: UNKNOWN
            //Debug(23613) / LeakCanary: │    ↓ ArrayAdapter.mContext
            //Debug(23613) / LeakCanary: │                   ~~~~~~~~
            //Debug(23613) / LeakCanary: ╰→ crc6496d286667f106fa4.FragmentActivity instance
            //Debug(23613) / LeakCanary: ​     Leaking: YES(ObjectWatcher was watching this because crc6496d286667f106fa4.FragmentActivity received Activity#onDestroy() callback and Activity#mDestroyed is true)
            //Debug(23613) / LeakCanary: ​     key = b96431f5 - 588f - 42cc - 81d5 - a32e984ae947
            //Debug(23613) / LeakCanary: ​     watchDurationMillis = 4938
            //Debug(23613) / LeakCanary: ​     retainedDurationMillis = -76
            //Debug(23613) / LeakCanary: ====================================
            ListAdapter.Dispose();

            // Dispose the activity itself

            //Debug(24191) / LeakCanary: ┬───
            //Debug(24191) / LeakCanary: │ GC Root: Global variable in native code
            //Debug(24191) / LeakCanary: │
            //Debug(24191) / LeakCanary: ​     Leaking: YES(ObjectWatcher was watching this because crc64808f84d1d8aaf486.PeopleFragment received Fragment#onDestroy() callback and Fragment#mFragmentManager is null)
            //Debug(24191) / LeakCanary: ​     key = 32030641 - a340 - 427a - 8244 - a9b925256fda
            //Debug(24191) / LeakCanary: ​     watchDurationMillis = 7394
            //Debug(24191) / LeakCanary: ​     retainedDurationMillis = 2394
            //Debug(24191) / LeakCanary: ====================================
           Dispose();
        }
    }
}

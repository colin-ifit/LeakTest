using System;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;

namespace LeakTest.Fragments
{
    public class QuoteFragment : Fragment
    {
        public int QuoteId => Arguments.GetInt("current_quote_id", 0);

        //TextView textView;
        //ScrollView scroller;

        public static QuoteFragment NewInstance(int quoteId)
        {
            var bundle = new Bundle();
            bundle.PutInt("current_quote_id", quoteId);
            return new QuoteFragment { Arguments = bundle };
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (container == null)
            {
                return null;
            }

            //textView = new TextView(Activity);
            //var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Activity.Resources.DisplayMetrics));
            //textView.SetPadding(padding, padding, padding, padding);
            //textView.TextSize = 24;
            //textView.Text = Quotes.Quote[QuoteId];

            //scroller = new ScrollView(Activity);
            //scroller.AddView(textView);

            return null;
        }

        public override void OnDestroy()
        {

            base.OnDestroy();

            // Dispose all disposable members
            //textView.Dispose();
            //scroller.Dispose();

            // Dispose the activity itself
            Dispose();
        }
    }
}

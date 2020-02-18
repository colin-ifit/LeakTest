using Android.App;
using Android.OS;
using LeakTest.Fragments;
using Android.Support.V4.App;
using Android.Support.V7.App;

namespace LeakTest
{
    [Activity(Label = "QuoteActivity")]
    public class QuoteActivity : AppCompatActivity
    {
        QuoteFragment quoteFragment;
        Android.Support.V4.App.FragmentTransaction ft;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var quoteId = Intent.Extras.GetInt("current_quote_id", 0);

            quoteFragment = QuoteFragment.NewInstance(quoteId);

            ft = SupportFragmentManager.BeginTransaction();

                ft.DisallowAddToBackStack()
                            .Add(Android.Resource.Id.Content, quoteFragment)
                            .Commit();

            //FragmentManager.PopBackStackImmediate();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            quoteFragment.Dispose();
            //var count = FragmentManager.Fragments.Count;
            SupportFragmentManager.Fragments.Clear();

            //count = FragmentManager.Fragments.Count;
            SupportFragmentManager.Dispose();

            ft.Dispose();
            Dispose();
        }
    }
}

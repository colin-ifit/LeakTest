using Android.App;
using Android.OS;
using LeakTest.Fragments;

namespace LeakTest
{
    [Activity(Label = "QuoteActivity")]
    public class QuoteActivity : Activity
    {
        QuoteFragment quoteFragment;
        FragmentTransaction ft;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var quoteId = Intent.Extras.GetInt("current_quote_id", 0);

            quoteFragment = QuoteFragment.NewInstance(quoteId);

            ft = FragmentManager.BeginTransaction();

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
            FragmentManager.Fragments.Clear();

            //count = FragmentManager.Fragments.Count;
            FragmentManager.Dispose();

            ft.Dispose();
            Dispose();
        }
    }
}

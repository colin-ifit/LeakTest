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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var quoteId = Intent.Extras.GetInt("current_quote_id", 0);

            quoteFragment = QuoteFragment.NewInstance(quoteId);

            SupportFragmentManager.BeginTransaction()
                            .Add(Android.Resource.Id.Content, quoteFragment)
                            .Commit();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            quoteFragment.Dispose();

            SupportFragmentManager.Fragments.Clear();
            SupportFragmentManager.Dispose();


            Dispose();
        }
    }
}

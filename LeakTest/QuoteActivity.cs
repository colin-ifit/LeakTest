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

            SupportFragmentManager.BeginTransaction().Remove(quoteFragment).Commit();

        }

        protected override void OnDestroy()
        {
            //FragmentManager.BeginTransaction().Remove(quoteFragment).Commit();

            base.OnDestroy();

            // LeakCanary doesn't seem to care about this but without it you will end up with a ton of Fragments without a parent.
            //quoteFragment.Dispose();


            //quoteFragment = null;
            //SupportFragmentManager.Fragments.Clear();
            //SupportFragmentManager.Dispose();


            Dispose();
        }
    }
}

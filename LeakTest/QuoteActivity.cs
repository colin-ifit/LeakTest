using Android.App;
using Android.OS;
using Android.Widget;
using LeakTest.Fragments;
using System;

namespace LeakTest
{
    [Activity(Label = "QuoteActivity")]
    public class QuoteActivity : Activity
    {
        QuoteFragment quoteFragment;
        FragmentManager fm;
        FragmentTransaction ft;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var quoteId = Intent.Extras.GetInt("current_quote_id", 0);

            quoteFragment = QuoteFragment.NewInstance(quoteId);

            fm = FragmentManager;

            ft = fm.BeginTransaction();

                        ft.Add(Android.Resource.Id.Content, quoteFragment)
                        .Commit();

            //FragmentManager.PopBackStackImmediate();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            var frameLayout = FindViewById<FrameLayout>(Android.Resource.Id.Content);
            //frameLayout.ClearAnimation();
            //frameLayout.RemoveAllViews();
            frameLayout?.Dispose();
            //frameLayout = null;

            //FragmentManager.BeginTransaction().Remove(quoteFragment).CommitAllowingStateLoss();
            //FragmentManager.Fragments.Clear();
            //FragmentManager.Dispose();
            //quoteFragment.Dispose();
            ft.Dispose();
            fm.Dispose();
            Dispose();
            GC.Collect(0);
            //Java.Lang.JavaSystem.Gc();
        }
    }
}

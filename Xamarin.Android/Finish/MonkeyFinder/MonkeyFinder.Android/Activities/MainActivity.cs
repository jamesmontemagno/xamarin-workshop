using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content.PM;
using MonkeyFinder.Droid.Fragments;

namespace MonkeyFinder.Droid.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Android.Support.V4.App.FragmentManager fragmentManager;
        private Android.Support.V4.App.Fragment monkeysFragment;
        public Android.Support.V7.Widget.Toolbar _toolbar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            _toolbar = toolbar;
            SetSupportActionBar(toolbar);

            fragmentManager = SupportFragmentManager;

            monkeysFragment = new MonkeyListFragment();

            fragmentManager.BeginTransaction().Replace(Resource.Id.main_container, monkeysFragment).Commit();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
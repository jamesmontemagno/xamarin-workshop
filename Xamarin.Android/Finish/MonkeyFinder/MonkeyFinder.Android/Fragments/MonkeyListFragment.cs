using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MonkeyFinder.Droid.Activities;
using MonkeyFinder.Droid.Adapters;
using MonkeyFinder.Model;
using MonkeyFinder.ViewModel;

namespace MonkeyFinder.Droid.Fragments
{
    public class MonkeyListFragment : Android.Support.V4.App.Fragment
    {
        private MainActivity _activity;
        private Android.Support.V4.App.FragmentManager fragmentManager;
        private Android.Support.V4.App.Fragment monkeyDetailFragment;
        private MonkeysViewModel monkeysViewModel = new MonkeysViewModel();

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _activity._toolbar.Title = "Monkey Finder";
            View view = inflater.Inflate(Resource.Layout.fragment_monkeys, container, false);
            var recyclerView = view.FindViewById<RecyclerView>(Resource.Id.monkeysRecyclerView);

            Task.Run(async () => {
                await monkeysViewModel.GetMonkeysAsync();
            }).Wait();

            MonkeysRecyclerViewAdapter adapter = new MonkeysRecyclerViewAdapter(Context, monkeysViewModel);
            adapter.ItemClick += Adapter_ItemClick;
            recyclerView.SetAdapter(adapter);
            LinearLayoutManager layoutManager = new LinearLayoutManager(Context);
            recyclerView.SetLayoutManager(layoutManager);
            return view;
        }

        private void Adapter_ItemClick(object sender, int e)
        {
            var monkey = monkeysViewModel.Monkeys[e];
            monkeyDetailFragment = new MonkeyDetailFragment(monkey);
            fragmentManager.BeginTransaction().Replace(Resource.Id.main_container, monkeyDetailFragment).AddToBackStack(monkey.Name).Commit();
        }

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
            var activity = context as MainActivity;
            _activity = activity;
            fragmentManager = activity.SupportFragmentManager;
        }

    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Bumptech.Glide;
using MonkeyFinder.Droid.Activities;
using MonkeyFinder.Model;
using MonkeyFinder.ViewModel;

namespace MonkeyFinder.Droid.Fragments
{
    public class MonkeyDetailFragment : Android.Support.V4.App.Fragment
    {
        private FloatingActionButton lightSwitchFloatingActionButton { get; set; }
        private TextView monkeyNameTextView { get; set; }
        private TextView monkeyLocationTextView { get; set; }
        private TextView monkeyPopulationTextView { get; set; }
        private TextView monkeyDetailsTextView { get; set; }
        private ImageView monkeyImageView { get; set; }
        private FloatingActionButton showOnMapButton { get; set; }
        private MonkeyDetailsViewModel viewModel;
        public MonkeyDetailFragment(Monkey monkey)
        {
            viewModel = new MonkeyDetailsViewModel(monkey);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_monkey_detail, container, false);

            monkeyNameTextView = view.FindViewById<TextView>(Resource.Id.monkeyNameTextView);
            monkeyLocationTextView = view.FindViewById<TextView>(Resource.Id.monkeyLocationTextView);
            monkeyPopulationTextView = view.FindViewById<TextView>(Resource.Id.monkeyPopulationTextView);
            monkeyDetailsTextView = view.FindViewById<TextView>(Resource.Id.monkeyDetailsTextView);
            monkeyImageView = view.FindViewById<ImageView>(Resource.Id.monkeyImageView);
            showOnMapButton = view.FindViewById<FloatingActionButton>(Resource.Id.showOnMapButton);

            Glide.With(this).Load(viewModel.Monkey.Image.ToString()).CenterCrop().Override(200, 200).Into(monkeyImageView);
            monkeyNameTextView.Text = viewModel.Monkey.Name;
            monkeyLocationTextView.Text = viewModel.Monkey.Location;
            monkeyPopulationTextView.Text = viewModel.Monkey.Population.ToString();
            monkeyDetailsTextView.Text = viewModel.Monkey.Details;

            showOnMapButton.Click += ShowOnMapButton_Click;

            return view;
        }

        private async void ShowOnMapButton_Click(object sender, EventArgs e)
        {
            await viewModel.OpenMapAsync();
        }

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
            var activity = context as MainActivity;
            activity._toolbar.Title = viewModel.Monkey.Name;
        }
    }
}
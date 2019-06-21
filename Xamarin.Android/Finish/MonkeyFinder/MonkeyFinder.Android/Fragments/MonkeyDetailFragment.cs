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

namespace MonkeyFinder.Droid.Fragments
{
    public class MonkeyDetailFragment : Android.Support.V4.App.Fragment
    {
        private Monkey _monkey;
        private FloatingActionButton lightSwitchFloatingActionButton { get; set; }
        private TextView monkeyNameTextView { get; set; }
        private TextView monkeyLocationTextView { get; set; }
        private TextView monkeyPopulationTextView { get; set; }
        private TextView monkeyDetailsTextView { get; set; }
        private ImageView monkeyImageView { get; set; }
        public MonkeyDetailFragment(Monkey monkey)
        {
            _monkey = monkey;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_monkey_detail, container, false);

            monkeyNameTextView = view.FindViewById<TextView>(Resource.Id.monkeyNameTextView);
            monkeyLocationTextView = view.FindViewById<TextView>(Resource.Id.monkeyLocationTextView);
            monkeyPopulationTextView = view.FindViewById<TextView>(Resource.Id.monkeyPopulationTextView);
            monkeyDetailsTextView = view.FindViewById<TextView>(Resource.Id.monkeyDetailsTextView);
            monkeyImageView = view.FindViewById<ImageView>(Resource.Id.monkeyImageView);

            Glide.With(this).Load(_monkey.Image.ToString()).CenterCrop().Override(200, 200).Into(monkeyImageView);
            monkeyNameTextView.Text = _monkey.Name;
            monkeyLocationTextView.Text = _monkey.Location;
            monkeyPopulationTextView.Text = _monkey.Population.ToString();
            monkeyDetailsTextView.Text = _monkey.Details;

            return view;
        }

        //private async void LightSwitchFloatingActionButton_Click(object sender, EventArgs e)
        //{
        //    await SmartHomeCloudService.Controller.ChangeLightBulbState(_lightBulb, !_lightBulbState);
        //    var lightsEnumerable = await SmartHomeCloudService.Controller.GetLightBulbStatus();
        //    var lights = lightsEnumerable.ToList();
        //    _lightBulbState = lights.First(i => i.Id == _lightBulb).State;
        //    lightSwitchStatusTextView.Text = _lightBulbState ? "On" : "Off";
        //}

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
            var activity = context as MainActivity;
            activity._toolbar.Title = _monkey.Name;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace MonkeyFinder.Droid.ViewHolders
{
    public class MonkeyViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Name { get; set; }
        public TextView Location { get; set; }
        public MonkeyViewHolder(View view, Action<int> listener) : base(view)
        {
            Image = view.FindViewById<ImageView>(Resource.Id.monkeyImageView);
            Name = view.FindViewById<TextView>(Resource.Id.monkeyNameTextView);
            Location = view.FindViewById<TextView>(Resource.Id.monkeyLocationTextView);

            view.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
}
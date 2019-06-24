using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Bumptech.Glide;
using MonkeyFinder.Droid.ViewHolders;
using MonkeyFinder.Model;
using MonkeyFinder.ViewModel;

namespace MonkeyFinder.Droid.Adapters
{
    public class MonkeysRecyclerViewAdapter : RecyclerView.Adapter
    {
        private Context _context;
        private MonkeysViewModel _viewModel;
        public event EventHandler<int> ItemClick;
        public override int ItemCount => _viewModel.Monkeys.Count;

        public MonkeysRecyclerViewAdapter(Context context, MonkeysViewModel viewModel)
        {
            _context = context;
            _viewModel = viewModel;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MonkeyViewHolder vh = holder as MonkeyViewHolder;
            Glide.With(_context).Load(_viewModel.Monkeys[position].Image.ToString()).CenterCrop().Override(300, 400).Into(vh.Image);
            vh.Name.Text = _viewModel.Monkeys[position].Name;
            vh.Location.Text = _viewModel.Monkeys[position].Location;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.monkey_item, parent, false);
            MonkeyViewHolder vh = new MonkeyViewHolder(view, OnClick);
            return vh;
        }

        void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }
    }
}
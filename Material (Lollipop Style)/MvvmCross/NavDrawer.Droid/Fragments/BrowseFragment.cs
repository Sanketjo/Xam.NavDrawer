

using System;
using System.Collections.Generic;

using Android.Content;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

using NavDrawer.Activities;
using NavDrawer.Adapters;
using NavDrawer.Models;
using NavDrawer.Droid;
using Android.Runtime;
using Cirrious.MvvmCross.Droid.FullFragging.Fragments;
using NavDrawer.Core.ViewModels;

namespace NavDrawer.Fragments
{
    [Register("navdrawer.fragments.BrowseFragment")]
    public class BrowseFragment : MvxFragment<BrowseViewModel>
    {

        public BrowseFragment()
        {
            this.RetainInstance = true;
        }
        private List<Friend> _friends;
        public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            SetHasOptionsMenu (true);
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.fragment_browse, null);

            var grid = view.FindViewById<GridView>(Resource.Id.grid);
            _friends = Util.GenerateFriends();
            grid.Adapter = new MonkeyAdapter(Activity, _friends);
            grid.ItemClick += GridOnItemClick;
            return view;
        }

        private void GridOnItemClick(object sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
        {
            /*var intent = new Intent(Activity, typeof(FriendActivity));
            intent.PutExtra("Title", _friends[itemClickEventArgs.Position].Title);
            intent.PutExtra("Image", _friends[itemClickEventArgs.Position].Image);
            StartActivity(intent);*/
        }

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            inflater.Inflate(Resource.Menu.refresh, menu);
        }
    }
}
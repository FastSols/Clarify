using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace App4.FragFolder
{
    public class DefaultFrag : Fragment
    {
      public  int id;
        public override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            // Create your fragment here

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Dashboard, container, false);

            Button profile = view.FindViewById<Button>(Resource.Id.profile);
            Button questions = view.FindViewById<Button>(Resource.Id.questiions);
            Button videos = view.FindViewById<Button>(Resource.Id.videos);
            Button history = view.FindViewById<Button>(Resource.Id.History);
            Button subscription = view.FindViewById<Button>(Resource.Id.Subscription);
            Button feedback = view.FindViewById<Button>(Resource.Id.Feedbacks);
            id = Arguments.GetInt("StudId");
            Toast.MakeText(Context, id.ToString(), ToastLength.Long).Show();

            profile.Click += profileClick;
            questions.Click += questionClick;
            videos.Click += videosClick;

            return view;
           
        }
        void profileClick(Object sender,EventArgs eventArgs)
        {
            var prof = new profileFrag();
            FragmentManager.BeginTransaction()
                            .Replace(Resource.Id.frameLayout1, prof).Commit();
                            
        }
        void questionClick(Object sender, EventArgs eventArgs)
        {
            Bundle bundle = new Bundle();
            bundle.PutInt("StudId", id);
            var prof = new questionsFrag();
            prof.Arguments = bundle;
            FragmentManager.BeginTransaction()
                            .Replace(Resource.Id.frameLayout1, prof).Commit();

        }
        void videosClick(Object sender,EventArgs eventArgs)
        {
            Bundle bundle = new Bundle();
            bundle.PutInt("StudId", id);
            var prof = new getSolutionFrag();
            prof.Arguments = bundle;
            FragmentManager.BeginTransaction()
                            .Replace(Resource.Id.frameLayout1, prof).Commit();
        }
    }
}
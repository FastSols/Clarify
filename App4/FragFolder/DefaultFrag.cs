using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        int newid;
        SqlDataReader reader;
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
            try
            {
                SqlConnection connection = new SqlConnection("server=tcp:fastsols.database.windows.net,1433;Initial Catalog=UserDetails;Persist Security Info=False;User ID=system123;Password=Hornyporny@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                connection.Open();
                string query = "select Question_id from LiveQuestion where Student_id = '" + id + "';";
                SqlCommand cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                reader.Read();
                newid = Int32.Parse(reader["Question_id"].ToString());
                Toast.MakeText(Context, id.ToString(), ToastLength.Long).Show();
                connection.Close();
            }
            catch (Exception)
            {

                throw;
            }



            Bundle bundle = new Bundle();
            bundle.PutInt("StudId", id);
            bundle.PutInt("Qid",newid );
            var prof = new getSolutionFrag();
            prof.Arguments = bundle;
            FragmentManager.BeginTransaction()
                            .Replace(Resource.Id.frameLayout1, prof).Commit();
        }
    }
}
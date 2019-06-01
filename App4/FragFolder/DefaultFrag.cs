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
      public  int sid;
        int newid,tid;
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
           
            sid = Arguments.GetInt("StudId");
            tid = Arguments.GetInt("TeachId");
            Toast.MakeText(Context, sid.ToString(), ToastLength.Long).Show();

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
            bundle.PutInt("StudId", sid);
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

                string query = "select Question_Id from DataRefernce where Student_Id = '" + sid + "';";

                SqlCommand cmd = new SqlCommand(query, connection);

                reader = cmd.ExecuteReader();

                reader.Read();

                newid = Int32.Parse(reader["Question_Id"].ToString());

                Toast.MakeText(Context, sid.ToString(), ToastLength.Long).Show();

                connection.Close();

            }

            catch (Exception)

            {



                Toast.MakeText(Context, "Error", ToastLength.Long).Show();

            }



            Bundle bundle = new Bundle();
            bundle.PutInt("StudId", sid);
              bundle.PutInt("Qid",newid );
            var prof = new getSolutionFrag();
            prof.Arguments = bundle;
            FragmentManager.BeginTransaction()
                            .Replace(Resource.Id.frameLayout1, prof).Commit();
        }
    }
}
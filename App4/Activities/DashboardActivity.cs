using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
namespace App4.Activities
{
    [Activity(Label = "DashboardActivity")]
    public class DashboardActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Dashboard);
            Button profilebutton = FindViewById<Button>(Resource.Id.profile);
            profilebutton.Click += profileClick;

            try
            {
                //  Toast.MakeText(this, "Logged In", ToastLength.Long).Show();
                string username = Intent.Extras.GetString("username");
                string password = Intent.Extras.GetString("password");

                string con_query = "Server=tcp:fastsols.database.windows.net,1433;Initial Catalog=UserDetails;Persist Security Info=False;User ID=system123;Password=Hornyporny@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                string command = "select * from SignInDetails where Email = '" + username + "'";
                SqlConnection con = new SqlConnection(con_query);
                con.Open();
                Toast.MakeText(this, con.State.ToString(), ToastLength.Long).Show();
                SqlCommand sqlCommand = new SqlCommand(command, con);
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                Toast.MakeText(this, username + " " + password, ToastLength.Long).Show();
                if (dataReader.Read())
                {
                    Toast.MakeText(this, "Logged In", ToastLength.Long).Show();
                }
            }
            catch (Exception e)
            {
            }


            void profileClick(Object sender, EventArgs eventArgs)
            {
              

                var p = new Intent(this, typeof(ProfileActivity));

                StartActivity(p);
            }


            
            Button Ques = FindViewById<Button>(Resource.Id.questiions);
            Ques.Click += quesClick;
            void quesClick(Object sender, EventArgs eventArgs)
            {
                


                var p = new Intent(this, typeof(QuestionActivity));
                StartActivity(p);
            }


            Button Videos = FindViewById<Button>(Resource.Id.videos);
            Videos.Click += videoClick;
            void videoClick(Object sender, EventArgs eventArgs)
            {
                var p = new Intent(this, typeof(VideoActivity));
                StartActivity(p);
            }


           /* Button History = FindViewById<Button>(Resource.Id.History);
            History.Click += HistoryClick;
            void HistoryClick(Object sender, EventArgs eventArgs)
            {
                var h = new Intent(this, typeof(HistoryActivity));
                StartActivity(h);
            }


            Button Subscript = FindViewById<Button>(Resource.Id.Subscription);
            Subscript.Click += SubscriptClick;
            void SubscriptClick(Object sender, EventArgs eventArgs)
            {
                var s = new Intent(this, typeof(SubscriptionActivity));
                StartActivity(s);
            }

            //  SetContentView(Resource.Layout.SignIn);
            Button Feedback = FindViewById<Button>(Resource.Id.Feedbacks);
            Feedback.Click += FeedbackClick;
            void FeedbackClick(Object sender, EventArgs eventArgs)
            {
                var f = new Intent(this, typeof(FeedbackActivity));
                StartActivity(f);
            }
            */
        }
      

    }
}
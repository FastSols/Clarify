using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Data.SqlClient;
namespace App4.Activities
{
    [Activity(Label = "AskActivity")]
    public class AskActivity : Activity
    {
        EditText question;
        SqlConnection connection;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Search);
             connection = new SqlConnection("server=tcp:fastsols.database.windows.net,1433;Initial Catalog=UserDetails;Persist Security Info=False;User ID=system123;Password=Hornyporny@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
           
             question = FindViewById<EditText>(Resource.Id.askedquestion);
            Button ask = FindViewById<Button>(Resource.Id.ask);
            ask.Click += asked;
            // Create your application here
        }
        void asked(Object sender, EventArgs eventArgs)
        {
            connection.Open();
            string sql = "insert into LiveQuestion(Question_id,Student_id,Domain,Question,Accept,Answered,Answer_Count) values (4,4,'DS','"+question.Text+"',0,0,0);";

            SqlCommand cmd = new SqlCommand(sql, connection);
            int i = cmd.ExecuteNonQuery();
            Toast.MakeText(this, i.ToString(), ToastLength.Long).Show();
        }
    }
}
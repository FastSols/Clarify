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
using App4.FragFolder;
namespace App4.FragFolder
{
    public class searcgFrag : Fragment
    {
        EditText question;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view;
            view = inflater.Inflate(Resource.Layout.Search,container,false);
            Button ask = view.FindViewById<Button>(Resource.Id.ask);
             question = view.FindViewById<EditText>(Resource.Id.askedquestion);

            ask.Click += askClick;

            return view;
        }

        void askClick(Object sender, EventArgs eventArgs)
        {
            Random r = new Random(10);
            int x = r.Next(10000);
            int y = r.Next(10000);
            var con = connect();
            string sql = "insert into LiveQuestion(Question_id,Student_id,Domain,Question,Accept,Answered,Answer_Count) values ('"+x+"','" + y + "','DS','" + question.Text + "',0,0,0);";
            try
            {

                SqlCommand cmd = new SqlCommand(sql, con);
                int i = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
          //  Toast.MakeText(this, i.ToString(), ToastLength.Long).Show();
        }

        SqlConnection connect()
        {
            SqlConnection connection = new SqlConnection("server=tcp:fastsols.database.windows.net,1433;Initial Catalog=UserDetails;Persist Security Info=False;User ID=system123;Password=Hornyporny@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            connection.Open();


            return connection;
        }
    }
}
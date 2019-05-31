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
    [Activity(Label = "QuestionActivity")]
    public class QuestionActivity : Activity
    {
        ListView listView;
        string[] items;
        ArrayAdapter ListAdapter = null;
        SqlDataReader reader;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Question);
            List<String> items = new List<String>();
            SqlConnection connection = new SqlConnection("server=tcp:fastsols.database.windows.net,1433;Initial Catalog=UserDetails;Persist Security Info=False;User ID=system123;Password=Hornyporny@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            connection.Open();
            string query = "select Question from LiveQuestion;";
            SqlCommand cmd = new SqlCommand(query, connection);
             reader = cmd.ExecuteReader();
            reader.Read();
            do
            {
                items.Add(reader["Question"].ToString());


            }
            while (reader.Read());
            connection.Close();

             listView = FindViewById<ListView>(Resource.Id.listView1);
            // Create your application here
            


            ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
            listView.Adapter = ListAdapter;
           
            listView.ItemClick += list_item_clicked;



        }

        void list_item_clicked(Object sender, AdapterView.ItemClickEventArgs e)
        {

            Toast.MakeText(this, listView.GetItemAtPosition(e.Position).ToString(), ToastLength.Long).Show();

            var intent = new Intent(this, typeof(AnswerActivity));
            intent.PutExtra("QuestionId", listView.GetItemAtPosition(e.Position).ToString());
            StartActivity(intent);
        }
    }
}

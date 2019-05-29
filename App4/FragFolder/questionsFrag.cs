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
    public class questionsFrag : Fragment
    {
        ListView listView;
        string[] items;
        ArrayAdapter ListAdapter = null;
        SqlDataReader reader;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Question, container, false);

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

            listView = view.FindViewById<ListView>(Resource.Id.listView1);
            // Create your application here



            ListAdapter = new ArrayAdapter<String>(Context, Android.Resource.Layout.SimpleListItem1, items);
            listView.Adapter = ListAdapter;

            listView.ItemClick += list_item_clicked;

            return view;

        }

        void list_item_clicked(Object sender, AdapterView.ItemClickEventArgs e)
        {

            // Toast.MakeText(this, listView.GetItemAtPosition(e.Position).ToString(), ToastLength.Long).Show();

            var ques = new answerFrag();
            FragmentManager.BeginTransaction()
                            .Replace(Resource.Id.frameLayout1, ques).Commit();
        }

    }
   
}

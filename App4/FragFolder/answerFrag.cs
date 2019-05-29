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
using Plugin.FilePicker;

namespace App4.FragFolder
{
    public class answerFrag : Fragment
    {
        EditText answerText;
        Random r = new Random(10);
        Random r2 = new Random(10);
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Answerpage, container, false);
            Button answer = view.FindViewById<Button>(Resource.Id.SearchFile);
            Button upload = view.FindViewById<Button>(Resource.Id.Submit);
             answerText = view.FindViewById<EditText>(Resource.Id.editText1);
            answer.Click += searchclick;
            upload.Click += uploadclick;

            return view;
        }
        

            void searchclick(Object Sender, EventArgs eventArgs)
            {
                try
                {
                    var file = CrossFilePicker.Current.PickFile();
                    file.ToString();
                }
                catch (Exception e)
                {
                
                }

            }

        void uploadclick(Object sender, EventArgs eventArgs)
        {

            int x = r.Next();
            int y = r2.Next();


            //
            string sql = "insert into AnswerTable(QUESTIONID,ANSWER,ANSWERID) values ('" + x+ "','"+ answerText.Text+ "','"+y+"');";
            try
            {

                var con = connect();
              
                SqlCommand cmd = new SqlCommand(sql, con);
                int i = cmd.ExecuteNonQuery();
                Toast.MakeText(Context, i.ToString(), ToastLength.Long).Show();
                // Toast.MakeText(this, i.ToString(), ToastLength.Long).Show();


            }
            catch (Exception e)
            {
                Toast.MakeText(Context, e.ToString(), ToastLength.Long).Show();
            }
        }
        SqlConnection connect()
        {
            SqlConnection connection = new SqlConnection("server=tcp:fastsols.database.windows.net,1433;Initial Catalog=UserDetails;Persist Security Info=False;User ID=system123;Password=Hornyporny@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            connection.Open();


            return connection;
        }
    }
}
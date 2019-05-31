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
    [Activity(Label = "SignInActivity", MainLauncher = true)]
    public class SignInActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SignIn);
            // Create your application here

            Button signingbutton = FindViewById<Button>(Resource.Id.login);
            signingbutton.Click += loginClick;

            void loginClick(Object sender, EventArgs eventArgs)
            {
                Toast.MakeText(this, "inside event", ToastLength.Long).Show();
                TextView email = FindViewById<TextView>(Resource.Id.email_address);
                TextView password = FindViewById<TextView>(Resource.Id.password_text);
                string command = "select * from SignInDetails where Email = '" + email.Text + "' ";
                try
                {
                    SqlConnection con = new SqlConnection("server=tcp:fastsols.database.windows.net,1433;Initial Catalog=UserDetails;Persist Security Info=False;User ID=system123;Password=Hornyporny@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                    con.Open();
                    Toast.MakeText(this, con.State.ToString(), ToastLength.Long).Show();
                    SqlCommand sqlCommand = new SqlCommand(command, con);
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();
                    if (dataReader.Read())

                    {

                        if (password.Text == dataReader["Password"].ToString())
                        {
                           
                            Toast.MakeText(this, dataReader["Email"].ToString(), ToastLength.Long).Show();
                            var intent = new Intent(this, typeof(MainActivity));
                            intent.PutExtra("StudId", dataReader["StudId"].ToString()); ;
                            StartActivity(intent);

                        }
                    }
                }
                catch (Exception e)
                {

                }
                
                }

        }
    }
}

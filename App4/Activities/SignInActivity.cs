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
    [Activity(Label = "SignInActivity")]
    public class SignInActivity : Activity
    {
        TextView email;
        TextView password;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NewSignIn);
            // Create your application here
            //Button signup = FindViewById<Button>(Resource.Id.);
            Button signingbutton = FindViewById<Button>(Resource.Id.login);
            signingbutton.Click += loginClick;
         //   sidechanel.Click += signClick;
            void loginClick(Object sender, EventArgs eventArgs)
            {
                
                 email = FindViewById<TextView>(Resource.Id.email_address);
                 password = FindViewById<TextView>(Resource.Id.password_text);
                CheckBox student = FindViewById<CheckBox>(Resource.Id.studentcheck);
                CheckBox teacher = FindViewById<CheckBox>(Resource.Id.teachercheck);
               


                if (student.Checked)
                {
                    
                    string command = "select * from SignInDetails where Email = '" + email.Text + "' ";
                    try
                    {
                        Toast.MakeText(this, "inside event", ToastLength.Long).Show();
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
                else if(teacher.Checked)
                {
                    string command = "select * from TeacherSignIn where Email = '" + email.Text + "' ";

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
                                intent.PutExtra("TeachId", dataReader["Teacher_id"].ToString()); ;
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
}

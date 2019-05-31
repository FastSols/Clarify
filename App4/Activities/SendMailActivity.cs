using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SendGrid;
using SendGrid.Helpers;
using SendGrid.Helpers.Mail;

namespace App4.Activities
{
    [Activity(Label = "SendMailActivity")]
    public class SendMailActivity : Activity
    {
      static  Random r = new Random(9999);
        static string email = "";
        static string name1 = "";
        protected override void OnCreate(Bundle savedInstanceState)
        {
           
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Mail);
          string   username = Intent.GetStringExtra("EmailId");
            string name = Intent.GetStringExtra("name");
            email = username;
            name1 = name;           
            try {

                SendMail();
               
                Toast.MakeText(this,"Mail has been sent", ToastLength.Long).Show();
                var intent = new Intent(this, typeof(SignInActivity));

                StartActivity(intent);
            }
            
            catch (Exception e)
            {
            }

           // Toast.MakeText(this, "Inside Activity ", ToastLength.Long).Show();
        }

        static  async Task SendMail()
        {

            int i = r.Next() ;
            var client = new SendGridClient("");
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("chitalechinmay@outlook.com", "CLARIFY TEAM"),
                Subject = "Verification Mail",
               
                HtmlContent = "<Strong> Welcome "+name1+" please verify your account in below link</Strong>" +
              "<br>" +
                 "<a href='"+"instantsolution.co.in"+"'> Click Here</a>" +
                 "<Strong>your OTP is '"+i+"'</Strong>" 
               
            };
            msg.AddTo(new EmailAddress(email, "Test User"));
           await client.SendEmailAsync(msg);
          //  Toast.MakeText(null, "mail has been sent", ToastLength.Long).Show();

        }
    }

   
    // Create your application here
}
   

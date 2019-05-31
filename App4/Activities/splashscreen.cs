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

namespace App4.Activities
{
    [Activity(Label = "splashscreen", MainLauncher = true)]
    public class splashscreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here

            System.Threading.Thread.Sleep(100);

            var intent = new Intent(this, typeof(SignInActivity));

            StartActivity(intent);
            // Create your application here
        }
    }
}
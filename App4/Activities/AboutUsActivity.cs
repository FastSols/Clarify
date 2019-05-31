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
using Android.Webkit;

namespace App4.Activities
{
    [Activity(Label = "AboutUsActivity")]
    public class AboutUsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            WebView web_view;
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AboutUs);
            // Create your application here

            web_view = FindViewById<WebView>(Resource.Id.webView);
            web_view.Settings.JavaScriptEnabled = true;
            //  web_view.SetWebViewClient(new HelloWebViewClient())
            web_view.LoadUrl("https://prthm123.000webhostapp.com/team.html");
        }
    }
}
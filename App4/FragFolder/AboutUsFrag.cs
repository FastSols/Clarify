using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Webkit;
namespace App4.FragFolder
{
    public class AboutUsFrag : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            WebView web_view;
            View view = inflater.Inflate(Resource.Layout.AboutUs,container,false);
             web_view = view.FindViewById<WebView>(Resource.Id.webView);
            web_view.Settings.JavaScriptEnabled = true;
            //  web_view.SetWebViewClient(new HelloWebViewClient())
            web_view.LoadUrl("https://prthm123.000webhostapp.com/team.html");

            return view;
        }
    }
}
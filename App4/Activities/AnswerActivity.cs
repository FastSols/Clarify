using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Plugin.FilePicker;
using Android.Widget;
namespace App4.Activities
{
    [Activity(Label = "AnswerActivity")]
    public class AnswerActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Answerpage);
            string question  = Intent.Extras.GetString("QuestionId");
           TextView qtext = FindViewById<TextView>(Resource.Id.questiontext);
            Button search = FindViewById<Button>(Resource.Id.SearchFile);
            qtext.Text = question;
            search.Click += searchclick;

            void searchclick(Object Sender,EventArgs eventArgs)
            {
                try
                {
                    var file = CrossFilePicker.Current.PickFile();
                    file.ToString();
                }
                catch (Exception e)
                {
                    Toast.MakeText(this, e.ToString(), ToastLength.Long).Show();
                }

            }

           
                // Create your application here
        }
        
    }
}
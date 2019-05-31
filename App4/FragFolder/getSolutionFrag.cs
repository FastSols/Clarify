using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.Storage;

namespace App4.FragFolder
{
    public class getSolutionFrag : Fragment
    {
        SqlDataReader reader;
        string path1 = "/storage/emulated/0/Android/data/com.App4.App/Answers/";
        string path2,container;
        int id, qid;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Download, container, false);
            Button download = view.FindViewById<Button>(Resource.Id.download);
            Button check = view.FindViewById<Button>(Resource.Id.check);
            
            check.Click += checkClick;
            download.Click += downloadClick;

            return view;
        }

        void checkClick(Object sender ,EventArgs eventArgs)
        {
             id = Arguments.GetInt("StudId");
           qid = Arguments.GetInt("Qid");

            Toast.MakeText(Context, id.ToString() + " " + qid.ToString(), ToastLength.Long).Show();
            try
            {
                SqlConnection connection = new SqlConnection("server=tcp:fastsols.database.windows.net,1433;Initial Catalog=UserDetails;Persist Security Info=False;User ID=system123;Password=Hornyporny@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                connection.Open();
                string query = "select Container_Name ,Blob_Name from DataRefernce where Student_Id ='" + id + "' and Question_Id = '" + qid + "';";
                SqlCommand cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    path2 = reader["Blob_Name"].ToString();

                }
                connection.Close();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        void del()
        {
            SqlDataReader reader;

            try
            {
                SqlConnection connection = new SqlConnection("server=tcp:fastsols.database.windows.net,1433;Initial Catalog=UserDetails;Persist Security Info=False;User ID=system123;Password=Hornyporny@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                connection.Open();
                string query = "delete from DataRefernce where Student_Id ='" + id + "' and Question_Id = '" + qid + "';";
                SqlCommand cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();

                connection.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }
        void downloadClick(Object sender, EventArgs eventArgs)
        {
            string gpath = path1 + path2;
            //String path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
          //  var pathToNewFolder = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Pappu";
            Directory.CreateDirectory("/storage/emulated/0/Android/data/com.App4.App/Answers");
            
            DownloadFileAsync(path2,gpath);
            del();
        }

        public static async void DownloadFileAsync(String BlobPath, String DevicePath)

        {

            //FileStream stream = new FileStream(Path, FileMode.Open);

            var storageAccount = new CloudStorageAccount(new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials("clarify", "1uKpJnx1bKx+GWDsv+ZPbilsFxOO6lqd21XzyQixb2uGeHNPTHb1w1TaxKUlcMVDkAKezgj0Bb9Hb4+SHYb6Mg=="), true);



            var blobClient = storageAccount.CreateCloudBlobClient();



            var container = blobClient.GetContainerReference("answers");



            var blob = container.GetBlobReference(BlobPath);

            await blob.DownloadToFileAsync(DevicePath, FileMode.CreateNew);
            

        }

       
    }
}
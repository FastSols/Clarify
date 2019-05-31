using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;

namespace App4.FragFolder
{
    public class answerFrag : Fragment
    {
        EditText answerText;
        Random r = new Random(10);
        Random r2 = new Random(10);
        string path = null;
        int studid, qid;
        static int q1 = 0;
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
            answer.Click += searchclickAsync;
            upload.Click += uploadclick;
            studid = Arguments.GetInt("StudId");
            qid = Arguments.GetInt("Qid");
        //    q1 = Arguments.GetInt("Qid");
            Toast.MakeText(Context, qid.ToString()+" "+studid.ToString(), ToastLength.Long).Show();
            return view; 
        }
        

            async void searchclickAsync(Object Sender, EventArgs eventArgs)
            {
                try
                {
                FileData filedata = await CrossFilePicker.Current.PickFile();

                  path = filedata.FileName;
                
                }
                catch (Exception e)
                {
                
                }

            }

        public void uploadclick(Object sender, EventArgs eventArgs)
        {
            Toast.MakeText(Context, path, ToastLength.Long).Show();
            if (answerText == null)
            {
                
                int y = r2.Next();


                
                string sql = "insert into DataRefernce(Question_id,Student_id,Teacher_id,Container_Name,Blob_Name) values ('"+qid+"','"+studid+"','"+r+"',answers,'"+path+"');";
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

            else
            {
                int x = r.Next();
                String s = "answers";
                //FileStream stream = new FileStream(Path, FileMode.Open);
                string sql = "insert into DataRefernce(Question_id,Student_id,Teacher_id,Container_Name,Blob_Name) values ('" + qid + "','" + studid + "','"+x+"','"+s+"','" + path + "');";
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
                UploadFileAsync(path);


            }
        }
        SqlConnection connect()
        {
            SqlConnection connection = new SqlConnection("server=tcp:fastsols.database.windows.net,1433;Initial Catalog=UserDetails;Persist Security Info=False;User ID=system123;Password=Hornyporny@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            connection.Open();


            return connection;
        }

        public static async void UploadFileAsync(String Path)

        {

            //FileStream stream = new FileStream(Path, FileMode.Open);

            var storageAccount = new CloudStorageAccount(new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials("clarify", "1uKpJnx1bKx+GWDsv+ZPbilsFxOO6lqd21XzyQixb2uGeHNPTHb1w1TaxKUlcMVDkAKezgj0Bb9Hb4+SHYb6Mg=="), true);



            var blobClient = storageAccount.CreateCloudBlobClient();



            var container = blobClient.GetContainerReference("answers");

          await  container.CreateIfNotExistsAsync();

          await  container.SetPermissionsAsync(new BlobContainerPermissions()

            {

                PublicAccess = BlobContainerPublicAccessType.Blob

            });

            var blob = container.GetBlockBlobReference(Path);
            string final = "storage/emulated/0/Download/" + Path;
          await  blob.UploadFromFileAsync(final);
            
      /*    String q = "UPDATE LiveQuestion SET Answered = '"+true+"', WHERE Question_id = '" +q1+ "'; ";
            try
            {
                SqlConnection connection = new SqlConnection("server=tcp:fastsols.database.windows.net,1433;Initial Catalog=UserDetails;Persist Security Info=False;User ID=system123;Password=Hornyporny@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                connection.Open();

                SqlCommand cmd = new SqlCommand(q, connection);
                int i = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
           // Toast.MakeText(this, i.ToString(), ToastLength.Long).Show();
      */  }
    }
}
using System;
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using App4.Activities;
using App4.FragFolder;
namespace App4
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        int id = 0;
        int sid, tid;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

           

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            if (Android.Support.V4.Content.ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) != (int)Permission.Granted)
            {
                Android.Support.V4.App.ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.WriteExternalStorage }, 0);
            }

            if (Android.Support.V4.Content.ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) != (int)Permission.Granted)
            {
                Android.Support.V4.App.ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.ReadExternalStorage }, 0);
            }
           
            if (Intent.GetStringExtra("StudId") != null)
            {
                String id = Intent.GetStringExtra("StudId");
              sid  = Int32.Parse(id.ToString());
            }
            if (Intent.GetStringExtra("TeachId") != null)
            {
                String Tid = Intent.GetStringExtra("TeachId");
                tid = Int32.Parse(Tid.ToString());
            }

           
            //Toast.MakeText(this, id, ToastLength.Long).Show();


            Bundle bundle = new Bundle();
            bundle.PutInt("StudId",sid);
            bundle.PutInt("TeachId",tid);
            var def = new DefaultFrag();
           def.Arguments = bundle;
            FragmentManager.BeginTransaction()
                            .Add(Resource.Id.frameLayout1, def,"defaultFrag")
                            .Commit();
        }
        
        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }
        
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            if (e.KeyCode == Keycode.Back)
            {
                
                if(FragmentManager.BackStackEntryCount!=0)
                FragmentManager.PopBackStack();
            }

            return base.OnKeyDown(keyCode, e);
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
          

            if (id == Resource.Id.signup)
            {
                //FragmentTransaction fragmentTransaction = this.FragmentManager.BeginTransaction();
               

                var intent = new Android.Content.Intent(this, typeof(Activity1));
                StartActivity(intent);
            }
            else if (id == Resource.Id.signin)
            {
                var intent = new Android.Content.Intent(this, typeof(SignInActivity));
                StartActivity(intent);
            }
            else if (id == Resource.Id.dashboard)
            {
                var def = new DefaultFrag();
                FragmentManager.BeginTransaction()
                                .Replace(Resource.Id.frameLayout1, def)
                                .Commit();
            }
            else if (id == Resource.Id.ask)
            {
                String idd = Intent.GetStringExtra("StudId");
                //Toast.MakeText(this, id, ToastLength.Long).Show();

                int i = Int32.Parse(idd.ToString());
                Bundle bundle = new Bundle();
                bundle.PutInt("StudId", i);

              
                            
                var search = new searcgFrag();
                search.Arguments = bundle;
                FragmentManager.BeginTransaction()
                                .Add(Resource.Id.frameLayout1,search,"Ask")
                                .Commit();
            }
            else if (id == Resource.Id.about)
            {
                var answer = new AboutUsFrag();
                
                FragmentManager.BeginTransaction()
                                .Add(Resource.Id.frameLayout1, answer, "Ask")
                                .Commit();
            }
            else if (id == Resource.Id.answer)
            {
                
                String iid = Intent.GetStringExtra("StudId");
                //Toast.MakeText(this, id, ToastLength.Long).Show();

                int i = Int32.Parse(iid.ToString());
                Bundle bundle = new Bundle();
                bundle.PutInt("StudId", i);
                var answer = new answerFrag();
                answer.Arguments = bundle;
                FragmentManager.BeginTransaction()
                                .Add(Resource.Id.frameLayout1, answer, "Ask")
                                .Commit();
            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
    }
}


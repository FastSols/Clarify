using System;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using App4.Activities;
using App4.FragFolder;
namespace App4
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
       
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

            var def = new DefaultFrag();
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

                FragmentManager.BeginTransaction().AddToBackStack("defaultFrag");
                            
                var search = new searcgFrag();
                FragmentManager.BeginTransaction()
                                .Add(Resource.Id.frameLayout1,search,"Ask")
                                .Commit();
            }
            else if (id == Resource.Id.about)
            {
                var intent = new Android.Content.Intent(this, typeof(AboutUsActivity));
                StartActivity(intent);
            }
            else if (id == Resource.Id.answer)
            {
                var answer = new answerFrag();
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


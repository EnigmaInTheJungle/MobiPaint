using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using System.Collections.Generic;
using Android.Support.V7.Widget;

namespace MobilePaint.Droid
{
    [Activity(Label = "MobilePaint.Android", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class MainActivity : ActionBarActivity
    {
        private SupportToolbar mToolbar;
        private SupportToolbar bToolbar;
        private LeftMenuToggler mDrawerToggle;
        private DrawerLayout mDrawerLayout;
        private ListView mLeftDrawer;
        private DrawPanel drawPanel;
        public XCommand Command { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Command = new XCommand();


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            drawPanel = FindViewById<DrawPanel>(Resource.Id.drawFiheld);
            drawPanel.command = Command;

            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(mToolbar);

            bToolbar = FindViewById<SupportToolbar>(Resource.Id.lower_toolbar);
            bToolbar.InflateMenu(Resource.Menu.bot_menu);
            bToolbar.MenuItemClick += bToolbar_Click;

            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.left_menu);

            Dictionary<string, string[]> menu = new Dictionary<string, string[]>();
            menu.Add("File", new string[] { "New", "Open", "Save", "Save as..", "Save in cloud", "Load from cloud", "Exit" });
            menu.Add("Window", new string[] { "Rename", "Close", "Close all"});
            menu.Add("Figure", new string[] { "Line", "Rectangle", "Ellipse" });
            menu.Add("Plugins", new string[] { "Simple Figure", "Figure with text"});
            menu.Add("Skins", new string[] { "Dark", "Light", "Pink"});
            menu.Add("Language", new string[] { "English", "Ukrainian", "Russian"});
            menu.Add("Help", new string[] { "About..", "Show help.."});


            mLeftDrawer.Adapter = new CustomAdapter(Command,this, menu);

            mDrawerToggle = new LeftMenuToggler(
                this,                           //Host Activity
                mDrawerLayout,                  //DrawerLayout
                Resource.String.openDrawer,     //Opened Message
                Resource.String.closeDrawer     //Closed Message
            );

            mDrawerLayout.SetDrawerListener(mDrawerToggle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            mDrawerToggle.SyncState();

        }

        private void bToolbar_Click(object sender, SupportToolbar.MenuItemClickEventArgs e)
        {
            switch (e.Item.ItemId)
            {
                case Resource.Id.action_newtab: Toast.MakeText(this, "NewTab clicked", ToastLength.Short).Show(); break;
                case Resource.Id.action_color: Toast.MakeText(this, "Color clicked", ToastLength.Short).Show(); break;
                case Resource.Id.action_figure: Toast.MakeText(this, "Figure clicked", ToastLength.Short).Show(); break;
                case Resource.Id.action_width: Toast.MakeText(this, "Width clicked", ToastLength.Short).Show(); break;
                case Resource.Id.action_text: Toast.MakeText(this, "Text clicked", ToastLength.Short).Show(); break;
                case Resource.Id.action_image: Toast.MakeText(this, "Image clicked", ToastLength.Short).Show(); break;
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    mDrawerToggle.OnOptionsItemSelected(item);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            mDrawerToggle.OnConfigurationChanged(newConfig);
        }
    }
}



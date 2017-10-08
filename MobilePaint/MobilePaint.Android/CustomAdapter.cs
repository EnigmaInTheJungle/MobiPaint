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


namespace MobilePaint.Droid
{
    public class CustomAdapter : BaseAdapter<KeyValuePair<string, string[]>>
    {
        public XCommand Command { get; set; }

        Dictionary<string, string[]> items;
        Activity context;
        public CustomAdapter(XCommand command,Activity context, Dictionary<string,string[]> items) : base() {
            this.context = context;
            this.items = items;
            Command = command;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override KeyValuePair<string, string[]> this[int position]
        {
            get { return items.ElementAt(position); }
        }
        public override int Count
        {
            get { return items.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an existing view, if one is available
            if (view == null) // otherwise create a new one
                view = context.LayoutInflater.Inflate(Resource.Layout.PopUp, null);
            view.FindViewById<Button>(Resource.Id.pop_btn).Text = this[position].Key;
            view.FindViewById<Button>(Resource.Id.pop_btn).Click += (s, arg) =>
            {
                PopupMenu menu = new PopupMenu(context, view.FindViewById<Button>(Resource.Id.pop_btn));
                //menu.Inflate(Resource.Menu.popup_menu);
                foreach(string name in this[position].Value)
                {
                    menu.Menu.Add(name);
                }
                menu.MenuItemClick += (s1, arg1) => {
                    //Toast.MakeText(context, arg1.Item.ToString(), ToastLength.Long).Show();
                    switch (arg1.Item.ToString())
                    {
                        case "Line": Command.Type.Action("Line"); break;
                        case "Rectangle": Command.Type.Action("Rectangle"); break;
                        case "Ellipse": Command.Type.Action("Ellipse"); break;
                    }
                };

                menu.Show();
            };

            return view;
        }

        //private void OnShowDialog(object sender, EventArgs e)
        //{
        //    if (sender == colorToolStripMenuItem1 || sender == colorToolStripMenuItem)
        //    {
        //        ColorDialog cd = new ColorDialog();
        //        if (cd.ShowDialog() == DialogResult.OK)
        //        {
        //            if (sender == colorToolStripMenuItem1)
        //                Command.TextColor.Action(cd.Color);
        //            else
        //                Command.Color.Action(cd.Color);
        //        }
        //    }
        //    else if (sender == saveToolStripMenuItem)
        //    {
        //        SaveFileDialog dlgSave = new SaveFileDialog();
        //        string[] ext = { "JSON (*.json)|*.json", "XML (*.xml) | *.xml", "YAML (*.yaml)|*.yaml" };
        //        dlgSave.Filter = String.Join("|", ext);
        //        if (dlgSave.ShowDialog() == DialogResult.OK)
        //        {
        //            Command.Save.Action(dlgSave.FileName);
        //        }
        //    }
        //    else if (sender == openToolStripMenuItem)
        //    {
        //        OpenFileDialog dlgOpen = new OpenFileDialog();
        //        string ext = "SO (*.json; *.xml; *.yaml)| *.json; *.xml; *.yaml";
        //        dlgOpen.Filter = ext;
        //        if (dlgOpen.ShowDialog() == DialogResult.OK)
        //        {
        //            Command.Open.Action(dlgOpen.FileName);
        //        }
        //    }
        //}

    }
}
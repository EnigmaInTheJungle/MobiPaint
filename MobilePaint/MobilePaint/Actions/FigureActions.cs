using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MobilePaint.Figure;

namespace MobilePaint.Actions
{
    public class FigureActions
    {
        //public class ActionChangeColor : IAction
        //{
        //    ICommand cmd;

        //    public ActionChangeColor(ICommand cmd)
        //    {
        //        this.cmd = cmd;
        //    }

        //    public void Action(object sender, EventArgs e)
        //    {
        //        var colorPicker = new ColorPickerView();
        //        colorPicker.ColorPicked += (sender, e) => {
        //            var color = e.SelectedColor;

        //            // use selected color
        //        };
        //    }
        //}

        public class ActionChangeType
        {
            XCommand cmd;
            public ActionChangeType(XCommand cmd)
            {
                this.cmd = cmd;
            }
            public void Action(string type)
            {
                //if (sender is ToolStripMenuItem)
                //    type = (sender as ToolStripMenuItem).Text;
                //else if (sender is ToolStripComboBox)
                //    type = (sender as ToolStripComboBox).SelectedItem.ToString();

                switch (type)
                {
                    case "Rectangle": cmd.Data.Type = FType.Rect; break;
                    case "Ellipse": cmd.Data.Type = FType.Ellipse; break;
                    case "Line": cmd.Data.Type = FType.Line; break;
                }
            }
        }
    }
}

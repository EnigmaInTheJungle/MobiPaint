using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePaint.Actions;

namespace MobilePaint
{
    public class XCommand
    {
        //public FigureActions.ActionWidth Width;
        //public FigureActions.ActionColor Color;
        public FigureActions.ActionChangeType Type;

        public XData Data = new XData();
        
        public XCommand()
        {
            //Width = new FigureActions.ActionWidth(this);
            //Color = new FigureActions.ActionColor(this);
            Type = new FigureActions.ActionChangeType(this);
        }
    }
}

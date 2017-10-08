using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MobilePaint.Figure;

namespace MobilePaint
{
    public class XData
    {
        public Android.Graphics.Color Color { get; set; }
        public int Width { get; set; }
        public FType Type { get; set; }

        public XData()
        {
            Color = Android.Graphics.Color.Black;
            Width = 1;
            Type = FType.Rect;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePaint.Actions
{
    public interface IAction
    {
        void Action(object sender, EventArgs e);
    }
}

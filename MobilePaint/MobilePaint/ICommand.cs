using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePaint.Actions;

namespace MobilePaint
{
    public interface ICommand
    {
        IAction SaveAs { get; }
        IAction Open { get; }
        IAction Status { get; }
        IAction Save { get; }

        IAction AddPage { get; }
        IAction RemovePage { get; }
        IAction RenamePage { get; }
        IAction ActiveFigure { get; }
        IAction SelectPage { get; }
        IAction RemoveAllPages { get; }

        IAction ChangeLanguage { get; }

        IAction LoadCloud { get; }
        IAction SaveCloud { get; }

        IAction AddPlugin { get; }
        IAction RemovePlugin { get; }

        IAction ChangeSkin { get; }

        IData Data { get; set; }
    }
}

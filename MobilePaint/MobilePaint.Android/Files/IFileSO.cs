using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePaint.Files
{
    public interface IFileSO
    {
        void Save(List<Figure> lf);
        List<Figure> Open();
    }
}

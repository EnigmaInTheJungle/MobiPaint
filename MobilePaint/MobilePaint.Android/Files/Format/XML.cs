using Java.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MobilePaint.Files.Format
{
    
    public class XML : IFileSO
    {
        string path = "";
        public XML(string path)
        {
            this.path = path;
        }

        public List<Figure> Open()
        {
            throw new NotImplementedException();
        }

        public void Save(List<Figure> lf)
        {
            throw new NotImplementedException();
        }
    }
}

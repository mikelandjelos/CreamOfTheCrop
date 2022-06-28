using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace _18203
{
    internal interface IXMLLoad
    {
        void LoadData(XmlDocument dokument, Form forma); //forma dobije naziv fajla, preuzme ga i kao xmldoc prosledi dalje
    }
}

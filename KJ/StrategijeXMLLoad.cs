using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace _18203
{
    public class StrategijeXMLLoad : IXMLLoad
    {
        public void LoadData(XmlDocument dokument, Form forma)
        {
            foreach (XmlNode node in dokument.DocumentElement)
            {
                try
                {
                    string naziv = "";
                    naziv = node["Naziv"].InnerText;
                    List<Ocena> ocene = new List<Ocena>();

                    foreach (XmlNode ocena in node["Ocene"])
                    {
                        int naz = int.Parse(ocena["Name"].InnerText);
                        int min = int.Parse(ocena["Min"].InnerText);
                        int max = int.Parse(ocena["Max"].InnerText);

                        ocene.Add(new Ocena(naz, min, max));
                    }
                    Strategija nova = new Strategija(naziv, ocene);
                    ((Form1)forma).AddStrat(nova);
                    
                    if(((Form1)forma).LbxStrat.Items.Count != 0)
                    {
                        ((Form1)forma).EnableBtnPred();
                    }
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Odabran pogresni fajl");
                    break;
                }
                catch (Exception) 
                {
                    MessageBox.Show("Greska pri biranju fajla");
                }
            }
        }
    }
}

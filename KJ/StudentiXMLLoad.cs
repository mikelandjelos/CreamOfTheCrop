using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace _18203
{
    internal class StudentiXMLLoad : IXMLLoad
    {
        public void LoadData(XmlDocument dokument, Form forma)
        {
            foreach(XmlNode node in dokument.DocumentElement)
            {
                try
                {
                    int indeks = int.Parse(node["Indeks"].InnerText);
                    string imepred = node["Predmet"].InnerText;
                    Predmet pred = null;

                    foreach(Predmet predmet in ((Form1)forma).LbxPredmet.Items)
                    {
                        if (imepred == predmet.Naziv)
                        {
                            pred = predmet;
                        }
                        
                    }

                    if (pred == null)
                    {
                        MessageBox.Show("Dodati predmet: " + imepred);
                        return;
                    }

                    int usmp = int.Parse(node["Usmeni"].InnerText);
                    int brp = pred.Count;
                    Dictionary<string, int> poeni = new Dictionary<string, int>(brp);

                    if (brp > 0)
                    {
                        foreach (XmlNode item in node["Elementi"])
                        {
                            string ime = item["Name"].InnerText;
                            int osv = int.Parse(item["Value"].InnerText);
                            poeni.Add(ime, osv);
                        }
                    }
                    ((Form1)forma).AddStud(new Student(indeks, pred, usmp, poeni));
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

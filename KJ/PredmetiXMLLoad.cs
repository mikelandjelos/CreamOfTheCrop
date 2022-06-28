using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace _18203
{
    internal class PredmetiXMLLoad : IXMLLoad
    {
        public void LoadData(XmlDocument dokument, Form forma)
        {
            foreach(XmlNode node in dokument.DocumentElement)
            {
                try { 
                    string str = "";
                    str = node["Strategija"].InnerText;
                    Strategija strategija = null;

                    foreach(Strategija item in ((Form1)forma).LbxStrat.Items)
                    {
                        if (str == item.Naziv)
                        {
                            strategija = item;
                        }
                    }

                    if (strategija == null)
                    {
                        //smatra se da se strategija dodaje dodavanjem novog fajla
                        //ili dopisivanjem u vec postojeci fajl i ponovnim pokretanjem programa
                        MessageBox.Show("Dodati strategiju " + str);
                        return;
                    }

                    string naz = node["Naziv"].InnerText;
                    int min = int.Parse(node["UsmeniMinPct"].InnerText);
                    int max = int.Parse(node["UsmeniMaxPoena"].InnerText);

                    List<Item> elementi = new List<Item>();

                    foreach(XmlNode el in node["Elementi"])
                    {
                        string nazivel = el["Name"].InnerText;
                        int minel = 0;

                        if (el.SelectSingleNode("Min") != null) {
                             minel = int.Parse(el["Min"].InnerText);
                        }

                        int maxel = int.Parse(el["Max"].InnerText);

                        elementi.Add(new Item(nazivel, minel, maxel));
                    }

                   ((Form1)forma).AddPred(new Predmet(naz, strategija, max, min, elementi));

                    if (((Form1)forma).LbxPredmet.Items.Count != 0)
                    {
                        ((Form1)forma).EnableBtnStudent();
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

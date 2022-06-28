using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftverskiProjekat
{
    class PredmetXmlReader : MyXmlReader
    {
        public override XmlReadable[] ReadXml(string path)
        {
            Predmet pred = null;
            Strategija strat = null;
            string naziv = "", itemName = "";
            int minUsmeni = 0, maxUsmeni = 0, minP = 0, maxP = 0;
            List<Element> elementi = new List<Element>();
            DirectoryInfo dirInfo = DirectoryInfo.Instance();
            StrategijaXmlReader stratReader = new StrategijaXmlReader();
            try
            {
                if (!dirInfo.currentFiles.Contains(path))
                    throw new Exception("Ne postoji xml dokument za predmet!");
                xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                if (xmlDoc.DocumentElement.Name != "Predmet")
                    throw new Exception("Izabrani xml dokument nije validan!");
                foreach (XmlNode node in xmlDoc.DocumentElement) {
                    switch (node.Name) {
                        case "Strategija":
                            strat = stratReader.ReadXml($"strategija{node.InnerText}.xml")[0] as Strategija;
                            break;
                        case "Naziv":
                            naziv = node.InnerText;
                            break;
                        case "UsmeniMinPct":
                            minUsmeni = int.Parse(node.InnerText);
                            break;
                        case "UsmeniMaxPoena":
                            maxUsmeni = int.Parse(node.InnerText);
                            break;
                        case "Elementi":
                            foreach (XmlNode item in node) {
                                minP = maxP = 0;
                                itemName = "";
                                foreach (XmlNode tag in item) {
                                    switch (tag.Name) {
                                        case "Name":
                                            itemName = tag.InnerText;
                                            break;
                                        case "Min":
                                            minP = int.Parse(tag.InnerText);
                                            break;
                                        case "Max":
                                            maxP = int.Parse(tag.InnerText);
                                            break;
                                    }
                                }
                                elementi.Add(new Element(itemName, minP, maxP));
                            }
                            break;
                    }
                }
                pred = new Predmet(strat, minUsmeni, maxUsmeni, elementi.ToArray());
                pred.Naziv = naziv;
            }
            catch (Exception ex) {
                Console.WriteLine($"ERROR [PredmetXmlReader]: {ex.Message}");
            }
            XmlReadable[] returnVal = new XmlReadable[1];
            returnVal[0] = pred;
            return returnVal;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml;
namespace SoftverskiProjekat
{
    internal class StrategijaXmlReader : MyXmlReader
    {
        public StrategijaXmlReader() 
        {
        }

        public override XmlReadable[] ReadXml(string path)
        {
            DirectoryInfo dirInfo = DirectoryInfo.Instance();
            Strategija strat = null;
            string nazivStrat = "";
            int ocena = 0;
            int minPoena = 0, maxPoena = 0;
            List<Ocena> listOcene = new List<Ocena>();
            try
            {
                if (!dirInfo.currentFiles.Contains(path))
                    throw new Exception("Ne postoji xml dokument za strategiju!");
                xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                if (xmlDoc.DocumentElement.Name != "Strategija")
                    throw new Exception("Izabrani xml dokument nije validan!");
                foreach (XmlNode ocene in xmlDoc.DocumentElement) {
                    if (ocene.Name == "Naziv")
                    {
                        nazivStrat = ocene.InnerText;
                    }
                    else {
                        foreach (XmlNode item in ocene) {
                            foreach (XmlNode tag in item) {
                                switch (tag.Name) {
                                    case "Name":
                                        ocena = int.Parse(tag.InnerText);
                                        break;
                                    case "Min":
                                        minPoena = int.Parse(tag.InnerText);
                                        break;
                                    case "Max":
                                        maxPoena = int.Parse(tag.InnerText);
                                        break;
                                }
                            }
                            listOcene.Add(new Ocena(minPoena, maxPoena, ocena));
                        }
                    }
                }
                strat = new Strategija(nazivStrat, listOcene.ToArray());
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ERROR [StrategijaXmlReader]: {ex.Message}");
            }
            XmlReadable[] returnVal = new XmlReadable[1];
            returnVal[0] = strat;
            return returnVal;
        }
    }
}
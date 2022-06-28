using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SoftverskiProjekat
{
    class StudentXmlReader : MyXmlReader
    {
        public override XmlReadable[] ReadXml(string path)
        {
            DirectoryInfo dirInfo = DirectoryInfo.Instance();
            Student student = new Student();
            List<Student> studenti = new List<Student>();
            List<PredispitnaObaveza> elementi = new List<PredispitnaObaveza>();
            try
            {
                if (!dirInfo.currentFiles.Contains(path))
                    throw new Exception("Ne postoji xml fajl za studente!");
                xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                if (xmlDoc.DocumentElement.Name != "Studenti")
                    throw new Exception("Izabrani xml dokument nije validan!");
                foreach (XmlNode studentNode in xmlDoc.DocumentElement) {
                    foreach (XmlNode studentInfo in studentNode) {
                        switch (studentInfo.Name) {
                            case "Indeks":
                                student.Indeks = studentInfo.InnerText;
                                break;
                            case "Predmet":
                                PredmetXmlReader predmetReader = new PredmetXmlReader();
                                student.Predmet = predmetReader.ReadXml($"predmet{studentInfo.InnerText}.xml")[0] as Predmet;
                                break;
                            case "Usmeni":
                                student.Usmeni = int.Parse(studentInfo.InnerText);
                                break;
                            case "Elementi":
                                foreach(XmlNode item in studentInfo)
                                {
                                    string elementName = "";
                                    int elementValue = 0;
                                    foreach(XmlNode tag in item)
                                    {
                                        if (tag.Name == "Name")
                                            elementName = tag.InnerText;
                                        if (tag.Name == "Value")
                                            elementValue = int.Parse(tag.InnerText);
                                    }
                                    elementi.Add(new PredispitnaObaveza(elementName, elementValue));
                                }
                                break;
                        }
                        student.Elementi = elementi.ToArray();
                    }
                    studenti.Add(student);
                    student = new Student();
                    elementi = new List<PredispitnaObaveza>();
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"ERROR [StudentXmlReader]: {ex.Message}");
                return null;
            }
            return studenti.ToArray();
        }
    }
}

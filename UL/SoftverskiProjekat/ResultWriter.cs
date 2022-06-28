using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace SoftverskiProjekat
{
    class ResultWriter
    {
        XmlDocument doc;
        string filename;

        public ResultWriter() { }
        public ResultWriter(string filename)
        {
            this.filename = filename;
        }

        public bool Write(Student[] studenti)
        {
            try
            {
                doc = new XmlDocument();
                XmlNode root = doc.CreateElement("Ocene");
                doc.AppendChild(root);
                for (int i = 0; i < studenti.Length; i++) {
                    XmlNode student = doc.CreateElement("Student");
                    XmlNode indeks = doc.CreateElement("Indeks");
                    XmlNode ocena = doc.CreateElement("Ocena");
                    indeks.InnerText = studenti[i].Indeks;
                    ocena.InnerText = studenti[i].ZavrsnaOcena.ToString();
                    student.AppendChild(indeks);
                    student.AppendChild(ocena);
                    root.AppendChild(student);
                }
                doc.Save(filename);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ERROR: ResultWriter caught an exception! {ex.Message}");
                throw ex;
            }
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EvaluacijaOcena
{
    /// <summary>Klasa koja cuva listu Studenata.</summary>
    [XmlRoot(Const.S_ROOT_NAME)]
    public class ListaStudenata : IXMLDeserializable
    {
        [XmlIgnore]
        public string TagName {
            get {
                return Const.S_TAGNAME_STUDENT;
            }
        }

        [XmlArray(Const.S_LIST_NAME)]
        [XmlArrayItem("Student")]
        public List<Student> Studenti { get; set; }

        /// <summary>Default konstruktor.</summary>
        public ListaStudenata() 
        {
            Studenti = new List<Student>();
        }

        /// <summary>Metoda koja racuna ocenu za svakog studenta.</summary>
        /// <param name="lp">Lista predmeta u kojoj se trazi predmet cija se ocena racuna.</param>
        /// <param name="ls">Lista strategija u kojoj se traze predmeti.</param>
        public void izracunajOcene(ListaPredmeta lp, ListaStrategija ls)
        {
            foreach(Student student in this.Studenti) {
                Predmet predmet = lp[student.Predmet];
                if(student.Usmeni >= predmet.UsmeniMaxPoena / 100 * predmet.UsmeniMinPct) {
                    int nSumaBodova = student.sumItems(predmet);
                    nSumaBodova += Math.Min(student.Usmeni, predmet.UsmeniMaxPoena);
                    student.Ocena = predmet.izracunajOcenu(ls, nSumaBodova);
                }
                else {
                    student.Ocena = Const.N_MIN_OCENA;
                }
            }
        }
    }

    public class Student
    {
        [XmlElement("Indeks")]
        public int Indeks { get; set; }
        private string sPredmet;
        [XmlElement("Predmet")]
        public string Predmet { get { return sPredmet; } set { sPredmet = value.Trim(); } }
        [XmlElement("Usmeni")]
        public int Usmeni { get; set; }
        [XmlArray("Elementi")]
        [XmlArrayItem("Item")]
        public List<ItemStudent> Elementi { get; set; }
        [XmlElement("Ocena")]
        public int? Ocena { get; set; }

        /// <summary>Indekser za pristup predispitnoj obavezi na osnovu njenog imena.</summary>
        /// <param name="sNaziv">Ime predispitne obaveze kojoj se pristupa.</param>
        /// <returns>Predispitan obaveza sa zadatim imenom, a ukoliko ne postoji takva vraca predispitnu obavezu koja sigurno nije polozena.</returns>
        private ItemStudent this[string sNaziv] {
            get {
                foreach(ItemStudent itemS in this.Elementi) {
                    if(itemS.Name == sNaziv) {
                        return itemS;
                    }
                }
                return new ItemStudent();
            }
        }

        /// <summary>Default konstruktor.</summary>
        public Student()
        {
            this.Indeks = 0;
            this.Predmet = "";
            this.Usmeni = 0;
            this.Elementi = new List<ItemStudent>();
            this.Ocena = null;
        }

        /// <summary>Pomocna funkcija koja sabira poene sa predispitnih obaveza.</summary>
        /// <param name="predmet">Predmet za koji se sabiraju predispitne obaveze.</param>
        /// <returns>Broj poena osvojen na svim predispitnim obavezama, a ukoliko neka nije polozena vraca se negativan maksimalan broj poena.</returns>
        internal int sumItems(Predmet predmet)
        {
            int nSumaBodova = 0;
            foreach(ItemPredmet ip in predmet.Elementi) {
                if(this[ip.Name].Value >= ip.Min) {
                    nSumaBodova += Math.Min(this[ip.Name].Value, predmet[ip.Name].Max);
                }
                else {
                    return -(Const.N_MAX_POENA - 1);
                }
            }
            return nSumaBodova;
        }
    }

    /// <summary>Klasa koja modeluje predispitnu obavezu studenta.</summary>
    public class ItemStudent
    {
        private string sName;
        [XmlElement("Name")]
        public string Name { get { return sName; } set { sName = value.Trim(); } }
        [XmlElement("Value")]
        public int Value { get; set; }

        /// <summary>Default konstruktor.</summary>
        /// <remarks>Predispitna obaveza koja sigurno nije polozena.</remarks>
        public ItemStudent()
        {
            this.Name = "";
            this.Value = -(Const.N_MAX_POENA + 1);
        }
    }
}

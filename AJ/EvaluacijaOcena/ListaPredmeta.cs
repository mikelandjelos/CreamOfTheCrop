using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EvaluacijaOcena
{
    /// <summary>Klasa koja cuva listu Predmeta.</summary>
    [XmlRoot(Const.S_ROOT_NAME)]
    public class ListaPredmeta : IXMLDeserializable
    {
        [XmlIgnore]
        public string TagName { 
            get {
                return Const.S_TAGNAME_PREDMET;
            } 
        }

        [XmlArray(Const.S_LIST_NAME)]
        [XmlArrayItem("Predmet")]
        public List<Predmet> Predmeti { get; set; }

        /// <summary>Default konstruktor.</summary>
        public ListaPredmeta() 
        {
            Predmeti = new List<Predmet>();
        }

        /// <summary>Indekser za prstup Predmetu na osnovu imena Predmeta.</summary>
        /// <param name="sNaziv">Ime Predmeta koji se trazi.</param>
        /// <returns>Predmet sa zadatim imenom.</returns>
        public Predmet this[string sNaziv] {
            get {
                foreach(Predmet p in this.Predmeti) {
                    if(p.Naziv == sNaziv) {
                        return p;
                    }
                }
                Predmet pp = new Predmet(sNaziv);
                return pp;
            }
        }

        /// <summary>Operator + koji spaja dve liste, bez ponavljanja elemenata.</summary>
        /// <param name="lst1">Lista iz koje se dodaju elementi</param>
        /// <param name="lst2">Lista na koju se dodaju elementi.</param>
        /// <returns>Lista koja sadrzi samo razlicite elemente.</returns>
        public static ListaPredmeta operator+(ListaPredmeta lst1, ListaPredmeta lst2)
        {
            ListaPredmeta lst = new ListaPredmeta();
            lst.Predmeti.AddRange(lst2.Predmeti);
            lst.Predmeti.AddRange(lst1.Predmeti);
            lst.Predmeti = lst.Predmeti.Distinct().ToList();
            return lst;
        }

        /// <summary>Metoda koja menja svim predmetima u listi ime strategije.</summary>
        /// <param name="sImeStrategije">Ime strategije koje se postavlja svima.</param>
        public void promeniStrategijuSvima(string sImeStrategije)
        {
            foreach(Predmet p in this.Predmeti) {
                p.Strategija = sImeStrategije;
            }
        }
    }

    /// <summary>Klasa koja modeluje Predmet.</summary>
    public class Predmet
    {
        private string sStrategija;
        [XmlElement("Strategija")]
        public string Strategija { get { return sStrategija; } set { sStrategija = value.Trim(); } }
        private string sNaziv;
        [XmlElement("Naziv")]
        public string Naziv { get { return sNaziv; } set { sNaziv = value.Trim(); } }
        [XmlElement("UsmeniMinPct")]
        public int UsmeniMinPct { get; set; }
        [XmlElement("UsmeniMaxPoena")]
        public int UsmeniMaxPoena { get; set; }
        [XmlArray("Elementi")]
        [XmlArrayItem("Item")]
        public List<ItemPredmet> Elementi { get; set; }

        /// <summary>Indekser za pristup predispitnoj obavezni na osnovu njenog imena.</summary>
        /// <param name="sName">Ime predispitne obaveze.</param>
        /// <returns>Predispitna obaveza sa zadatim imenom. Ukoliko ne postoji predispitna obaveza sa zadatim imenom, vraca podrazumevanu predispitnu obavezu.</returns>
        public ItemPredmet this[string sName] 
        {
            get {
                foreach(ItemPredmet ip in this.Elementi) {
                    if(ip.Name == sName) {
                        return ip;
                    }
                }
                return new ItemPredmet();
            }
        }

        /// <summary>Konstruktor koji postavlja ime Predmeta.</summary>
        public Predmet(string sNaziv)
        {
            this.Strategija = "";
            this.Naziv = sNaziv;
            this.UsmeniMinPct = 0;
            this.UsmeniMaxPoena = 0;
            this.Elementi = new List<ItemPredmet>();
        }

        /// <summary>Default knstruktor koji postavlja ime Strategije na prazan string.</summary>
        /// <remarks>Nije mogao konstruktor sa podrazumevanim parametrom, jer program puca kod deserijalizacije.</remarks>
        public Predmet() : this("") { }

        public override bool Equals(object obj)
        {
            Predmet p = obj as Predmet;
            if(p != null) {
                return this.Naziv == p.Naziv;
            }
            return false;
        }

        public override int GetHashCode() => Naziv.GetHashCode();

        /// <summary>Metoda koja pronalazi Strategiju u listi Strategija i racuna ocenu na osnovu te Strategije.</summary>
        /// <param name="ls">Lista strategija u kojoj se trazi Strategija.</param>
        /// <param name="nSumaBodova">Broj bodova koje je osvojio student.</param>
        /// <returns>Ocena koja je izrcunata na osnovu broja bodova.</returns>
        public int? izracunajOcenu(ListaStrategija ls, int nSumaBodova) => ls[this.Strategija].izracunajOcenu(nSumaBodova);
    }

    /// <summary>Klasa koja modeluje predispitnu obavezu.</summary>
    public class ItemPredmet
    {
        private string sName;
        [XmlElement("Name")]
        public string Name { get { return sName; } set { sName = value.Trim(); } }
        [XmlElement("Min")]
        public int Min { get; set; }
        [XmlElement("Max")]
        public int Max { get; set; }

        /// <summary>Default konstruktor.</summary>
        /// <remarks>Default predispitna obaveza koja polaze sa ilo kojim brojem poena.</remarks>
        public ItemPredmet()
        {
            this.Name = "";
            this.Min = 0;
            this.Max = Const.N_MAX_POENA + 1;
        }
    }
}

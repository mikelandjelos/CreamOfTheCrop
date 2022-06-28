using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EvaluacijaOcena
{
    /// <summary>Klasa koja cuva listu Strategija.</summary>
    [XmlRoot(Const.S_ROOT_NAME)]
    public class ListaStrategija : IXMLDeserializable
    {
        [XmlIgnore]
        public string TagName {
            get {
                return Const.S_TAGNAME_STRATEGIJA;
            }
        }

        [XmlArray(Const.S_LIST_NAME)]
        [XmlArrayItem(Const.S_TAGNAME_STRATEGIJA)]
        public List<Strategija> Strategije { get; set; }

        /// <summary>Default konstruktor.</summary>
        public ListaStrategija() 
        {
            Strategije = new List<Strategija>();
        }

        /// <summary>Indekser za prstup Strategiji na osnovu imena Strategije.</summary>
        /// <param name="sNaziv">Ime Strategije koja se trazi.</param>
        /// <returns>Strategija sa zadatim imenom.</returns>
        public Strategija this[string sNaziv] 
        {
            get {
                foreach(Strategija s in this.Strategije) {
                    if(s.Naziv == sNaziv) {
                        return s;
                    }
                }
                Strategija ss = new Strategija(sNaziv);
                ItemStrategija itemS = new ItemStrategija();
                ss.Ocene.Add(itemS);
                return ss;
            }
        }

        public static ListaStrategija operator +(ListaStrategija lst1, ListaStrategija lst2)
        {
            ListaStrategija lst = new ListaStrategija();
            lst.Strategije.AddRange(lst2.Strategije);
            lst.Strategije.AddRange(lst1.Strategije);
            lst.Strategije = lst.Strategije.Distinct().ToList();
            return lst;
        }
    }

    /// <summary>Klasa koja modeluje Strategiju.</summary>
    public class Strategija
    {
        private string sNaziv;
        [XmlElement("Naziv")]
        public string Naziv { get { return sNaziv; } set { sNaziv = value.Trim(); } }
        [XmlArray("Ocene")]
        [XmlArrayItem("Item")]
        public List<ItemStrategija> Ocene { get; set; }

        /// <summary>Indekser za prstup oceni na osnovu broja bodova.</summary>
        /// <param name="nBrojBodova">Broj bodova za koji se trazi ocena.</param>
        /// <returns>Vraca ocenu za zadati broj poena. Ukoliko broj poena ne pripada ni jednom intervalu, vraca ocenu koja oznacava da ispit nije polozen.</returns>
        private int? this[int nBrojBodova] {
            get {
                foreach(ItemStrategija ocena in this.Ocene) {
                    if(ocena.Min <= nBrojBodova && nBrojBodova <= ocena.Max) {
                        return ocena.Name;
                    }
                }
                return Const.N_MIN_OCENA;
            }
        }

        /// <summary>Kostruktor koji postavlja ime Strategije.</summary>
        public Strategija(string sNaziv)
        {
            this.Naziv = sNaziv;
            this.Ocene = new List<ItemStrategija>();
        }

        /// <summary>Default knstruktor koji postavlja ime Strategije na prazan string.</summary>
        /// <remarks>Nije mogao konstruktor sa podrazumevanim parametrom, jer program puca kod deserijalizacije.</remarks>
        public Strategija() : this("") { }

        public override bool Equals(object obj)
        {
            Strategija s = obj as Strategija;
            if(s != null) {
                return this.Naziv == s.Naziv;
            }
            return false;
        }

        public override int GetHashCode() => Naziv.GetHashCode();

        /// <summary>Metoda koja racuna vrednost ocene na osnovu broja bodova.</summary>
        /// <param name="nSumaBodova">Broj bodova za koji se racuna ocena.</param>
        /// <returns>Ocena izracunata na osnovu broja bodova.</returns>
        public int? izracunajOcenu(int nSumaBodova) => this[nSumaBodova];
    }

    /// <summary>Ocena u Strategiji sa intervalom za poene.</summary>
    public class ItemStrategija
    {
        [XmlElement("Name")]
        public int? Name { get; set; }
        [XmlElement("Min")]
        public int Min { get; set; }
        [XmlElement("Max")]
        public int Max { get; set; }

        /// <summary>Default konstruktor koji postavlja ocenu Strategije tako da se dobija sa bilo kojim brojem poena.</summary>
        /// <remarks>Sluzi za NullObject pattern.</remarks>
        public ItemStrategija()
        {
            this.Min = 0;
            this.Max = Const.N_MAX_POENA + 1;
            this.Name = null;
        }
    }
}

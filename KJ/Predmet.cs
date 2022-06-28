using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18203
{
    public class Predmet
    {
        //plan je da iz fajla kada procita studenta procita i predmet, ovde se modeluju predmeti koji se sastoje od usmenog(uvek) i
        //ostalih delova ciji se broj i tezina razlikuju od predmeta do predmeta pa njih modeluje posebna klasa item
        
        private string naziv;
        private Strategija strategija;
        private int usmeni; //koliko max poena nosi
        private int uslov; //posto je neophodno poloziti usmeni, svi predmeti moraju imati uslov za polaganje usmenog
        private List<Item> elementi;

        public Predmet(string naziv, Strategija strategija, int usmeni, int uslov)
        {
            this.naziv = naziv;
            this.strategija = strategija;
            this.usmeni = usmeni;
            this.elementi = new List<Item>();
            this.uslov = uslov;
        }

        public Predmet(string naziv, Strategija strategija, int usmeni, int uslov, List<Item> elementi) : this(naziv, strategija, usmeni, uslov)
        {
            this.elementi = elementi;
        }

        public Predmet() : this("", null, 0, 0)
        {

        }

        public string Naziv
        {
            get { return this.naziv; }
        }
        public int Count
        {
            get { return this.elementi.Count; }
        }

        public Strategija Strategija
        {
            get { return strategija; }
        }

        public override string ToString()
        {
            return naziv;
        }

        public int Granica()
        {
            return (uslov/100) * usmeni;
        }
        public Item PronadjiEl(string ime)
        {
            Item ret = null;
            foreach(Item el in elementi)
            {
                if (el.Naziv == ime)
                {
                    ret = el;
                }
            }
            return ret;
        }

        public void PromeniStrategiju(Strategija nova)
        {
            this.strategija = nova;
        }

        public string Prikazi()
        {
            string ret = "";
            ret += naziv + "\n" + strategija.ToString() + "\n" + "Usmeni nosi: " + usmeni.ToString() + "\n" + "Uslov je: " + uslov.ToString();

            foreach(Item el in elementi)
            {
                ret += "\n" + el.ToString();
            }
            return ret;
        }
    }
}

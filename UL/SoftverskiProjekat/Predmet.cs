using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftverskiProjekat
{
    class Predmet : XmlReadable
    {
        public string Naziv { get; set; }
        Strategija strategija;
        private int usmeniMin;
        private int usmeniMax;
        Element[] elementi;

        public Element[] Elementi
        {
            get
            {
                return elementi;
            }
            set
            {
                elementi = value;
            }
        }

        public Strategija Strategija
        {
            get
            {
                return strategija;
            }
            set
            {
                strategija = value;
            }
        }

        public Predmet(string Naziv)
        {
            this.Naziv = Naziv;
        }
        public Predmet(Strategija strat, int min, int max, Element[] elementi) {
            strategija = strat;
            UsmeniMax = max;
            UsmeniMin = min;
            this.elementi = new Element[elementi.Length];
            for (int i = 0; i < elementi.Length; i++)
                this.elementi[i] = elementi[i];
        }

        public int UsmeniMin {
            get
            {
                return usmeniMin;
            }
            private set
            {
                usmeniMin = value;
            }
        }
        public int UsmeniMax {
            get
            {
                return usmeniMax;
            }
            private set
            {
                usmeniMax = value;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Naziv + "\n");
            sb.Append($"Usmeni min%: {UsmeniMin}\nUsmeniMaxPoena:{UsmeniMax}\nStrategija:{strategija.Naziv}\n");
            foreach(Element el in elementi)
            {
                sb.Append(el.ToString());
            }
            return sb.ToString();
        }
    }
}

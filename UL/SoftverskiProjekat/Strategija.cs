using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftverskiProjekat
{
    class Strategija : XmlReadable
    {
        private string naziv;
        Ocena[] ocene;

        public string Naziv {
            get
            {
                return naziv;
            }
            private set
            {
                naziv = value;
            }
        }

        public Ocena[] Ocene {
            get
            {
                return ocene;
            }
            private set
            {
                ocene = value;
            }
        }

        public Strategija(string naziv, Ocena[] ocene) {
            Naziv = naziv;
            Ocene = ocene;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Naziv + "\n");
            foreach (Ocena o in ocene) {
                sb.Append(o.ToString());
            }
            return sb.ToString();
        }
    }
}

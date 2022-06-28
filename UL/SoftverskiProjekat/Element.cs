using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftverskiProjekat
{
    class Element
    {
        private string naziv;
        private int minPoena = 0;
        private int maxPoena;

        public int MinPoena {
            get
            {
                return minPoena;
            }
            private set
            {
                minPoena = value;
            }
        }

        public int MaxPoena
        {
            get
            {
                return maxPoena;
            }
            private set
            {
                maxPoena = value;
            }
        }

        public string Naziv
        {
            get
            {
                return naziv;
            }
            private set
            {
                naziv = value;
            }
        }
        public Element(string naziv, int minpoen, int maxpoen) {
            this.Naziv = naziv;
            MinPoena = minpoen;
            MaxPoena = maxpoen;
        }
        public override string ToString()
        {
            return $"{Naziv},MinPoena:{MinPoena},MaxPoena:{MaxPoena}\n";
        }
    }
}

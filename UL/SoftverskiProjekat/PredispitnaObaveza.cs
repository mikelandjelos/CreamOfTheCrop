using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftverskiProjekat
{
    class PredispitnaObaveza
    {
        string nazivObaveze;
        int osvojeniBrojPoena;

        public PredispitnaObaveza(string naziv, int poeni)
        {
            Naziv = naziv;
            Poeni = poeni;
        }

        public string Naziv
        {
            get
            {
                return nazivObaveze;
            }
            set
            {
                nazivObaveze = value;
            }
        }

        public int Poeni
        {
            get { return osvojeniBrojPoena; }
            set { osvojeniBrojPoena = value; }
        }
    }
}

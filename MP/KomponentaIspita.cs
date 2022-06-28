using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat18332Ocene
{
    abstract class KomponentaIspita
    {
        private string naziv;
        protected int max;
        public KomponentaIspita(string naziv = "nema naziv", int max = 0)
        {
            this.max = max;
            this.naziv = naziv;
        }
        public abstract bool polozioElement(int poeni);
        public string vratiNaziv()
        {
            return naziv;
        }
        public int vratiMax()
        {
            return max;
        }
    }
}

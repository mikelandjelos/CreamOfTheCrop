using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat18332Ocene
{
    class Element : KomponentaIspita
    {

        private int min;

        public Element(string naziv = "nema naziv", int max = 0,int min=0):base(naziv, max)
        {
            this.min = min;
        }
        public int vratiMin()
        {
            return min;
        }
        public override bool polozioElement(int poeni)
        {
            bool daLi = false;
            if (poeni >= min && poeni <= max)
                daLi = true;
            return daLi;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat18332Ocene
{
    class ElementSaProcentima : KomponentaIspita
    {
        private int procenat;

        public ElementSaProcentima(string naziv = "nema naziv", int max = 0, int procenat = 0) : base(naziv, max)
        {
            this.procenat = procenat;
        }
        public override bool polozioElement(int poeni)
        {
            bool daLi = false;
            if (poeni >= max*procenat/100 && poeni <= max)
                daLi = true;
            return daLi;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat18332Ocene
{
    class Strategija
    {
        private string naziv;
        private List<Ocena> ocene;

        public Strategija(string nazivn,List<Ocena>ocenan)
        {
            this.naziv = nazivn;
            this.ocene = new List<Ocena>();
            this.ocene = ocenan;
        }

        public string vratiNazivStrategije()
        {
            return naziv;
        }

        public List<Ocena> vratiListuOcena()
        {
            return ocene;
        }
        public string oceni(int poeni)
        {
            string s = "nije polozio";
            for(int i=0;i<ocene.Count;i++)
            {
                if (ocene[i].daLiJeTa(poeni))
                    s = ocene[i].Naziv;
            }

            return s;
        }
        
       
    }
}

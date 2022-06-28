using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18203
{
    public class Strategija
    {
        private string naziv;
        private List<Ocena> ocene;

        public Strategija(string naziv)
        {
            this.naziv = naziv;
            this.ocene = new List<Ocena>();
        }

        public Strategija(string naziv, List<Ocena> ocene) 
        {
            this.naziv = naziv;
            this.ocene = ocene;
        }

        public Strategija() : this("")
        {

        }

        public string Naziv
        {
            get { return this.naziv; }
        }
        public override string ToString()
        {
            return naziv;
        }

        public string Prikazi()
        {
            string ret = "";
            ret += naziv + "\r\n";
            foreach (Ocena ocena in ocene)
            {
                ret += ocena.ToString() + "\r\n";
            }
            return ret;
        }

        public int Izracunaj(int ukupno)
        {
            foreach(Ocena ocena in ocene)
            {
                if(ukupno>=ocena.Min && ukupno <= ocena.Max)
                {
                    return ocena.Naziv;
                }
            }

            return 5;
        }
    }
}

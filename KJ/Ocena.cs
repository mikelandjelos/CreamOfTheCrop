using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18203
{
    public class Ocena
    {
        private int naziv;
        private int min;
        private int max;

        public Ocena(int naziv, int min, int max)
        {
            this.naziv = naziv;
            this.min = min;
            this.max = max;
        }

        public Ocena() : this(0, 0, 0)
        {

        }

        public int Min
        {
            get { return this.min; }
        }

        public int Max
        {
            get { return max; }
        }

        public int Naziv
        {
            get { return naziv; }
        }
        public override string ToString()
        {
            return "Ocena: " + naziv.ToString() + "\r\n" + "Od: " + min.ToString() + "\r\n "+ "Do: " + max.ToString() + "\r\n";
        }
    }
}

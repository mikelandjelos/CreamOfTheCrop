using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18203
{
    public class Item 
    {
        //koristi se za modelovanje dodatnih elemenata ispita i pamti naziv obaveze, maksimalan broj poena i uslov za polaganje

        private string naziv;
        private int min;
        private int max;

        public Item(string naziv, int min, int max)
        {
            this.naziv = naziv;
            this.min = min;
            this.max = max;
        }

        public Item(): this("", 0, 0)
        {

        }

        public string Naziv
        {
            get { return this.naziv; }
            set { this.naziv = value; }
        }

        public int Granica()
        {
            return (min/100) * max;
        }
        public override string ToString()
        {
            return naziv + " " + min.ToString() + " " + max.ToString();
        }
    }
}

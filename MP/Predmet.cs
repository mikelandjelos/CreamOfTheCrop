using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat18332Ocene
{
     class Predmet
    {
        private string naziv;
        private string strategija;
        private ElementSaProcentima usmeni;
        private List<KomponentaIspita> elementi;

        public Predmet(string naziv,string strategija, ElementSaProcentima usmeni,List<KomponentaIspita> elementi)
        {
            this.naziv = naziv;
            this.strategija = strategija;
            this.usmeni = usmeni;
            this.elementi = new List<KomponentaIspita>();
            if(elementi!=null)
                this.elementi = elementi;
        }
        public string vratiStrategiju()
        {
            return strategija;
        }
        public string vratiNaziv()
        {
            return naziv;
        }
        public int racunajPoene(Student student)
        {
            int poeni = 0;
            bool polozio = true;
            if (usmeni.polozioElement(student.vratiUsmeni()))
            {
                poeni += student.vratiUsmeni();
            }
            else
                polozio = false;
            List<int> elem = student.vratiPoenePoElementima();
            for(int i=0;i<elementi.Count;i++)
            {
                if (elementi[i].polozioElement(elem[i]))
                {
                    poeni += elem[i];
                }
                else
                    polozio = false;
            }
            if (polozio)
                return poeni;
            return -1;
        }
        public bool postojiElement(string s)
        {
            bool postoji= false;
            int i = 0;
            while(!postoji&&i<elementi.Count)
            {
                if (elementi[i].vratiNaziv() == s)
                    postoji = true;
                i++;
            }

            return postoji;

        }
        public int brojElemenata()
        {
            return elementi.Count;
        }

        public void izmeniStrategiju(string s)
        {
            this.strategija = s;
        }

    }
}

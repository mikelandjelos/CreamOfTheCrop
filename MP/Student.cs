using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat18332Ocene
{
    
    class Student
    {
        private string brIndeksa;
        private string nazivPredmeta;
        private int brojPoenaUsmeni;
        private List<string> naziviElemenata;
        private List<int> brojPoenaPoElementima;
        private string ocena;

        public Student(string bri="0000",string naz="Nema predmeta",int brUsm=0,List<string>nazel=null,List<int>brpoen=null)
        {
            this.brIndeksa = bri;
            this.nazivPredmeta = naz;
            this.brojPoenaUsmeni = brUsm;
            this.naziviElemenata = new List<string>();
            this.naziviElemenata = nazel;
            this.brojPoenaPoElementima = new List<int>();
            this.brojPoenaPoElementima = brpoen;
            this.ocena = "neocenjen";
        }

        public override string ToString()
        {
            return "indeks: "+brIndeksa + " predmet: "+nazivPredmeta + " ocena: " + ocena; 

        }
        public string vratiNazivPredmeta()
        {
            return nazivPredmeta;
        }
       
        public void postaviOcenu(string s)
        {
            this.ocena = s;
        }
        public int vratiUsmeni()
        {
            return brojPoenaUsmeni;
        }
        public List<int> vratiPoenePoElementima()
        {
            return brojPoenaPoElementima;
        }
        public List<string> vratiNaziveElemenata()
        {
            return naziviElemenata;
        }

    }
}

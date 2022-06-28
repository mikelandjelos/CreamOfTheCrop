using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18203
{
    public class Student
    {
        //plan je da iz fajla cita indeks studenta i da poene smesta u listu koja ce u zavisnosti od predmeta imati razl br el
        private int indeks;
        private Predmet predmet;
        private int usmp; //broj osvojenih poena na usmenom
        private int brp;
        private Dictionary<string, int> poeni; //pogleda koliko elemenata u nizu ima predmet, za toliko elemenata cuva broj poena

        public Student(int indeks, Predmet predmet, int usmp, Dictionary<string,int> poeni)
        {
            this.indeks = indeks;
            this.predmet = predmet;
            this.usmp = usmp;
            this.brp = this.predmet.Count;
            this.poeni = poeni;
        }

        public Student() :this(0000, new Predmet(), 0, new Dictionary<string, int>())
        {

        }

        public override string ToString()
        {
            return indeks.ToString();
        }

        public string Prikazi()
        {
            string ret = "";
            ret += indeks.ToString() + "\n" + predmet.ToString() + "\n" + "Osvojeni poeni na usmenom: " + usmp.ToString();
            foreach(Object obj in poeni)
            {
                ret+= "\n" + obj.ToString();
            }
            return ret;
        }

        public Predmet Predmet
        {
            get { return predmet; }
        }

        public int Indeks
        {
            get
            {
                return indeks;
            }
        }
        public int IzracunajOcenu()
        {
            //logika: na osnovu imena iz dictionary se uzima element predmeta sa istim imenom, poredi se broj iz dictionary
            //sa uslov*max, ako < onda 5 ako vise onda se sabiraju svi poeni i salje se strategiji iz predmeta da izracuna ocenu
            int ukupno = usmp;
            if (usmp > predmet.Granica())
            {
                string[] imenael = new string[brp];
                imenael = poeni.Keys.ToArray();
                for (int i = 0; i < this.brp; i++)
                {
                    Item element = null;
                    element = this.predmet.PronadjiEl(imenael[i]);
                    if (element == null)
                    {
                        Console.WriteLine("Nepostojeci element");
                    }
                    else
                    {
                        int br = poeni.ElementAt(i).Value;
                        if (br > element.Granica())
                        {
                            ukupno += br;
                        }
                        else
                        {
                            return 5;
                        }
                    }
                }
                return predmet.Strategija.Izracunaj(ukupno);
            }
            else { return 5; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftverskiProjekat
{
    class Student : XmlReadable
    {
        string indeks;
        Predmet predmet;
        int usmeni, zavrsnaOcena;
        PredispitnaObaveza[] elementi;

        public int ZavrsnaOcena
        {
            get
            {
                return zavrsnaOcena;
            }
            set
            {
                zavrsnaOcena = value;
            }
        }

        public PredispitnaObaveza[] Elementi
        {
            get
            {
                return elementi;
            }
            set
            {
                elementi = value;
            }
        }

        public int Usmeni
        {
            get
            {
                return usmeni;
            }
            set
            {
                usmeni = value;
            }
        }

        public string Indeks
        {
            get
            {
                return indeks;
            }
            set
            {
                indeks = value;
            }
        }

        public Predmet Predmet
        {
            get
            {
                return predmet;
            }
            set
            {
                predmet = value;
            }
        }

        public Student() { }
        public Student(string indeks, Predmet predmet, int usmeni, PredispitnaObaveza[] elementi) {
            this.indeks = indeks;
            this.predmet = predmet;
            this.usmeni = usmeni;
            this.elementi = elementi;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Indeks:{indeks}|Usmeni:{usmeni}\n");
            //stringBuilder.Append($"{indeks}|{usmeni}|{predmet}\n");
            foreach (PredispitnaObaveza el in elementi) {
                stringBuilder.Append($"{el.Naziv}:{el.Poeni}\n");
            }
            return stringBuilder.ToString();
        }
    }
}

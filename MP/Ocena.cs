using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat18332Ocene
{
    class Ocena
    {
        private int min;
        private int max;
        private string naziv;

        public Ocena(int mini=-1,int maxi=-1,string zovese="neodredjeno")
        {
            this.min = mini;
            this.max = maxi;
            Naziv = zovese;
        }
        public string Naziv { get => naziv; set => naziv = value; }

        public bool daLiJeTa(int points)
        {
            bool dali = false;
            if (points >= min && points <= max)
                dali = true;
            return dali;
        }
    }
}

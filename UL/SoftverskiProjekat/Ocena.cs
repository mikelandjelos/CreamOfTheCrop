using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftverskiProjekat
{
    class Ocena : XmlReadable
    {
        private int ocena;
        private int minPoena;
        private int maxPoena;
        private bool isValid;

        public int BrojOcene {
            get {
                return ocena;
            }
            private set {
                if (value < 6 || value > 10)
                {
                    isValid = false;
                    return;
                }
                ocena = value;
                isValid = true;
            }
        }

        public int MinPoena {
            get {
                return minPoena;
            }
            private set
            {
                minPoena = value;
            }
        }

        public int MaxPoena {
            get {
                return maxPoena;
            }
            private set
            {
                maxPoena = value;
            }
        }

        public bool IsValid {
            get
            {
                return isValid;
            }
        }

        public string Naziv {
            get {
                return BrojOcene.ToString();
            }
        }

        public Ocena(int minPoena, int maxPoena, int ocena) {
            MinPoena = minPoena;
            MaxPoena = maxPoena;
            BrojOcene = ocena;
        }
        public override string ToString()
        {
            return $"{BrojOcene}\nMin:{MinPoena}\nMax:{MaxPoena}\n";
        }
    }
}

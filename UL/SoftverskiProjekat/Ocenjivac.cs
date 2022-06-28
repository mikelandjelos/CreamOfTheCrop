using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftverskiProjekat
{
    static class Ocenjivac
    {
        public static void Oceni(Student[] studenti) {
            foreach (Student student in studenti)
            {
                if (student.Predmet == null)
                {
                    Console.WriteLine($"Za studenta {student.Indeks} ne postoji Predmet!");
                    continue;
                }
                if(student.Predmet.Strategija == null)
                {
                    Console.WriteLine($"Za studenta {student.Indeks} i Predmet {student.Predmet} ne postoji Strategija!");
                    continue;
                }
                int brojPoena = 0;
                if (student.Usmeni < student.Predmet.UsmeniMax * (student.Predmet.UsmeniMin / 100))
                {
                    student.ZavrsnaOcena = 5;
                    continue;
                }
                brojPoena += student.Usmeni;
                for (int i = 0; i < student.Elementi.Length; i++)
                {
                    if (student.Elementi[i].Poeni < student.Predmet.Elementi[i].MinPoena)
                    {
                        student.ZavrsnaOcena = 5;
                        break;
                    }
                    brojPoena += student.Elementi[i].Poeni;
                }
                for (int i = student.Predmet.Strategija.Ocene.Length - 1; i >= 0; i--)
                {
                    if (brojPoena >= student.Predmet.Strategija.Ocene[i].MinPoena)
                    {
                        student.ZavrsnaOcena = student.Predmet.Strategija.Ocene[i].BrojOcene;
                        break;
                    }
                }
            }
        }
    }
}

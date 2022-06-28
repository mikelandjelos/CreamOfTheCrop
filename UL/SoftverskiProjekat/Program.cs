using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SoftverskiProjekat
{
    class Program
    {

        static void ShowXMLFiles()
        {
            DirectoryInfo dirInfo = DirectoryInfo.Instance();
            Console.WriteLine("Dostupni XML fajlovi:");
            foreach (string filename in dirInfo.currentFiles)
                Console.WriteLine(filename);
        }

        static void PrintOptions() {
            Console.WriteLine("Unesite slovo ispred opcije koju zelite!");
            Console.WriteLine("a. Prikazi ucitane studente");
            Console.WriteLine("b. Oceni studente");
            Console.WriteLine("c. Zameni strategiju ocenjivanja");
            Console.WriteLine("w. Upisi u ocene.xml");
            Console.WriteLine("q. Korak nazad");
        }

        static void ReadStudents() {
            while (true)
            {
                Console.WriteLine("Za povratak nazad unesite 'q'");
                Console.Write("Unesite ime XML fajla sa studentima (sa ekstenzijom): ");
                string userInput = Console.ReadLine();
                if (userInput == "q") break;
                StudentXmlReader studentReader = new StudentXmlReader();
                Student[] studenti = studentReader.ReadXml(userInput) as Student[];
                if(studenti == null)
                {
                    Console.WriteLine("Nisam uspeo da ucitam zadati fajl, probaj opet!");
                    continue;
                }
                bool goBack = false;
                while (!goBack)
                {
                    PrintOptions();
                    string userOption = Console.ReadLine().ToLower();
                    switch (userOption)
                    {
                        case "a":
                            foreach(Student s in studenti)
                            {
                                Console.WriteLine(s);
                            }
                            break;
                        case "b":
                            Ocenjivac.Oceni(studenti);
                            Console.WriteLine("Ocenjeni studenti: ");
                            Console.WriteLine("Indeks\tOcena");
                            foreach(Student s in studenti)
                            {
                                Console.WriteLine($"|{s.Indeks}|\t|{s.ZavrsnaOcena}|");
                            }
                            break;
                        case "c":
                            while (true)
                            {
                                Console.Write("Unesite naziv strategije (A) || (B) || (D): ");
                                string stratInput = Console.ReadLine().Trim();
                                Strategija strat = new StrategijaXmlReader().ReadXml($"strategija{stratInput}.xml")[0] as Strategija;
                                if (strat == null)
                                {
                                    Console.WriteLine("Ne postoji strategija!");
                                    continue;
                                }
                                foreach(Student student in studenti)
                                {
                                    student.Predmet.Strategija = strat;
                                }
                                break;
                            }
                            break;
                        case "w":
                            try
                            {
                                ResultWriter writer = new ResultWriter("ocene.xml");
                                writer.Write(studenti);
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                return;
                            }
                            break;
                        case "q":
                            goBack = true;
                            break;
                    }
                }
            }
        }
        static void Usage() {
            Console.WriteLine("1.) Prikaz dostupnih XML fajlova");
            Console.WriteLine("2.) Ucitaj XML fajl sa studentima");
            Console.WriteLine("3.) Izadji");
            Console.WriteLine("Unesite broj ispred opcije koju zelite da odaberete!");
            Console.WriteLine("----------------------------------------------------");
        }

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Usage();
                string userInput = Console.ReadLine().Trim();
                switch (userInput)
                {
                    case "1":
                        ShowXMLFiles();
                        break;
                    case "2":
                        ReadStudents();
                        Console.Clear();
                        break;
                    case "3":
                        exit = true;
                        break;

                }
            }
        }
    }
}

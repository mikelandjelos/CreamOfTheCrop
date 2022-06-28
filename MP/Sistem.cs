using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace Projekat18332Ocene
{
    class Sistem
    {
        private Dictionary<string,Strategija> strategije;
        private Dictionary<string,Predmet> predmeti;
        private List<Student> studenti;
        
        public Sistem()
        {
            strategije = new Dictionary<string, Strategija>();
            predmeti = new Dictionary<string, Predmet>();
            studenti = new List<Student>();
            
            popuniStartPredmete();
            popuniStartStrategije();
        }
        private void popuniStartPredmete()
        {
            //ovo je inicijalna konfiguracija i nije radjen checking za tacnost podataka jer se podrazumeva da su tacno uneti programski
            List<KomponentaIspita> e1 = new List<KomponentaIspita>();
            e1.Add(new ElementSaProcentima("Pismeni", 32, 50));
            e1.Add(new Element("Lab", 20, 0));
            Predmet p = new Predmet("OO Projektovanje", "A",new ElementSaProcentima("Usmeni", 48, 50), e1);
            predmeti.Add("OO Projektovanje", p);

            List<KomponentaIspita> e2 = new List<KomponentaIspita>();
            e2.Add(new Element("Projekat a",10,6));
            e2.Add(new Element("Projekat b", 10, 8));
            e2.Add(new Element("Lab", 20, 8));
            e2.Add(new Element("Terenski zadatak", 20, 8));
            p = new Predmet("Geodezija", "A", new ElementSaProcentima("Usmeni", 40, 50), e2);
            predmeti.Add("Geodezija", p);

            List<KomponentaIspita> e3 = new List<KomponentaIspita>();
            e3.Add(new Element("Istraživanje", 20, 7));
            p = new Predmet("Istorija starog veka", "A", new ElementSaProcentima("Usmeni", 80, 60), e3);
            predmeti.Add("Istorija starog veka", p);

            List<KomponentaIspita> e4 = new List<KomponentaIspita>();
            e4.Add(new ElementSaProcentima("Test A", 25,60));
            e4.Add(new ElementSaProcentima("Test B", 25, 60));
            e4.Add(new Element("Lab 1", 10, 0));
            e4.Add(new Element("Lab 2", 10, 2));
            e4.Add(new Element("Lab 3", 10, 5));
            p = new Predmet("Farmakologija", "B", new ElementSaProcentima("Usmeni", 20, 80), e4);
            predmeti.Add("Farmakologija", p);

            List<KomponentaIspita> e5 = new List<KomponentaIspita>();
            e5.Add(new Element("SW projekat", 30, 0));
            e5.Add(new Element("MM projekat", 30, 15));
             p = new Predmet("MMS", "B", new ElementSaProcentima("Usmeni", 40, 50), e5);
            predmeti.Add("MMS", p);

            p = new Predmet("Rimsko pravo", "B", new ElementSaProcentima("Usmeni", 100, 55), null);
            predmeti.Add("Rimsko pravo", p);


        }
        private void popuniStartStrategije()
        {
            //ovo je inicijalna konfiguracija i nije radjen checking za tacnost podataka jer se podrazumeva da su tacno uneti programski
            List<Ocena> l1 = new List<Ocena>();
            l1.Add(new Ocena(55, 64, "6"));
            l1.Add(new Ocena(65, 74, "7"));
            l1.Add(new Ocena(75, 84, "8"));
            l1.Add(new Ocena(85, 94, "9"));
            l1.Add(new Ocena(95, 100, "10"));
            Strategija a = new Strategija("A", l1);
            strategije.Add("A", a);


            List<Ocena> l2 = new List<Ocena>();
            l2.Add(new Ocena(50, 64, "6"));
            l2.Add(new Ocena(65, 89, "7"));
            l2.Add(new Ocena(90, 97, "9"));
            l2.Add(new Ocena(98, 100, "10"));
            Strategija b = new Strategija("B", l2);

            strategije.Add("B", b);


        }
        
        private bool validan(Student s)
        {
            bool jeste = true;
                Predmet p; predmeti.TryGetValue(s.vratiNazivPredmeta(), out p);
                foreach(string ime in s.vratiNaziveElemenata())
                {
                    if (!p.postojiElement(ime))
                        jeste = false;

                }
            return jeste;
        }
        public void ucitajOcene(string fajl)
        {
            
            string brIndexa = "";
            string nazivPredmeta = "";
            int brPoenaUsmeni = 0;
         
            string[] naziviElemenata=new string[0];
            int[] brojPoenaPoElementima=new int[0];
            bool validanJe=false;
            bool losipodaci = false;
            Predmet p = null;
            int brElem=0;

            try
            {
                XmlTextReader xtr = new XmlTextReader(fajl);
                xtr.WhitespaceHandling = WhitespaceHandling.None;
                
                while(xtr.Read())
                {
                    if(xtr.NodeType==XmlNodeType.Element)
                    {
                        
                        if(xtr.Name== "Indeks")
                            brIndexa = xtr.ReadElementContentAsString();
                        if (xtr.Name == "Predmet")
                        {
                            nazivPredmeta = xtr.ReadElementContentAsString();
                            if (predmeti.ContainsKey(nazivPredmeta))
                            {
                                validanJe = true;
                                brElem = 0;
                                predmeti.TryGetValue(nazivPredmeta, out p);
                                brojPoenaPoElementima = new int[p.brojElemenata()];
                                naziviElemenata = new string[p.brojElemenata()];
                            }
                        }
                        if (xtr.Name == "Usmeni")
                            brPoenaUsmeni = xtr.ReadElementContentAsInt();
                        if (xtr.Name == "Name")
                            naziviElemenata[brElem] = xtr.ReadElementContentAsString();
                        if (xtr.Name == "Value")
                            brojPoenaPoElementima[brElem++] = xtr.ReadElementContentAsInt();

                    }
                    if(validanJe&&brElem==p.brojElemenata())
                    {
                        
                        Student s = new Student(brIndexa, nazivPredmeta, brPoenaUsmeni, naziviElemenata.ToList(), brojPoenaPoElementima.ToList());
                        if (validan(s))
                        {
                            studenti.Add(s);

                        }
                        else
                            losipodaci = true;
                        validanJe = false;
                        brElem = 0;
                        p = null;
                    }

                }
                if (losipodaci)
                    losiPodaci();
                xtr.Close();

            }
            catch
            {
                MessageBox.Show("Neuspelo citanje iz fajla!");
            }
            

        }
        private void losiPodaci()
        {
            MessageBox.Show("Fajl sadrzi neispravne podatke za citanje. Ako postoje, ucitani su samo ispravni.");
        }
        private bool dobriElementi(List<Element>elementi,int umax,int uminpct)
        {
            bool dobri = true;
            int suma = 0;
            if(umax<0||umax>100||uminpct<0||uminpct>100)
            {
                dobri = false;
            }
            else
            {
                suma = umax;
                for (int i = 0; i < elementi.Count; i++)
                {
                    suma += elementi[i].vratiMax();
                    if (elementi[i].vratiMin() > elementi[i].vratiMax() || elementi[i].vratiMin() < 0 || elementi[i].vratiMax() < 0 || elementi[i].vratiMax() > 100)
                        dobri = false;
                }
            }

            if (suma > 100)
                dobri = false;
            return dobri;
        }
        public void ucitajPredmet(string fajl)
        {
            List<Element> elementi=new List<Element>();
            List<KomponentaIspita> elementi2 = new List<KomponentaIspita>();
            string naziv="";
            string strategija = "";
            int min = -1;
            int max = -1;
            int minpct = -1;
            int usmenimax = -1;
            string nazivElementa = "";
            
            try
            {
                XmlTextReader xtr = new XmlTextReader(fajl);
                xtr.WhitespaceHandling = WhitespaceHandling.None;

                xtr.Read();
                if(xtr.NodeType==XmlNodeType.Element&&xtr.Name!="Predmet")
                {
                    losiPodaci();
                    return;
                }

                while (xtr.Read())
                {
                    if(xtr.NodeType == XmlNodeType.Element)
                    {
                        if(xtr.Name=="Strategija")
                            strategija = xtr.ReadElementContentAsString();
                        if (xtr.Name == "Naziv")
                            naziv = xtr.ReadElementContentAsString();
                        if (xtr.Name == "UsmeniMinPct")
                            minpct = xtr.ReadElementContentAsInt();
                        if (xtr.Name == "UsmeniMaxPoena")
                            usmenimax = xtr.ReadElementContentAsInt();
                        if (xtr.Name == "Name")
                            nazivElementa = xtr.ReadElementContentAsString();
                        if (xtr.Name == "Min")
                            min = xtr.ReadElementContentAsInt();
                        if (xtr.Name == "Max")
                            max = xtr.ReadElementContentAsInt();
                        
                        if(max!=-1)//uvek mora da ima max ako postoji element
                        {
                            if (min == -1)
                                min = 0;
                            elementi.Add(new Element(nazivElementa, max, min));
                            elementi2.Add(new Element(nazivElementa, max, min));
                            max = -1;
                            min = -1;
                            nazivElementa = "";
                        }
                    }
                }
                if (dobriElementi(elementi,usmenimax,minpct))
                {
                    if(strategije.ContainsKey(strategija))
                    {

                        if (!predmeti.ContainsKey(naziv))
                            predmeti.Add(naziv, new Predmet(naziv, strategija, new ElementSaProcentima("Usmeni", usmenimax, minpct), elementi2));
                        else
                            MessageBox.Show("Predmet sa ovim nazivom vec postoji!");
                    }
                    else
                    {
                        MessageBox.Show("Zadata strategija za ocenjivanje predmeta ne postoji. Predmet dodat sa strategijom A.");
                        if (!predmeti.ContainsKey(naziv))
                            predmeti.Add(naziv, new Predmet(naziv, "A", new ElementSaProcentima("Usmeni", usmenimax, minpct), elementi2));
                        else
                            MessageBox.Show("Predmet sa ovim nazivom vec postoji!");
                    }
                }
                else
                    MessageBox.Show("Nisu validni elementi predmeta. Proverite ukupnu sumu poena. Mora biti 100.");
            }
            catch
            {
                MessageBox.Show("Neuspelo citanje iz fajla!");
            }
        }
        public string ucitajStrategiju(string fajl)
        {
            string naziv = "";
            List<Ocena> ocene = new List<Ocena>();
            int min = -1;
            int max = -1;
            string nazivOcene = "";

            try
            {
                XmlTextReader xtr = new XmlTextReader(fajl);
                xtr.WhitespaceHandling = WhitespaceHandling.None;

                xtr.Read();
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name != "Strategija")
                {
                    losiPodaci();
                    return "";
                }

                while (xtr.Read())
                {
                    if (xtr.NodeType == XmlNodeType.Element)
                    {
                        
                        if (xtr.Name == "Naziv")
                            naziv = xtr.ReadElementContentAsString();                      
                        if (xtr.Name == "Name")
                            nazivOcene = xtr.ReadElementContentAsString();
                        if (xtr.Name == "Min")
                            min = xtr.ReadElementContentAsInt();
                        if (xtr.Name == "Max")
                            max = xtr.ReadElementContentAsInt();

                        if (max != -1)//uvek mora da ima max ako postoji element
                        {
                            if (min > 0 && min < max && max <= 100)
                                ocene.Add(new Ocena(min, max, nazivOcene));
                        }
                    }
                }
                if(!strategije.ContainsKey(naziv))
                {
                    strategije.Add(naziv, new Strategija(naziv, ocene));
                }
                else
                {
                    MessageBox.Show("Strategija sa ovim nazivom vec postoji!");
                }
                
            }
            catch
            {
                MessageBox.Show("Neuspelo citanje iz fajla!");
            }
            return naziv;
        }
        public List<Student> vratiStudente()
        {
            return this.studenti;
        }
        public List<string> vratiPredmete()
        {          
            return predmeti.Keys.ToList();      
        }
        public List<string> vratiStrategije()
        {
            return strategije.Keys.ToList();
        }
        public void racunajOcene()
        {
            for(int i=0;i<studenti.Count;i++)
            {
                Predmet p;
                predmeti.TryGetValue(studenti[i].vratiNazivPredmeta(), out p);
                if(p!=null)
                {
                    Strategija s;
                    strategije.TryGetValue(p.vratiStrategiju(), out s);
                    int poeni = p.racunajPoene(studenti[i]);
                    if(s!=null)
                        studenti[i].postaviOcenu(s.oceni(poeni));
                }
                
            }
        }
        public void upisiUFajl(string fajl)
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(new FileStream(fajl,FileMode.Create)))
                {
                    for(int i=0;i<studenti.Count;i++)
                    {
                        sw.WriteLine(studenti[i].ToString());
                    }
                }
            }
            catch
            {
                MessageBox.Show("Neuspeli upis u fajl. Pokusajte ponovo.");
            }
                
        }
        public void izmeniStrategijePredmetima(string naziv)
        {
            foreach(KeyValuePair<string,Predmet> p in predmeti)
            {
                p.Value.izmeniStrategiju(naziv);
            }
        }

    }
}

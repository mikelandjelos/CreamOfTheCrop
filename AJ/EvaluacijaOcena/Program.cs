using System;
using System.IO;
using System.Collections.Generic;

namespace EvaluacijaOcena
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ucitavanje podrazumevanih Strategija: A i B
            ListaStrategija lstStr = XMLDeserialize<ListaStrategija>.readFromXML(Properties.Resources.Strategije);
            // Ucitavanje podrazumevanih predmeta: OO Projektovanje, Rimsko pravo, MMS, Farmakologija, Istorija starog veka i Geodezija.
            ListaPredmeta lstPred = XMLDeserialize<ListaPredmeta>.readFromXML(Properties.Resources.Predmeti);
            // Ucitavanje liste studenata iz fajla.
            ListaStudenata lStud = XMLDeserialize<ListaStudenata>.readFromXML(Const.S_FILEPATH_STUDENTI);
            // Racunanje ocena studentima.
            lStud.izracunajOcene(lstPred, lstStr);
            // Cuvanje studenata sa izracunatim ocenama u fajl.
            XMLDeserialize<ListaStudenata>.save2XML(lStud, Const.S_FILENAME_REZULTAT + ".xml");

            // Dodavanje novih predmeta iz fajla.
            lstPred += XMLDeserialize<ListaPredmeta>.readFromXML(Const.S_FILEPATH_PREDMETI);

            // Ucitavanje novih Strategija iz fajla.
            ListaStrategija strFromFile = XMLDeserialize<ListaStrategija>.readFromXML(Const.S_FILEPATH_STRATEGIJE);
            // Za svaku ucitanu Strategiju iz fajla:
            for(int i = 0; i < strFromFile.Strategije.Count; i++) {
                // Postavlja se svim predmetima ta Strategija.
                lstPred.promeniStrategijuSvima(strFromFile.Strategije[i].Naziv);
                // Racunaju se ocene sa tom Strategijom.
                lStud.izracunajOcene(lstPred, strFromFile);
                // Svaki rezultat se cuva u razliciti fajl.
                XMLDeserialize<ListaStudenata>.save2XML(lStud, String.Format("{0}{1}.xml", Const.S_FILENAME_REZULTAT, (i + 1).ToString()));
            }

            //Console.ReadKey();
        }
    }
}

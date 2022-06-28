using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacijaOcena
{
    /// <summary>Klasa koja cuva konstante koje se koriste u programu.</summary>
    static class Const
    {
        /// <summary>Tag koji se dodaje da bude root tag u XML fajlu koji treba parsovati.</summary>
        public const string S_ROOT_NAME = "Root";
        /// <summary>Tag koji se dodaje da grupise niz tagova.</summary>
        public const string S_LIST_NAME = "List";
        
        /// <summary>Maksimalni broj poena koji se moze osvojiti na ispitu.</summary>
        public const int N_MAX_POENA = 100;
        /// <summary>Ocena koja se dobija ukoliko ispit nije polozen.</summary>
        public const int N_MIN_OCENA = 5;
        
        /// <summary>Putanja do XML fajla gde se nalaze strategije.</summary>
        public const string S_FILEPATH_STRATEGIJE = "StrategijaEvaluacioniPrimer.xml";
        /// <summary>Putanja do XML fajla gde se nalaze predmeti.</summary>
        public const string S_FILEPATH_PREDMETI = "PredmetEvaluacioniPrimer.xml";
        /// <summary>Putanja do XML fajla gde se nalaze studenti cija se ocena racuna.</summary>
        public const string S_FILEPATH_STUDENTI = "OceneEvaluacioniPrimer.xml";
        /// <summary>Ime rezultujuceg fajla na koje se dodaje redni broj iz liste strategija.</summary>
        /// <example>RezultatPrimer1.xml</example>
        public const string S_FILENAME_REZULTAT = "RezultatPrimer";

        /// <summary>Ime taga u okviru koga se nalaze podaci za Strategiju.</summary>
        public const string S_TAGNAME_STRATEGIJA = "Strategija";
        /// <summary>Ime taga u okviru koga se nalaze podaci za Predmet.</summary>
        public const string S_TAGNAME_PREDMET = "Predmet";
        /// <summary>Ime taga u okviru koga se nalaze podaci za Studenta.</summary>
        public const string S_TAGNAME_STUDENT = "Student";

        #region Sadrzaj resources XML fajlova
        /*
        public const string Strategije = 
          @"<Root>
            <List>
            <Strategija>
              <Naziv>A</Naziv>
              <Ocene>
                <Item>
                  <Name>6</Name>
                  <Min>55</Min>
                  <Max>64</Max>
                </Item>
                <Item>
                  <Name>7</Name>
                  <Min>65</Min>
                  <Max>74</Max>
                </Item>
                <Item>
                  <Name>8</Name>
                  <Min>75</Min>
                  <Max>84</Max>
                </Item>
                <Item>
                  <Name>9</Name>
                  <Min>85</Min>
                  <Max>94</Max>
                </Item>
                <Item>
                  <Name>10</Name>
                  <Min>95</Min>
                  <Max>100</Max>
                </Item>    
              </Ocene>
            </Strategija>
            <Strategija>
              <Naziv>B</Naziv>
              <Ocene>
                <Item>
                  <Name>6</Name>
                  <Min>50</Min>
                  <Max>64</Max>
                </Item>
                <Item>
                  <Name>7</Name>
                  <Min>65</Min>
                  <Max>89</Max>
                </Item>
                <Item>
                  <Name>8</Name>
                  <Min>90</Min>
                  <Max>97</Max>
                </Item>
                <Item>
                  <Name>9</Name>
                  <Min>90</Min>
                  <Max>97</Max>
                </Item>
                <Item>
                  <Name>10</Name>
                  <Min>98</Min>
                  <Max>100</Max>
                </Item>    
              </Ocene>
            </Strategija>
            </List>
            </Root>";
        public const string Predmeti =
          @"<Root>
            <List>
            <Predmet>
              <Strategija>A</Strategija>
              <Naziv>OO Projektovanje</Naziv>
              <UsmeniMinPct>50</UsmeniMinPct>
              <UsmeniMaxPoena>48</UsmeniMaxPoena>
              <Elementi>
                <Item>
                  <Name>Pismeni</Name>
                  <Min>16</Min>
                  <Max>32</Max>
                </Item>
                <Item>
                  <Name>Lab</Name>
                  <Max>20</Max>
                </Item>
              </Elementi>
            </Predmet>
            <Predmet>
              <Strategija>A</Strategija>
              <Naziv>Rimsko pravo</Naziv>
              <UsmeniMinPct>55</UsmeniMinPct>
              <UsmeniMaxPoena>100</UsmeniMaxPoena>
              <Elementi>
              </Elementi>
            </Predmet>
            <Predmet>
              <Strategija>B</Strategija>
              <Naziv>MMS</Naziv>
              <UsmeniMinPct>50</UsmeniMinPct>
              <UsmeniMaxPoena>40</UsmeniMaxPoena>
              <Elementi>
                <Item>
                  <Name>SW projekat</Name>
                  <Max>30</Max>
                </Item>
                <Item>
                  <Name>MM projekat</Name>
                  <Min>15</Min>
                  <Max>30</Max>
                </Item>
              </Elementi>
            </Predmet>
            <Predmet>
              <Strategija>B</Strategija>
              <Naziv>Farmakologija</Naziv>
              <UsmeniMinPct>80</UsmeniMinPct>
              <UsmeniMaxPoena>20</UsmeniMaxPoena>
              <Elementi>
                <Item>
                  <Name>Test A</Name>
                  <Min>15</Min>
                  <Max>25</Max>
                </Item>
                <Item>
                  <Name>Test B</Name>
                  <Min>15</Min>
                  <Max>25</Max>
                </Item>
                <Item>
                  <Name>Lab 1</Name>
                  <Max>10</Max>
                </Item>
                <Item>
                  <Name>Lab 2</Name>
                  <Min>2</Min>
                  <Max>10</Max>
                </Item>
                <Item>
                  <Name>Lab 3</Name>
                  <Min>5</Min>
                  <Max>10</Max>
                </Item>
              </Elementi>
            </Predmet>
            <Predmet>
              <Strategija>A</Strategija>
              <Naziv>Istorija starog veka</Naziv>
              <UsmeniMinPct>60</UsmeniMinPct>
              <UsmeniMaxPoena>80</UsmeniMaxPoena>
              <Elementi>
                <Item>
                  <Name>Istraživanje</Name>
                  <Min>7</Min>
                  <Max>20</Max>
                </Item>
              </Elementi>
            </Predmet>
            <Predmet>
              <Strategija>A</Strategija>
              <Naziv>Geodezija</Naziv>
              <UsmeniMinPct>50</UsmeniMinPct>
              <UsmeniMaxPoena>40</UsmeniMaxPoena>
              <Elementi>
                <Item>
                  <Name>Projekat a</Name>
                  <Min>6</Min>
                  <Max>10</Max>
                </Item>
                <Item>
                  <Name>Projekat b</Name>
                  <Min>8</Min>
                  <Max>10</Max>
                </Item>
                <Item>
                  <Name>Lab</Name>
                  <Min>8</Min>
                  <Max>20</Max>
                </Item>
                <Item>
                  <Name>Terenski zadatak</Name>
                  <Min>8</Min>
                  <Max>20</Max>
                </Item>
              </Elementi>
            </Predmet>
            </List>
            </Root>";
        */
        #endregion
    }
}

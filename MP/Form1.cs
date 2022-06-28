using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat18332Ocene
{
    public partial class RaspodelaOcena : Form
    {
        Sistem sistem;
        public RaspodelaOcena()
        {
            InitializeComponent();
            sistem = new Sistem();
            PrikaziListu();
        }

        

        private void PrikaziListu()
        {
            lbStudenti.Items.Clear();
            lbPredmeti.Items.Clear();
            lbStrategije.Items.Clear();
            if (sistem.vratiStudente().Count != 0)
            {
                lbStudenti.Items.AddRange(sistem.vratiStudente().ToArray());
            }
            if (sistem.vratiPredmete().Count != 0)
            {
                lbPredmeti.Items.AddRange(sistem.vratiPredmete().ToArray());
            }
            if (sistem.vratiStrategije().Count != 0)
            {
                lbStrategije.Items.AddRange(sistem.vratiStrategije().ToArray());
            }
        }
        private void btnUcitajStudente_Click(object sender, EventArgs e)
        {
            
            if(ofdUcitajStudente.ShowDialog()==DialogResult.OK)
            {
                sistem.ucitajOcene(ofdUcitajStudente.FileName);
                PrikaziListu();
            }
            else
            {
                MessageBox.Show("Morate odabrati xml fajl iz koga se ucitavaju studenti");
            }

        }

        private void btnOdrediUpisi_Click(object sender, EventArgs e)
        {
            sistem.racunajOcene();
            PrikaziListu();
            if(sfdSacuvajOcene.ShowDialog()==DialogResult.OK)
            {
                sistem.upisiUFajl(sfdSacuvajOcene.FileName);
            }
            else
            {
                sistem.upisiUFajl("izlaz.txt");
                MessageBox.Show("Nije odabran faj, pa ce biti kreiran pod imenom izlaz.txt");

            }

        }

        private void btnNoviPredmet_Click(object sender, EventArgs e)
        {
            if (ofdDodajPredmet.ShowDialog() == DialogResult.OK)
            {
                sistem.ucitajPredmet(ofdDodajPredmet.FileName);
                PrikaziListu();
            }
            else
            {
                MessageBox.Show("Morate odabrati xml fajl iz koga se ucitava novi predmet");
            }
        }

        private void btnDodajStrategiju_Click(object sender, EventArgs e)
        {
            if (ofdDodajStrategiju.ShowDialog() == DialogResult.OK)
            {
                string naziv=sistem.ucitajStrategiju(ofdDodajStrategiju.FileName);
                sistem.izmeniStrategijePredmetima(naziv);
                sistem.racunajOcene();
                PrikaziListu();
            }
            else
            {
                MessageBox.Show("Morate odabrati xml fajl iz koga se ucitava strategija");
            }

        }
    }
}

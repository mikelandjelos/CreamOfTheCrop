using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace _18203
{
    public partial class Form1 : Form
    {
        private List<Strategija> strategije;
        private List<Predmet> predmeti;
        private List<Student> studenti;

        IXMLLoad loader;
        public Form1()
        {
            InitializeComponent();
            strategije = new List<Strategija>();
            predmeti = new List<Predmet>();
            studenti = new List<Student>();
        }

        private XmlDocument LoadDoc(string imef)
        {
            XmlDocument dokument = new XmlDocument();
            dokument.Load(imef);
            return dokument;
        }
        private void LoadStrategije(string imef)
        {
            lbxStrat.Items.Clear();
            strategije.Clear();
            loader = new StrategijeXMLLoad();
            loader.LoadData(this.LoadDoc(imef), this);
        }
        private void LoadPredmeti(string imef)
        {
            lbxPredmet.Items.Clear();
            loader = new PredmetiXMLLoad();
            loader.LoadData(this.LoadDoc(imef), this);
        } 

        private void LoadStudenti(string imef)
        {
            lbxStudent.Items.Clear();
            loader = new StudentiXMLLoad();
            loader.LoadData(this.LoadDoc(imef), this);
        }
        public void AddStrat(Strategija st)
        {

            strategije.Add(st);
            int p = 0;
            foreach (Strategija strat in strategije)
            {
                if(strat.Naziv == st.Naziv)
                {
                    p++;
                }
            }
            if (p > 1)
            {
                MessageBox.Show("Strategija vec postoji");
                strategije.Remove(st);
            }

            else
            {
                lbxStrat.Items.Add(st);
            }
        }

        public void AddPred(Predmet pr)
        {
            predmeti.Add(pr);
            lbxPredmet.Items.Add(pr);
        }

        public void AddStud(Student st)
        {
            studenti.Add(st);
            lbxStudent.Items.Add(st);
        }

        public ListBox LbxStrat
        {
            get { return this.lbxStrat; }
        }

        public ListBox LbxPredmet
        {
            get { return this.lbxPredmet; }
        }

        public ListBox LbxStudent
        {
            get { return this.lbxStudent; }
        }

        public void EnableBtnPred()
        {
            btnPredmet.Enabled = true;
        }

        public void EnableBtnStudent()
        {
            btnStudent.Enabled = true;
        }

        private void btnStrat_Click(object sender, EventArgs e)
        {
            if( ofdUcitaj.ShowDialog() == DialogResult.OK)
            {
                LoadStrategije(ofdUcitaj.FileName);
            }
        }

        private void btnPredmet_Click(object sender, EventArgs e)
        {
            if (ofdUcitaj.ShowDialog() == DialogResult.OK)
            {
                LoadPredmeti(ofdUcitaj.FileName);
            }
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            if (ofdUcitaj.ShowDialog() == DialogResult.OK)
            {
                LoadStudenti(ofdUcitaj.FileName);
            }
        }

        private void btnIzmenjenaStrat_Click(object sender, EventArgs e)
        {
            //daje mogucnost da se predmetu zameni trenutna strategija drugom postojecom strategijom
            //za dodavanje nove strategije i reevaluaciju ocena pogledati btnNovaStr_Click
            string imenovestr = txtNovaStrat.Text;
            Strategija nova = null;
            foreach(Strategija item in lbxStrat.Items)
            {
                if (item.Naziv == imenovestr)
                {
                    nova = item;
                }
            }
            if (nova == null)
            {
                MessageBox.Show("Izaberite postojecu strategiju ili dodajte strategiju: " + txtNovaStrat.Text);
            }
            else
            {
                Predmet predmet = null;
                predmet = (Predmet)lbxPredmet.SelectedItem;
                if (predmet == null)
                {
                    MessageBox.Show("Obavezno je izabrati predmet");
                }
                else
                {
                    predmet.PromeniStrategiju(nova);
                    MessageBox.Show(predmet.Prikazi());
                }
            }
        }

        private void txtNovaStrat_TextChanged(object sender, EventArgs e)
        {
            if (txtNovaStrat.TextLength>0)
            {
                btnIzmenjenaStrat.Enabled = true;
            }
            else
            {
                btnIzmenjenaStrat.Enabled = false;
            }
        }

        private void lbxStrat_DoubleClick(object sender, EventArgs e)
        {
            Strategija strat = (Strategija)lbxStrat.SelectedItem;
            MessageBox.Show(strat.Prikazi());
        }

        private void lbxPredmet_DoubleClick(object sender, EventArgs e)
        {
            Predmet pred = (Predmet)lbxPredmet.SelectedItem;
            MessageBox.Show(pred.Prikazi());
        }

        private void lbxStudent_DoubleClick(object sender, EventArgs e)
        {
            Student stud = (Student)lbxStudent.SelectedItem;
            MessageBox.Show(stud.Prikazi());
        }

        private void btnOcena_Click(object sender, EventArgs e)
        {
            Student student = (Student)lbxStudent.SelectedItem;
            MessageBox.Show("Ocena je: " + student.IzracunajOcenu().ToString());
            btnOcena.Enabled = false;
        }

        private void btnNovaStr_Click(object sender, EventArgs e)
        {
            //cita se dodati fajl sa strategijom i svi studenti dobijaju nove ocene na osnovu nove strategije
            if(ofdUcitaj.ShowDialog() == DialogResult.OK)
            {
                loader = new StrategijeXMLLoad();
                loader.LoadData(this.LoadDoc(ofdUcitaj.FileName), this);

                List<int> stareocene = new List<int>();
                List<int> noveocene = new List<int>();

                foreach (Student student in lbxStudent.Items)
                {
                    stareocene.Add(student.IzracunajOcenu());
                    student.Predmet.PromeniStrategiju(strategije.Last());
                    noveocene.Add(student.IzracunajOcenu());
                }

                //formatiranje prikaza
                if (stareocene.Count != 0)
                {
                    string prikaz = "";
                    for (int i = 0; i < stareocene.Count; i++)
                    {
                        prikaz += studenti[i].Indeks.ToString() + " Stara ocena: " + stareocene[i].ToString() + " Nova ocena: " + noveocene[i].ToString() + "\n";
                    }
                    MessageBox.Show(prikaz);
                }
            }
        }

        private void lbxStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOcena.Enabled = true;
        }
    }
}

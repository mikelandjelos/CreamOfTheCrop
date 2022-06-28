
namespace Projekat18332Ocene
{
    partial class RaspodelaOcena
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUcitajStudente = new System.Windows.Forms.Button();
            this.btnOdrediUpisi = new System.Windows.Forms.Button();
            this.btnNoviPredmet = new System.Windows.Forms.Button();
            this.btnDodajStrategiju = new System.Windows.Forms.Button();
            this.lbStudenti = new System.Windows.Forms.ListBox();
            this.ofdUcitajStudente = new System.Windows.Forms.OpenFileDialog();
            this.ofdDodajPredmet = new System.Windows.Forms.OpenFileDialog();
            this.ofdDodajStrategiju = new System.Windows.Forms.OpenFileDialog();
            this.sfdSacuvajOcene = new System.Windows.Forms.SaveFileDialog();
            this.lbPredmeti = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbStrategije = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUcitajStudente
            // 
            this.btnUcitajStudente.Location = new System.Drawing.Point(12, 37);
            this.btnUcitajStudente.Name = "btnUcitajStudente";
            this.btnUcitajStudente.Size = new System.Drawing.Size(138, 55);
            this.btnUcitajStudente.TabIndex = 0;
            this.btnUcitajStudente.Text = "Ucitaj studente i poene";
            this.btnUcitajStudente.UseVisualStyleBackColor = true;
            this.btnUcitajStudente.Click += new System.EventHandler(this.btnUcitajStudente_Click);
            // 
            // btnOdrediUpisi
            // 
            this.btnOdrediUpisi.Location = new System.Drawing.Point(156, 37);
            this.btnOdrediUpisi.Name = "btnOdrediUpisi";
            this.btnOdrediUpisi.Size = new System.Drawing.Size(138, 55);
            this.btnOdrediUpisi.TabIndex = 1;
            this.btnOdrediUpisi.Text = "Odredi ocene i upisi u fajl";
            this.btnOdrediUpisi.UseVisualStyleBackColor = true;
            this.btnOdrediUpisi.Click += new System.EventHandler(this.btnOdrediUpisi_Click);
            // 
            // btnNoviPredmet
            // 
            this.btnNoviPredmet.Location = new System.Drawing.Point(300, 37);
            this.btnNoviPredmet.Name = "btnNoviPredmet";
            this.btnNoviPredmet.Size = new System.Drawing.Size(138, 55);
            this.btnNoviPredmet.TabIndex = 2;
            this.btnNoviPredmet.Text = "Dodaj predmet";
            this.btnNoviPredmet.UseVisualStyleBackColor = true;
            this.btnNoviPredmet.Click += new System.EventHandler(this.btnNoviPredmet_Click);
            // 
            // btnDodajStrategiju
            // 
            this.btnDodajStrategiju.Location = new System.Drawing.Point(444, 37);
            this.btnDodajStrategiju.Name = "btnDodajStrategiju";
            this.btnDodajStrategiju.Size = new System.Drawing.Size(138, 55);
            this.btnDodajStrategiju.TabIndex = 3;
            this.btnDodajStrategiju.Text = "Dodaj strategiju";
            this.btnDodajStrategiju.UseVisualStyleBackColor = true;
            this.btnDodajStrategiju.Click += new System.EventHandler(this.btnDodajStrategiju_Click);
            // 
            // lbStudenti
            // 
            this.lbStudenti.FormattingEnabled = true;
            this.lbStudenti.ItemHeight = 16;
            this.lbStudenti.Location = new System.Drawing.Point(12, 132);
            this.lbStudenti.Name = "lbStudenti";
            this.lbStudenti.Size = new System.Drawing.Size(570, 148);
            this.lbStudenti.TabIndex = 4;
            // 
            // ofdUcitajStudente
            // 
            this.ofdUcitajStudente.FileName = "openFileDialog1";
            this.ofdUcitajStudente.Filter = "XML|*.xml";
            // 
            // ofdDodajPredmet
            // 
            this.ofdDodajPredmet.FileName = "openFileDialog1";
            this.ofdDodajPredmet.Filter = "XML|*.xml";
            // 
            // ofdDodajStrategiju
            // 
            this.ofdDodajStrategiju.FileName = "openFileDialog2";
            this.ofdDodajStrategiju.Filter = "XML|*.xml";
            // 
            // sfdSacuvajOcene
            // 
            this.sfdSacuvajOcene.Filter = "Tekstualni fajl|*.txt";
            // 
            // lbPredmeti
            // 
            this.lbPredmeti.FormattingEnabled = true;
            this.lbPredmeti.ItemHeight = 16;
            this.lbPredmeti.Location = new System.Drawing.Point(15, 319);
            this.lbPredmeti.Name = "lbPredmeti";
            this.lbPredmeti.Size = new System.Drawing.Size(260, 244);
            this.lbPredmeti.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Studenti i ocene:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Predmeti:";
            // 
            // lbStrategije
            // 
            this.lbStrategije.FormattingEnabled = true;
            this.lbStrategije.ItemHeight = 16;
            this.lbStrategije.Location = new System.Drawing.Point(322, 319);
            this.lbStrategije.Name = "lbStrategije";
            this.lbStrategije.Size = new System.Drawing.Size(260, 244);
            this.lbStrategije.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Strategije:";
            // 
            // RaspodelaOcena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 644);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbStrategije);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbPredmeti);
            this.Controls.Add(this.lbStudenti);
            this.Controls.Add(this.btnDodajStrategiju);
            this.Controls.Add(this.btnNoviPredmet);
            this.Controls.Add(this.btnOdrediUpisi);
            this.Controls.Add(this.btnUcitajStudente);
            this.Name = "RaspodelaOcena";
            this.Text = "Evaluacija uspeha studenata";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUcitajStudente;
        private System.Windows.Forms.Button btnOdrediUpisi;
        private System.Windows.Forms.Button btnNoviPredmet;
        private System.Windows.Forms.Button btnDodajStrategiju;
        private System.Windows.Forms.ListBox lbStudenti;
        private System.Windows.Forms.OpenFileDialog ofdUcitajStudente;
        private System.Windows.Forms.OpenFileDialog ofdDodajPredmet;
        private System.Windows.Forms.OpenFileDialog ofdDodajStrategiju;
        private System.Windows.Forms.SaveFileDialog sfdSacuvajOcene;
        private System.Windows.Forms.ListBox lbPredmeti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbStrategije;
        private System.Windows.Forms.Label label3;
    }
}


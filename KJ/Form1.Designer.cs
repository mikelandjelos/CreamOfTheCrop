namespace _18203
{
    partial class Form1
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
            this.lbxStrat = new System.Windows.Forms.ListBox();
            this.lbxPredmet = new System.Windows.Forms.ListBox();
            this.lbxStudent = new System.Windows.Forms.ListBox();
            this.btnStrat = new System.Windows.Forms.Button();
            this.btnStudent = new System.Windows.Forms.Button();
            this.btnPredmet = new System.Windows.Forms.Button();
            this.ofdUcitaj = new System.Windows.Forms.OpenFileDialog();
            this.txtNovaStrat = new System.Windows.Forms.TextBox();
            this.lblNovaStrat = new System.Windows.Forms.Label();
            this.btnIzmenjenaStrat = new System.Windows.Forms.Button();
            this.btnOcena = new System.Windows.Forms.Button();
            this.btnNovaStr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxStrat
            // 
            this.lbxStrat.FormattingEnabled = true;
            this.lbxStrat.Location = new System.Drawing.Point(8, 61);
            this.lbxStrat.Name = "lbxStrat";
            this.lbxStrat.Size = new System.Drawing.Size(176, 173);
            this.lbxStrat.TabIndex = 1;
            this.lbxStrat.DoubleClick += new System.EventHandler(this.lbxStrat_DoubleClick);
            // 
            // lbxPredmet
            // 
            this.lbxPredmet.FormattingEnabled = true;
            this.lbxPredmet.Location = new System.Drawing.Point(226, 61);
            this.lbxPredmet.Name = "lbxPredmet";
            this.lbxPredmet.Size = new System.Drawing.Size(176, 173);
            this.lbxPredmet.TabIndex = 3;
            this.lbxPredmet.DoubleClick += new System.EventHandler(this.lbxPredmet_DoubleClick);
            // 
            // lbxStudent
            // 
            this.lbxStudent.FormattingEnabled = true;
            this.lbxStudent.Location = new System.Drawing.Point(451, 61);
            this.lbxStudent.Name = "lbxStudent";
            this.lbxStudent.Size = new System.Drawing.Size(175, 173);
            this.lbxStudent.TabIndex = 5;
            this.lbxStudent.SelectedIndexChanged += new System.EventHandler(this.lbxStudent_SelectedIndexChanged);
            this.lbxStudent.DoubleClick += new System.EventHandler(this.lbxStudent_DoubleClick);
            // 
            // btnStrat
            // 
            this.btnStrat.Location = new System.Drawing.Point(46, 3);
            this.btnStrat.Name = "btnStrat";
            this.btnStrat.Size = new System.Drawing.Size(75, 52);
            this.btnStrat.TabIndex = 6;
            this.btnStrat.Text = "Ucitajte strategije";
            this.btnStrat.UseVisualStyleBackColor = true;
            this.btnStrat.Click += new System.EventHandler(this.btnStrat_Click);
            // 
            // btnStudent
            // 
            this.btnStudent.Enabled = false;
            this.btnStudent.Location = new System.Drawing.Point(502, 3);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Size = new System.Drawing.Size(75, 52);
            this.btnStudent.TabIndex = 7;
            this.btnStudent.Text = "Ucitajte studente";
            this.btnStudent.UseVisualStyleBackColor = true;
            this.btnStudent.Click += new System.EventHandler(this.btnStudent_Click);
            // 
            // btnPredmet
            // 
            this.btnPredmet.Enabled = false;
            this.btnPredmet.Location = new System.Drawing.Point(273, 3);
            this.btnPredmet.Name = "btnPredmet";
            this.btnPredmet.Size = new System.Drawing.Size(75, 52);
            this.btnPredmet.TabIndex = 8;
            this.btnPredmet.Text = "Ucitajte predmete";
            this.btnPredmet.UseVisualStyleBackColor = true;
            this.btnPredmet.Click += new System.EventHandler(this.btnPredmet_Click);
            // 
            // ofdUcitaj
            // 
            this.ofdUcitaj.DefaultExt = "*.xml";
            // 
            // txtNovaStrat
            // 
            this.txtNovaStrat.Location = new System.Drawing.Point(119, 262);
            this.txtNovaStrat.Name = "txtNovaStrat";
            this.txtNovaStrat.Size = new System.Drawing.Size(100, 20);
            this.txtNovaStrat.TabIndex = 9;
            this.txtNovaStrat.TextChanged += new System.EventHandler(this.txtNovaStrat_TextChanged);
            // 
            // lblNovaStrat
            // 
            this.lblNovaStrat.AutoSize = true;
            this.lblNovaStrat.Location = new System.Drawing.Point(14, 246);
            this.lblNovaStrat.Name = "lblNovaStrat";
            this.lblNovaStrat.Size = new System.Drawing.Size(334, 13);
            this.lblNovaStrat.TabIndex = 10;
            this.lblNovaStrat.Text = "Odaberite predmet i unesite ime strategije u koju zelite da se promeni: ";
            // 
            // btnIzmenjenaStrat
            // 
            this.btnIzmenjenaStrat.Enabled = false;
            this.btnIzmenjenaStrat.Location = new System.Drawing.Point(129, 288);
            this.btnIzmenjenaStrat.Name = "btnIzmenjenaStrat";
            this.btnIzmenjenaStrat.Size = new System.Drawing.Size(75, 23);
            this.btnIzmenjenaStrat.TabIndex = 11;
            this.btnIzmenjenaStrat.Text = "Promeni";
            this.btnIzmenjenaStrat.UseVisualStyleBackColor = true;
            this.btnIzmenjenaStrat.Click += new System.EventHandler(this.btnIzmenjenaStrat_Click);
            // 
            // btnOcena
            // 
            this.btnOcena.Enabled = false;
            this.btnOcena.Location = new System.Drawing.Point(502, 268);
            this.btnOcena.Name = "btnOcena";
            this.btnOcena.Size = new System.Drawing.Size(121, 37);
            this.btnOcena.TabIndex = 14;
            this.btnOcena.Text = "Izracunati ocenu";
            this.btnOcena.UseVisualStyleBackColor = true;
            this.btnOcena.Click += new System.EventHandler(this.btnOcena_Click);
            // 
            // btnNovaStr
            // 
            this.btnNovaStr.Location = new System.Drawing.Point(378, 261);
            this.btnNovaStr.Name = "btnNovaStr";
            this.btnNovaStr.Size = new System.Drawing.Size(75, 50);
            this.btnNovaStr.TabIndex = 15;
            this.btnNovaStr.Text = "Dodajte novu strategiju";
            this.btnNovaStr.UseVisualStyleBackColor = true;
            this.btnNovaStr.Click += new System.EventHandler(this.btnNovaStr_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 350);
            this.Controls.Add(this.btnNovaStr);
            this.Controls.Add(this.btnOcena);
            this.Controls.Add(this.btnIzmenjenaStrat);
            this.Controls.Add(this.lblNovaStrat);
            this.Controls.Add(this.txtNovaStrat);
            this.Controls.Add(this.btnPredmet);
            this.Controls.Add(this.btnStudent);
            this.Controls.Add(this.btnStrat);
            this.Controls.Add(this.lbxStudent);
            this.Controls.Add(this.lbxPredmet);
            this.Controls.Add(this.lbxStrat);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lbxStrat;
        private System.Windows.Forms.ListBox lbxPredmet;
        private System.Windows.Forms.ListBox lbxStudent;
        private System.Windows.Forms.Button btnStrat;
        private System.Windows.Forms.Button btnStudent;
        private System.Windows.Forms.Button btnPredmet;
        private System.Windows.Forms.OpenFileDialog ofdUcitaj;
        private System.Windows.Forms.TextBox txtNovaStrat;
        private System.Windows.Forms.Label lblNovaStrat;
        private System.Windows.Forms.Button btnIzmenjenaStrat;
        private System.Windows.Forms.Button btnOcena;
        private System.Windows.Forms.Button btnNovaStr;
    }
}


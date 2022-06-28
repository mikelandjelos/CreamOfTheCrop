namespace EvaluacijaStudenata
{
    partial class MyForm
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
            this.btnChangeGradingStrategy = new System.Windows.Forms.Button();
            this.btnAddGradingStrategy = new System.Windows.Forms.Button();
            this.txtGradingStrategy = new System.Windows.Forms.TextBox();
            this.dlgLoadFromFile = new System.Windows.Forms.OpenFileDialog();
            this.lBoxSubjects = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.dlgSaveToFile = new System.Windows.Forms.SaveFileDialog();
            this.btnLoadStudents = new System.Windows.Forms.Button();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.lBoxStudents = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnChangeGradingStrategy
            // 
            this.btnChangeGradingStrategy.Location = new System.Drawing.Point(18, 194);
            this.btnChangeGradingStrategy.Name = "btnChangeGradingStrategy";
            this.btnChangeGradingStrategy.Size = new System.Drawing.Size(138, 41);
            this.btnChangeGradingStrategy.TabIndex = 1;
            this.btnChangeGradingStrategy.Text = "Change Grading Strategy";
            this.btnChangeGradingStrategy.UseVisualStyleBackColor = true;
            this.btnChangeGradingStrategy.Click += new System.EventHandler(this.btnChangeGradingStrategy_Click);
            // 
            // btnAddGradingStrategy
            // 
            this.btnAddGradingStrategy.Location = new System.Drawing.Point(18, 406);
            this.btnAddGradingStrategy.Name = "btnAddGradingStrategy";
            this.btnAddGradingStrategy.Size = new System.Drawing.Size(272, 23);
            this.btnAddGradingStrategy.TabIndex = 1;
            this.btnAddGradingStrategy.Text = "Add Grading Strategy";
            this.btnAddGradingStrategy.UseVisualStyleBackColor = true;
            this.btnAddGradingStrategy.Click += new System.EventHandler(this.btnAddGradingStrategy_Click);
            // 
            // txtGradingStrategy
            // 
            this.txtGradingStrategy.Location = new System.Drawing.Point(162, 212);
            this.txtGradingStrategy.Name = "txtGradingStrategy";
            this.txtGradingStrategy.Size = new System.Drawing.Size(128, 23);
            this.txtGradingStrategy.TabIndex = 2;
            // 
            // dlgLoadFromFile
            // 
            this.dlgLoadFromFile.DefaultExt = "xml";
            this.dlgLoadFromFile.Filter = "Xml files|*.xml";
            // 
            // lBoxSubjects
            // 
            this.lBoxSubjects.FormattingEnabled = true;
            this.lBoxSubjects.ItemHeight = 15;
            this.lBoxSubjects.Location = new System.Drawing.Point(18, 24);
            this.lBoxSubjects.Name = "lBoxSubjects";
            this.lBoxSubjects.Size = new System.Drawing.Size(272, 154);
            this.lBoxSubjects.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "New Grading Strategy";
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.Location = new System.Drawing.Point(18, 435);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(272, 23);
            this.btnAddSubject.TabIndex = 7;
            this.btnAddSubject.Text = "Add New Subject";
            this.btnAddSubject.UseVisualStyleBackColor = true;
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // dlgSaveToFile
            // 
            this.dlgSaveToFile.DefaultExt = "txt";
            // 
            // btnLoadStudents
            // 
            this.btnLoadStudents.Location = new System.Drawing.Point(18, 464);
            this.btnLoadStudents.Name = "btnLoadStudents";
            this.btnLoadStudents.Size = new System.Drawing.Size(272, 23);
            this.btnLoadStudents.TabIndex = 8;
            this.btnLoadStudents.Text = "Load Students And Calculate Grades";
            this.btnLoadStudents.UseVisualStyleBackColor = true;
            this.btnLoadStudents.Click += new System.EventHandler(this.btnLoadStudents_Click);
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Location = new System.Drawing.Point(18, 493);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(272, 23);
            this.btnSaveToFile.TabIndex = 9;
            this.btnSaveToFile.Text = "Save to File";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // lBoxStudents
            // 
            this.lBoxStudents.FormattingEnabled = true;
            this.lBoxStudents.ItemHeight = 15;
            this.lBoxStudents.Location = new System.Drawing.Point(18, 259);
            this.lBoxStudents.Name = "lBoxStudents";
            this.lBoxStudents.Size = new System.Drawing.Size(272, 139);
            this.lBoxStudents.TabIndex = 10;
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 544);
            this.Controls.Add(this.lBoxStudents);
            this.Controls.Add(this.btnSaveToFile);
            this.Controls.Add(this.btnLoadStudents);
            this.Controls.Add(this.btnAddSubject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lBoxSubjects);
            this.Controls.Add(this.txtGradingStrategy);
            this.Controls.Add(this.btnAddGradingStrategy);
            this.Controls.Add(this.btnChangeGradingStrategy);
            this.Name = "MyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnChangeGradingStrategy;
        private Button btnAddGradingStrategy;
        private TextBox txtGradingStrategy;
        private OpenFileDialog dlgLoadFromFile;
        private ListBox lBoxSubjects;
        private Label label1;
        private Button btnAddSubject;
        private SaveFileDialog dlgSaveToFile;
        private Button btnLoadStudents;
        private Button btnSaveToFile;
        private ListBox lBoxStudents;
    }
}
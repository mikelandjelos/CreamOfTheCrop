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

namespace EvaluacijaStudenata
{
    public partial class MyForm : Form
    {
        private List<Exam> exams;
        private List<Strategy> strategyList;
        private List<Student> students;

        public MyForm()
        {
            InitializeComponent();

            exams = new List<Exam>();
            strategyList = new List<Strategy>();
            students = new List<Student>();

            createStrategies();
            createExams();
            refreshListBox(lBoxSubjects);
        }
        private void createStrategies()
        {
            strategyList.Add(new Strategy("A", 55, 64, 65, 74, 75, 84, 85, 94, 95, 100));
            strategyList.Add(new Strategy("B", 50, 64, 65, 89, 90, 97, 90, 97, 98, 100));
        }
        private void createExams()
        {
            Strategy stratA = strategyList.Find(x => x.Name.Equals("A"));
            Strategy stratB = strategyList.Find(x => x.Name.Equals("B"));

            List<ExamPart> parts = new List<ExamPart>();
            parts.Add(new ExamPart("Pismeni", 50, 32));
            parts.Add(new ExamPart("Lab", 0, 20));
            exams.Add(new Exam("OO Projektovanje", stratA, new ExamPart("Usmeni", 50, 48), parts));

            parts.Clear();
            parts.Add(new ExamPart("Projekat a", 6 * 100 / 10, 10));
            parts.Add(new ExamPart("Projekat b", 8 * 100 / 10, 10));
            parts.Add(new ExamPart("Lab", 8 * 100 / 20, 20));
            parts.Add(new ExamPart("Terenski zadatak", 8 * 100 / 20, 20));
            exams.Add(new Exam("Geodezija", stratA, new ExamPart("Usmeni", 50, 40), parts));

            parts.Clear();
            parts.Add(new ExamPart("Istrazivanje", 7 * 100 / 20, 20));
            exams.Add(new Exam("Istorija starog veka", stratA, new ExamPart("Usmeni", 60, 80), parts));

            parts.Clear();
            parts.Add(new ExamPart("Test A", 60, 25));
            parts.Add(new ExamPart("Test B", 60, 25));
            parts.Add(new ExamPart("Lab 1", 0, 10));
            parts.Add(new ExamPart("Lab 2", 2 * 100 / 10, 10));
            parts.Add(new ExamPart("Lab 3", 5 * 100 / 10, 10));
            exams.Add(new Exam("Farmakologija", stratB, new ExamPart("Usmeni", 80, 20), parts));

            parts.Clear();
            parts.Add(new ExamPart("SW projekat", 0, 30));
            parts.Add(new ExamPart("MM projekat", 15 * 100 / 30, 30));
            exams.Add(new Exam("MMS", stratB, new ExamPart("Usmeni", 50, 40), parts));

            parts.Clear();
            exams.Add(new Exam("Rimsko pravo", stratB, new ExamPart("Usmeni", 55, 100), parts));
        }

        private void refreshListBox(ListBox lb)
        {
            lb.Items.Clear();
            if (lb.Name == lBoxSubjects.Name)
                lb.Items.AddRange(exams.ToArray());
            else if (lb.Name == lBoxStudents.Name)
            {
                foreach (Student student in students)
                {
                    student.calculateGrade();
                }
                lb.Items.AddRange(students.ToArray());
            }
        }

        private void btnAddGradingStrategy_Click(object sender, EventArgs e)
        {
            if(dlgLoadFromFile.ShowDialog()==DialogResult.OK)
            {
                XmlTextReader Xdoc = new XmlTextReader(dlgLoadFromFile.FileName);
                Xdoc.WhitespaceHandling = WhitespaceHandling.None;
                string name = "";
                int[] max = new int[5];
                int[] min = new int[5];
                int i = 0;

                Xdoc.Read();
                if (Xdoc.NodeType == XmlNodeType.Element && Xdoc.Name != "Strategija")
                {
                    MessageBox.Show("The document isn't correct!");
                    return;
                }

                try
                {
                    while (Xdoc.Read())
                    {
                        if (Xdoc.NodeType == XmlNodeType.Element && Xdoc.Name == "Naziv")
                        {
                            name = Xdoc.ReadElementContentAsString();
                        }
                        if (Xdoc.NodeType == XmlNodeType.Element && Xdoc.Name == "Min")
                        {
                            min[i] = Xdoc.ReadElementContentAsInt();
                        }
                        if (Xdoc.NodeType == XmlNodeType.Element && Xdoc.Name == "Max")
                        {
                            max[i++] = Xdoc.ReadElementContentAsInt();
                        }
                    }
                }
                catch(Exception ex)
                {
                    return;
                }
                finally
                {
                    if (strategyList.Find(x => x.Name.Equals(name)) != null)
                    {
                        MessageBox.Show("This strategy already exists in the system!");
                    }
                    else
                    {
                        strategyList.Add(new Strategy(name, min[0], max[0], min[1], max[1], min[2], max[2], min[3], max[3], min[4], max[4]));
                        foreach (Exam ex in lBoxSubjects.Items)
                        {
                            ex.Strategy = strategyList.Last();
                        }
                        refreshListBox(lBoxSubjects);
                        refreshListBox(lBoxStudents);
                        MessageBox.Show("Strategy successfully added and applied!");
                    }       
                }   
            }
        }

        private void btnChangeGradingStrategy_Click(object sender, EventArgs e)
        {
            string strat = txtGradingStrategy.Text;
            Strategy strategy = strategyList.Find(x => x.Name.Equals(strat));
            Exam ex = (Exam)lBoxSubjects.SelectedItem;
            if (ex == null)
                MessageBox.Show("Select a subject!");
            else if (strategy != null && ex != null && ex.Strategy != strategy)
            {
                ex.Strategy = strategy;
                refreshListBox(lBoxSubjects);
                refreshListBox(lBoxStudents);
                MessageBox.Show("Successful change!");
            }
            else if (strategy == null)
                MessageBox.Show("This strategy does not exist!");
            else
                MessageBox.Show("This subject already has this strategy!");
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            if (dlgLoadFromFile.ShowDialog() == DialogResult.OK)
            {
                XmlTextReader Xdoc = new XmlTextReader(dlgLoadFromFile.FileName);
                Xdoc.WhitespaceHandling = WhitespaceHandling.None;
                List<ExamPart> parts  = new List<ExamPart>();
                string partName = "";
                int partMin = 0;
                int partMax = 0;

                string strat = "";
                string name = "";
                int minPct = 0;
                int maxPoints = 0;

                Xdoc.Read();
                if (Xdoc.NodeType == XmlNodeType.Element && Xdoc.Name != "Predmet")
                {
                    MessageBox.Show("The document isn't correct!");
                    return;
                }

                try
                {
                    while (Xdoc.Read())
                    {
                        if (Xdoc.NodeType == XmlNodeType.Element && Xdoc.Name == "Strategija")
                        {
                            strat = Xdoc.ReadElementContentAsString();
                        }
                        if (Xdoc.NodeType == XmlNodeType.Element && Xdoc.Name == "Naziv")
                        {
                            name = Xdoc.ReadElementContentAsString();
                        }
                        if (Xdoc.NodeType == XmlNodeType.Element && Xdoc.Name == "UsmeniMinPct")
                        {
                            minPct = Xdoc.ReadElementContentAsInt();
                        }
                        if (Xdoc.NodeType == XmlNodeType.Element && Xdoc.Name == "UsmeniMaxPoena")
                        {
                            maxPoints = Xdoc.ReadElementContentAsInt();
                        }
                        if (Xdoc.NodeType == XmlNodeType.Element && Xdoc.Name == "Name")
                        {
                            partName = Xdoc.ReadElementContentAsString();
                        }
                        if (Xdoc.NodeType == XmlNodeType.Element && Xdoc.Name == "Min")
                        {
                            partMin = Xdoc.ReadElementContentAsInt();
                        }
                        if (Xdoc.NodeType == XmlNodeType.Element && Xdoc.Name == "Max")
                        {
                            partMax = Xdoc.ReadElementContentAsInt();
                        }
                        if (partMax != 0)
                        {
                            parts.Add(new ExamPart(partName, partMin * 100 / partMax, partMax));
                            partMin = partMax = 0;
                        }
                    }
                }
                catch(Exception ex)
                {
                    return;
                }
                finally
                {             
                    if (exams.Find(x => x.Name.Equals(name)) != null)
                        MessageBox.Show("This subject already exists in the system!");
                    else
                    {
                        Strategy strategy = strategyList.Find(x => x.Name.Equals(strat));
                        if (strategy != null)
                        {
                            exams.Add(new Exam(name, strategy, new ExamPart("Usmeni", minPct, maxPoints), parts));
                            refreshListBox(lBoxSubjects);
                            MessageBox.Show("Subject successfully added!");
                        }
                        else
                            MessageBox.Show("The strategy for this subject doesn't exist!\nSubject not added!");
                    }
                }
            }
        }

        private void btnLoadStudents_Click(object sender, EventArgs e)
        {
            if (dlgLoadFromFile.ShowDialog() == DialogResult.OK)
            {
                XmlTextReader Xdoc = new XmlTextReader(dlgLoadFromFile.FileName);
                Xdoc.WhitespaceHandling = WhitespaceHandling.None;

                string index = "";
                string subject = "";

                Exam exam = null;
                int[] points = new int[0];
                int i = 0;

                Xdoc.Read();
                if (Xdoc.NodeType == XmlNodeType.Element && Xdoc.Name != "Studenti")
                {
                    MessageBox.Show("The document isn't correct!");
                    return;
                }

                try
                {
                    while (Xdoc.Read())
                    {
                        if (Xdoc.NodeType == XmlNodeType.Element && Xdoc.Name == "Indeks")
                        {
                            index = Xdoc.ReadElementContentAsString();
                        }
                        if (Xdoc.NodeType == XmlNodeType.Element && Xdoc.Name == "Predmet")
                        {
                            subject = Xdoc.ReadElementContentAsString();
                            if (exams.Find(x => x.Name.Equals(subject)) == null)
                            {
                                while(Xdoc.Name != "Student")
                                {
                                    Xdoc.Read();
                                }
                            }
                            else
                            {
                                exam = exams.Find(x => x.Name.Equals(subject));
                                points = new int[exam.NumOfParts() + 1];
                            }
                        }
                        if (Xdoc.NodeType == XmlNodeType.Element && (Xdoc.Name == "Usmeni" || Xdoc.Name == "Value"))
                        {
                            points[i++] = Xdoc.ReadElementContentAsInt();
                        }
                        if (exam != null && i == exam.NumOfParts() + 1)
                        {
                            students.Add(new Student(index, exam, points));
                            i = 0;
                            exam = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return;
                }
                finally
                {
                    refreshListBox(lBoxStudents);
                    Xdoc.Close();
                } 
            }
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            if (students.Count == 0)
            {
                MessageBox.Show("No students in the system!");
                return;
            }
            if (dlgSaveToFile.ShowDialog() == DialogResult.OK) 
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(dlgSaveToFile.FileName, FileMode.Create)))
                {
                    foreach(Student s in students)
                    {
                        sw.WriteLine(s);
                    }
                }
            }
        }
    }
}

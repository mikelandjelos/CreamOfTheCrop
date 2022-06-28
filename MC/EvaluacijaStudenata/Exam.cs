using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacijaStudenata
{
    public class Exam
    {
        private string name;
        private Strategy strategy;
        private ExamPart spokenExam;
        private List<ExamPart> examParts;

        public Strategy Strategy { get => strategy; set => strategy = value; }
        public string Name { get => name; set => name = value; }
        public int NumOfParts() { return examParts.Count; }

        public Exam() { }

        public Exam(string name, Strategy strategy, ExamPart spokenExam, List<ExamPart> examParts)
        {
            this.name = name;
            Strategy = strategy;
            this.spokenExam = spokenExam;
            this.examParts = new List<ExamPart>(examParts);
        }
        public int calculateGrade(int[] points)
        {
            if (points[0] < spokenExam.retMinPoints())
                return 5;
            else
            {
                int i = 1;
                double sumOfPoints = points[0];
                foreach (ExamPart part in examParts)
                {
                    if (points[i] < part.retMinPoints())
                        return 5;
                    sumOfPoints += points[i++];
                }
                return strategy.calculateGrade(sumOfPoints);
            }
        }

        public override string ToString()
        {
            return name + " " + strategy.Name;
        }
    }
}

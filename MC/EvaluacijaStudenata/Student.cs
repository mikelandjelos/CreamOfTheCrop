using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacijaStudenata
{
    public class Student
    {
        private string index;
        private Exam exam;
        private int[] points;
        private int grade;

        public Student(string index, Exam exam, int[] points)
        {
            this.index = index;
            this.exam = exam;
            this.points = points;
        }
        public void calculateGrade()
        {
            grade = exam.calculateGrade(points);
        }
        public override string ToString()
        {
            return index + " " + exam.ToString() + " Poeni: " + points.Sum() + " Ocena: " + grade;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacijaStudenata
{
    public class Strategy
    {
        private string name;
        private List<Grade> grades;

        public string Name { get => name; set => name = value; }

        public Strategy(string name, int minFor6, int maxFor6, int minFor7, int maxFor7, 
            int minFor8, int maxFor8, int minFor9, int maxFor9, int minFor10, int maxFor10)
        {
            Name = name;
            grades = new List<Grade>();
            grades.Add(new Grade(10, minFor10, maxFor10));
            grades.Add(new Grade(9, minFor9, maxFor9));
            grades.Add(new Grade(8, minFor8, maxFor8));
            grades.Add(new Grade(7, minFor7, maxFor7));
            grades.Add(new Grade(6, minFor6, maxFor6));    
        }

        public int calculateGrade(double sumOfPoints)
        {
            int grade = 5;
            for (int i = 0; i < grades.Count; i++) 
            {
                grade = grades[i].checkGrade(sumOfPoints);
                if (grade != 5)
                    return grade;
            }
            return grade;
        }
    }
}

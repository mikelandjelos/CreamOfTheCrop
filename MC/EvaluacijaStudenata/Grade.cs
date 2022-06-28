using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacijaStudenata
{
    public class Grade
    {
        private int grade;
        private int min;
        private int max;

        public Grade(int grade, int min, int max)
        {
            this.grade = grade;
            this.min = min;
            this.max = max;
        }
        public int checkGrade(double sumOfPoints)
        {
            if (sumOfPoints >= min && sumOfPoints <= max)
                return grade;
            else
                return 5;
        }
    }
}

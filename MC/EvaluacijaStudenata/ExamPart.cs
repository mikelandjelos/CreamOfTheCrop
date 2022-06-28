using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacijaStudenata
{
    public class ExamPart
    {
        protected string name;
        private int minPct;
        private int maxPoints;

        public int MinPct { get => minPct; set => minPct = value; }
        public int MaxPoints { get => maxPoints; set => maxPoints = value; }

        public ExamPart(string name, int minPct, int maxPoints)
        {
            this.name = name;
            MinPct = minPct;
            MaxPoints = maxPoints;
        }

        public double retMinPoints()
        {
            return minPct * maxPoints / (double)100;
        }
    }
}

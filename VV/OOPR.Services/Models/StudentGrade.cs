using Newtonsoft.Json;
using System.Collections.Generic;

namespace OOPR.Services.Models
{
    /// <summary>
    /// Contains information about the grade for the given subject of a specific student.
    /// </summary>
    public class StudentGrade
    {
        public StudentGrade()
        {
            Elements = new List<GradingElement>();
        }

        /// <summary>
        /// Index number.
        /// </summary>
        [JsonProperty("Indeks")]
        public int IndexNumber { get; set; }

        /// <summary>
        /// Subject name
        /// </summary>
        [JsonProperty("Predmet")]
        public string SubjectName { get; set; }

        /// <summary>
        /// Number of points made on oral exam for the given subject.
        /// </summary>
        [JsonProperty("Usmeni")]
        public int OralExamPoints { get; set; }

        /// <summary>
        /// List of additional additional subject elements.
        /// </summary>
        [JsonProperty("Elementi")]
        public List<GradingElement> Elements { get; set; }

        public decimal ScoredPoints
        {
            get
            {
                int scoredPointsSum = 0;
                foreach (var element in Elements)
                {
                    scoredPointsSum += element.Points;
                }

                return scoredPointsSum += OralExamPoints;
            }
        }
    }
}

using OOPR.Services.Enums;
using OOPR.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPR.Services.Models
{
    public class StudentGradeEvaluationResult
    {
        public StudentGradeEvaluationResult(int indexNumber, string subjectName, GradeEnum grade)
        {
            this.IndexNumber = indexNumber;
            this.SubjectName = subjectName;
            this.Grade = grade;
        }

        /// <summary>
        /// Index number.
        /// </summary>
        public int IndexNumber { get; set; }

        /// <summary>
        /// Subject name
        /// </summary>
        public string SubjectName { get; set; }

        /// <summary>
        /// Grade that student scored for the given subject.
        /// </summary>
        public GradeEnum Grade { get; set; }

        public override string ToString()
        {
            return $"{IndexNumber} - {SubjectName} - {Grade.GetEnumDisplayName()}";
        }
    }
}

using Newtonsoft.Json;
using OOPR.Repository.Interfaces;
using OOPR.Services.Interfaces;
using OOPR.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OOPR.Services.Implementation
{
    public class StudentEvaluatorService : IStudentEvaluatorService
    {
        private readonly IStudentGradeEvaluationService studentGradeEvaluationService;

        public StudentEvaluatorService(IStudentGradeEvaluationService studentGradeEvaluationService)
        {
            this.studentGradeEvaluationService = studentGradeEvaluationService;
        }

        public List<StudentGrade> GetStudentGradeEvaluationData()
        {
            using (var streamReader = new StreamReader("rezultati.json"))
            {
                var json = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<StudentGrade>>(json);
            }
        }

        public List<StudentGradeEvaluationResult> GenerateStudentGradeEvaluationResult()
        {
            var data = GetStudentGradeEvaluationData();
            var result = new List<StudentGradeEvaluationResult>();

            foreach (var item in data)
            {
                var grade = studentGradeEvaluationService.GetGrade(item);
                result.Add(new StudentGradeEvaluationResult(item.IndexNumber, item.SubjectName, grade));
            }

            return result;
        }
    }
}
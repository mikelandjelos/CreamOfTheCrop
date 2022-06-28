using OOPR.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPR.Services.Interfaces
{
    public interface IStudentEvaluatorService
    {
        List<StudentGradeEvaluationResult> GenerateStudentGradeEvaluationResult();
    }
}

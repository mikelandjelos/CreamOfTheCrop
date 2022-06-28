using OOPR.Services.Enums;
using OOPR.Services.Models;

namespace OOPR.Services.Interfaces
{
    public interface IStudentGradeEvaluationService
    {
        GradeEnum GetGrade(StudentGrade studentGrade);
    }
}

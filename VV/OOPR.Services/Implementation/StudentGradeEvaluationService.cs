using OOPR.Repository.Interfaces;
using OOPR.Services.Enums;
using OOPR.Services.Interfaces;
using OOPR.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPR.Services.Implementation
{
    public class StudentGradeEvaluationService : IStudentGradeEvaluationService
    {
        private readonly IGradeStrategiesServices gradeStrategiesServices;
        private readonly ISubjectGradingStrategyDetailsService subjectGradingStrategyDetailsService;

        public StudentGradeEvaluationService(IGradeStrategiesServices gradeStrategiesServices, ISubjectGradingStrategyDetailsService subjectGradingStrategyDetailsService)
        {
            this.gradeStrategiesServices = gradeStrategiesServices;
            this.subjectGradingStrategyDetailsService = subjectGradingStrategyDetailsService;
        }



        public GradeEnum GetGrade(StudentGrade studentGrade)
        {
            // get subject evaluation
            var subject = subjectGradingStrategyDetailsService.GetSubject(studentGrade.SubjectName);

            // check if oral exam is passed
            if (!IsOralExamPassed(subject, studentGrade.OralExamPoints) || !AreGradingElementsPassed(subject, studentGrade.Elements))
            {
                return GradeEnum.Five;
            }

            return CalculateGrade(subject.StrategyName, subject.MaxPossibleNumberOfPoints, studentGrade.ScoredPoints);
        }

        private GradeEnum CalculateGrade(string strategyName, decimal maxPossibleNumberOfPoints, decimal scoredPoints)
        {
            var strategy = gradeStrategiesServices.GetStrategy(strategyName);

            if (strategyName == null)
            {
                throw new InvalidOperationException($"Strategija: {strategyName} ne postoji.");
            }

            var percentageOfScoredPoints = scoredPoints / maxPossibleNumberOfPoints * 100;

            // it is important to order list with grades descending in order to optimize algorythm.
            // the first result that matches percentageOfScoredPoints is the grade that student scored
            // because we check from the highest to the lowest grade.
            var sortedGradesStrategy = strategy.Grades.OrderByDescending(item => item.Grade);

            foreach (var grade in sortedGradesStrategy)
            {
                if (percentageOfScoredPoints > grade.MinimumPercentage)
                {
                    return grade.Grade;
                }
            }

            // if grade is not found, it means that student didn't pass the exam.
            return GradeEnum.Five;
        }

        private bool IsOralExamPassed(SubjectGradingStrategy subjectGradingStrategy, decimal oralExamScoredPoints)
        {
            var minimumPointsForPass = subjectGradingStrategy.OralExamMaxPoints * ((decimal)subjectGradingStrategy.OralExamMinPassingPercentage / 100);

            return oralExamScoredPoints > minimumPointsForPass;
        }

        private bool AreGradingElementsPassed(SubjectGradingStrategy subjectGradingStrategy, List<GradingElement> gradingElements)
        {
            foreach (var gradingElement in gradingElements)
            {
                var elementGradingStrategy = subjectGradingStrategy.Elements.FirstOrDefault(item => item.Name == gradingElement.Name);

                if (elementGradingStrategy == null)
                {
                    throw new InvalidOperationException("Za zadati predmet ne postoji strategija ocenjivanja.");
                }

                var minimumPointsForPass = elementGradingStrategy.PassingLimitType == PassingLimitType.Pct
                                           ? ((decimal?)elementGradingStrategy.PassingLimit / 100) * elementGradingStrategy.MaxPoints
                                           : elementGradingStrategy.PassingLimit;

                // if one of the elements is not passed, then student didn't pass the exam
                // false is returned here, because there is no need to itterate through the whole list,
                // because there is no point in examing the whole list if the student failed on the first element.
                if (gradingElement.Points < minimumPointsForPass)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

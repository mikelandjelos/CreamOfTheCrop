using Microsoft.Extensions.DependencyInjection;
using OOPR.Repository.Interfaces;
using OOPR.Repository.Services;
using OOPR.Services;
using OOPR.Services.Implementation;
using OOPR.Services.Interfaces;
using System;
using System.IO;
using System.Text;

namespace OOPR
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<GradeStrategiesCache>()
                .AddSingleton<SubjectGradingStrategiesCache>()
                .AddTransient<ISubjectGradingStrategyDetailsService, SubjectGradingStrategyDetailsService>()
                .AddTransient<IGradeStrategiesServices, GradeStrategiesServices>()
                .AddTransient<IStudentGradeEvaluationService, StudentGradeEvaluationService>()
                .AddTransient<IStudentEvaluatorService, StudentEvaluatorService>()
                .BuildServiceProvider();

            var gradeStrategiesService = serviceProvider.GetService<IGradeStrategiesServices>();
            var subjectGradingStrategyDetailsService = serviceProvider.GetService<ISubjectGradingStrategyDetailsService>();
            var studentEvaluatorService = serviceProvider.GetService<IStudentEvaluatorService>();

            gradeStrategiesService.Load();
            subjectGradingStrategyDetailsService.Load();

            var studentGradesResult = studentEvaluatorService.GenerateStudentGradeEvaluationResult();

            var stringBuilder = new StringBuilder();
            foreach (var studentGrade in studentGradesResult)
            {
                stringBuilder.AppendLine(studentGrade.ToString());
            }

            using (var streamWriter = new StreamWriter("rezultatiIspita.txt"))
            {
                streamWriter.Write(stringBuilder.ToString());
            }

            Console.WriteLine("Hello World!");
        }

    }
}

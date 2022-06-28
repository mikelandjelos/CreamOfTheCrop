using OOPR.Services.Enums;
using OOPR.Services.Models;
using System.Collections.Generic;

namespace OOPR.Services
{
    public sealed class GradeStrategiesCache
    {
        internal readonly List<StrategyModel> SubjectGradingStrategies = new List<StrategyModel>
        {
            new StrategyModel("A",  new List<GradeModel> { new GradeModel(GradeEnum.Six, 55),
                                                           new GradeModel(GradeEnum.Seven, 65),
                                                           new GradeModel(GradeEnum.Eight, 75),
                                                           new GradeModel(GradeEnum.Nine, 85),
                                                           new GradeModel(GradeEnum.Ten, 95)
                                                          }),
            new StrategyModel("B",  new List<GradeModel> { new GradeModel(GradeEnum.Six, 50),
                                                new GradeModel(GradeEnum.Seven, 65),
                                                new GradeModel(GradeEnum.Eight, 90),
                                                new GradeModel(GradeEnum.Nine, 95),
                                                new GradeModel(GradeEnum.Ten, 98)
                                                })
        };
    }
}

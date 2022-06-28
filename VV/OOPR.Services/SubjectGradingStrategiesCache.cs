using OOPR.Services.Enums;
using OOPR.Services.Models;
using System.Collections.Generic;

namespace OOPR.Services
{
    public sealed class SubjectGradingStrategiesCache
    {
        internal readonly List<SubjectGradingStrategy> SubjectGradingStrategies = new List<SubjectGradingStrategy>
        {
            new SubjectGradingStrategy("A",
                                       "OO Projektovanje",
                                       50,
                                       48,
                                       new List<GradingElementDefinition> { new GradingElementDefinition("Pismeni", 32, 50, PassingLimitType.Pct),
                                                                            new GradingElementDefinition("Lab", 20, null, null)
                                                                          }
                                       ),
            new SubjectGradingStrategy("A",
                                       "Geodezija",
                                       50,
                                       40,
                                       new List<GradingElementDefinition> { new GradingElementDefinition("Projekat a", 10, 6, PassingLimitType.Pts),
                                                                            new GradingElementDefinition("Projekat b", 10, 8, PassingLimitType.Pts),
                                                                            new GradingElementDefinition("Lab", 20, 8, PassingLimitType.Pts),
                                                                            new GradingElementDefinition("Terenski zadatak", 20, 8, PassingLimitType.Pts)
                                                                            }
                                       ),
            new SubjectGradingStrategy("A",
                                       "Istorija starog veka",
                                       60,
                                       80,
                                       new List<GradingElementDefinition> { new GradingElementDefinition("Istrazivanje", 20, 7, PassingLimitType.Pts)
                                                                            }
                                       ),
            new SubjectGradingStrategy("B",
                            "Farmakologija",
                            80,
                            20,
                            new List<GradingElementDefinition> { new GradingElementDefinition("Test A", 25, 60, PassingLimitType.Pct),
                                                                new GradingElementDefinition("Test B", 25, 60, PassingLimitType.Pct),
                                                                new GradingElementDefinition("Lab 1", 10, null, null),
                                                                new GradingElementDefinition("Lab 2", 10, 2, PassingLimitType.Pts),
                                                                new GradingElementDefinition("Lab 3", 10, 5, PassingLimitType.Pts)
                                                                }
                            ),
            new SubjectGradingStrategy("B",
                            "MMS",
                            50,
                            40,
                            new List<GradingElementDefinition> { new GradingElementDefinition("SW projekat", 30, null, null),
                                                                new GradingElementDefinition("MM projekat", 30, 15, PassingLimitType.Pts)
                                                                }
                            ),
            new SubjectGradingStrategy("B", "Rimsko pravo", 55, 100, new List<GradingElementDefinition>())
        };
    }
}

using Newtonsoft.Json;
using OOPR.Repository.Interfaces;
using OOPR.Services;
using OOPR.Services.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OOPR.Repository.Services
{
    public class SubjectGradingStrategyDetailsService : ISubjectGradingStrategyDetailsService
    {
        private readonly List<SubjectGradingStrategy> subjectGradingStrategies;

        public SubjectGradingStrategyDetailsService(SubjectGradingStrategiesCache subjectGradingStrategiesCache)
        {
            this.subjectGradingStrategies = subjectGradingStrategiesCache.SubjectGradingStrategies;
        }

        public void Load()
        {
            using (var streamReader = new StreamReader("predmeti.json"))
            {
                var json = streamReader.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<SubjectGradingStrategy>>(json);

                foreach (var item in items)
                {
                    var existingStrategy = GetSubject(item.Name);

                    if (existingStrategy != null)
                    {
                        continue;
                    }

                    AddSubject(item);
                }
            }
        }

        public SubjectGradingStrategy GetSubject(string name)
        {
            return subjectGradingStrategies.FirstOrDefault(item => item.Name == name);
        }

        public void AddSubject(SubjectGradingStrategy strategy)
        {
            subjectGradingStrategies.Add(strategy);
        }
    }
}

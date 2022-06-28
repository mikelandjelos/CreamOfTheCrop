using Newtonsoft.Json;
using OOPR.Services;
using OOPR.Services.Interfaces;
using OOPR.Services.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OOPR.Repository.Services
{
    public class GradeStrategiesServices : IGradeStrategiesServices
    {
        private readonly List<StrategyModel> subjectGradingStrategies;

        public GradeStrategiesServices(GradeStrategiesCache gradeStrategiesCache)
        {
            this.subjectGradingStrategies = gradeStrategiesCache.SubjectGradingStrategies;
        }


        public void Load()
        {
            using (var streamReader = new StreamReader("strategije.json"))
            {
                var json = streamReader.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<StrategyModel>>(json);

                foreach (var item in items)
                {
                    var existingStrategy = GetStrategy(item.Name);

                    if (existingStrategy != null)
                    {
                        continue;
                    }

                    AddStrategy(item);
                }
            }
        }

        public StrategyModel GetStrategy(string name)
        {
            return subjectGradingStrategies.FirstOrDefault(item => item.Name == name);
        }

        public void AddStrategy(StrategyModel strategy)
        {
            subjectGradingStrategies.Add(strategy);
        }
    }
}

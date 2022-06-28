using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPR.Services.Models
{
    public class SubjectGradingStrategy
    {
        public SubjectGradingStrategy(string strategyName, string name, int oralExamMinPassPct, int oralExamMaxPts, List<GradingElementDefinition> elements)
        {
            this.StrategyName = strategyName;
            this.Name = name;
            this.OralExamMinPassingPercentage = oralExamMinPassPct;
            this.OralExamMaxPoints = oralExamMaxPts;
            this.Elements = elements;
        }

        public SubjectGradingStrategy()
        {
            this.Elements = new List<GradingElementDefinition>();
        }

        [JsonProperty("Strategija")]
        public string StrategyName { get; set; }

        [JsonProperty("Naziv")]
        public string Name { get; set; }

        [JsonProperty("UsmeniMinimumProcenataZaProlaz")]
        public int OralExamMinPassingPercentage { get; set; }

        [JsonProperty("UsmeniMaxPoena")]
        public int OralExamMaxPoints { get; set; }

        [JsonProperty("Elementi")]
        public List<GradingElementDefinition> Elements { get; set; }

        public int MaxPossibleNumberOfPoints
        {
            get
            {
                var maxPoints = 0;
                foreach (var element in Elements)
                {
                    maxPoints += element.MaxPoints;
                }

                return maxPoints + OralExamMaxPoints;
            }
        }
    }
}

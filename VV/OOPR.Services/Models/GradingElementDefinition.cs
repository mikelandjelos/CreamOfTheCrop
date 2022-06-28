using Newtonsoft.Json;
using OOPR.Services.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPR.Services.Models
{
    public class GradingElementDefinition
    {
        public GradingElementDefinition(string name, int maxPoints, int? passingLimit, PassingLimitType? passingLimitType)
        {
            this.Name = name;
            this.MaxPoints = maxPoints;
            this.PassingLimit = passingLimit;
            this.PassingLimitType = passingLimitType;
        }

        /// <summary>
        /// Grading element name.
        /// </summary>
        /// 
        [JsonProperty("Naziv")]
        public string Name { get; set; }

        /// <summary>
        /// Maximum number of possible points that can be achieved for the given element.
        /// </summary>
        [JsonProperty("MaxPoena")]
        public int MaxPoints { get; set; }

        /// <summary>
        /// Minimum limit for passing the given element.
        /// </summary>
        [JsonProperty("MinimumZaProlaz")]
        public int? PassingLimit { get; set; }

        /// <summary>
        /// Determines limit type (percentage or points) for passing the given element.
        /// </summary>
        [JsonProperty("TipVrednostiMinimumaZaProlaz")]
        public PassingLimitType? PassingLimitType { get; set; }
    }

    public class GradingElement
    {
        [JsonProperty("Naziv")]
        public string Name { get; set; }

        [JsonProperty("Poeni")]
        public int Points { get; set; }
    }
}

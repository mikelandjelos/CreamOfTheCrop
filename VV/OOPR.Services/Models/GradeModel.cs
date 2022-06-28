using Newtonsoft.Json;
using OOPR.Services.Enums;

namespace OOPR.Services.Models
{
    public class GradeModel
    {
        public GradeModel(GradeEnum grade, int minimumPercentage)
        {
            this.Grade = grade;
            this.MinimumPercentage = minimumPercentage;
        }

        [JsonProperty("Ocena")]
        public GradeEnum Grade { get; set; }

        [JsonProperty("MinimalniProcenat")]
        public int MinimumPercentage { get; set; }
    }
}

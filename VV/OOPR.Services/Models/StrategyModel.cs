using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPR.Services.Models
{
    public class StrategyModel
    {
        public StrategyModel(string name, List<GradeModel> grades)
        {
            this.Name = name;
            this.Grades = grades;
        }

        [JsonProperty("Naziv")]
        public string Name { get; set; }

        [JsonProperty("Ocene")]
        public List<GradeModel> Grades { get; set; }
    }
}

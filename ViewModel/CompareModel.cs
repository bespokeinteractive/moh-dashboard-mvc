using System;
using System.Collections.Generic;
using hrhdashboard.Models;
using Newtonsoft.Json.Linq;

namespace hrhdashboard.ViewModel
{
    public class CompareModel
    {
        public Facility Facility { get; set; }
        public JObject Facilities { get; set; }
        public double ScoreChecklist { get; set; }
        public double ScoreHumanResources { get; set; }
        public double ScoreInfrastructure { get; set; }
        public double ScoreOverall { get; set; }
        public int Rank1 { get; set; }
        public int Rank2 { get; set; }
		
        public CompareModel()
        {
            Facility = new Facility();
            Facilities = null;

            ScoreChecklist = 0;
            ScoreHumanResources = 0;
            ScoreInfrastructure = 0;
            ScoreOverall = 0;

            Rank1 = 0;
            Rank2 = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using hrhdashboard.Models;

namespace hrhdashboard.ViewModel
{
    public class FacilityAssessmentViewModel
    {
        public List<Facility> Facilities { get; set; }
        public List<Norms> FacilityChecks { get; set; }
        public List<Norms> HumanResources { get; set; }
        public List<Norms> Infrastructure { get; set; }
        public Facility Selected { get; set; }
        public String ActiveTab { get; set; }

        public FacilityAssessmentViewModel()
        {
            Facilities = new List<Facility>();
            FacilityChecks = new List<Norms>();
            HumanResources = new List<Norms>();
            Infrastructure = new List<Norms>();
            Selected = new Facility();
            ActiveTab = "";
        }
    }
}

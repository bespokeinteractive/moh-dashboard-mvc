using System;
using System.Collections.Generic;

using hrhdashboard.Models;

namespace hrhdashboard.ViewModel
{
    public class FacilityListViewModel
    {
        public List<Facility> Facilities { get; set; }
        public List<Norms> Norms { get; set; }   
        public Facility Selected { get; set; }
        public String Route { get; set; }


        public FacilityListViewModel()
        {
            Facilities = new List<Facility>();
            Norms = new List<Norms>();
            Selected = new Facility();
            Route = "";
        }
    }
}

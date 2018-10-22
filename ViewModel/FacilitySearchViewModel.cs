using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using hrhdashboard.Models;

namespace hrhdashboard.ViewModel
{
    public class FacilitySearchViewModel
    {
        public int count { get; set; }
        public int county { get; set; }
        public int constituency { get; set; }
        public int ward { get; set; }
        public int level { get; set; }
        public List<County> counties { get; set; }
        public List<Facility> facilities { get; set; }

        public FacilitySearchViewModel() {
            count = 0;
            county = 0;
            constituency = 0;
            ward = 0;
            level = 0;

            counties = new List<County>();
            facilities = new List<Facility>();
        }
    }
}

using System;
using hrhdashboard.Models;

namespace hrhdashboard.ViewModel
{
    public class FacilityViewModel
    {
        public Facility facility { get; set; }

        public FacilityViewModel()
        {
            facility = new Facility();
        }
    }
}

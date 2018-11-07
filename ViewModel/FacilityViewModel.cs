using System;
using hrhdashboard.Models;
using hrhdashboard.Extensions;
using System.Collections.Generic;

namespace hrhdashboard.ViewModel
{
    public class FacilityViewModel
    {
        public Facility facility { get; set; }
        public FacilityOwner owner { get; set; }
        public KmhflContactsObject contacts { get; set; }
        public List<Norms> FacilityChecks { get; set; }
        public List<Norms> HumanResources { get; set; }
        public List<Norms> Infrastructure { get; set; }

        public FacilityViewModel()
        {
            facility = new Facility();
            owner = new FacilityOwner();
            contacts = new KmhflContactsObject();
            FacilityChecks = new List<Norms>();
            HumanResources = new List<Norms>();
            Infrastructure = new List<Norms>();
        }
    }
}

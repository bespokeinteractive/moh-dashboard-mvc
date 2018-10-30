using System;
using hrhdashboard.Services;
using hrhdashboard.Extensions;

namespace hrhdashboard.Models
{
    public class Norms
    {
        public Int64 Id { get; set; }
        public Facility Facility { get; set; }
        public NormsItems Item { get; set; }
        public Int64 Norm { get; set; }
        public Int64 Value { get; set; }
        public Int64 Gaps { get; set; }
        public Int64 Female { get; set; }
        public Int64 Male { get; set; }
        public Int64 Fit { get; set; }
        public Int64 Disabled { get; set; }


        public Norms()
        {
            Id = 0;
            Norm = 0;
            Value = 0;
            Gaps = 0;
            Female = 0;
            Male = 0;
            Fit = 0;
            Disabled = 0;

            Item = new NormsItems();
            Facility = new Facility();
        }

        public Norms Save(){
            return new FacilityService().SaveNorms(this);
        }
    }
}

using System;
using hrhdashboard.Services;

namespace hrhdashboard.Models
{
    public class NormsTiers
    {
        public Int64 Id { get; set; }
        public NormsItems Item { get; set; }
        public FacilityCategory Category { get; set; }
        public int Value { get; set; }

        public NormsTiers()
        {
            Id = 0;
            Value = 0;
            Item = new NormsItems();
            Category = new FacilityCategory();
        }

        public NormsTiers(int idnt) : this() {
            Id = idnt;
        }

        public NormsTiers Save(){
            return new FacilityService().SaveNormsTiers(this);
        }
    }
}

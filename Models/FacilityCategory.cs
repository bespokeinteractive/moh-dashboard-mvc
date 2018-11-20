using System;
namespace hrhdashboard.Models
{
    public class FacilityCategory
    {
        public Int64 Id { get; set; }
        public Tiers Tier { get; set; }
        public Level Level { get; set; }
        public string Name { get; set; }

        public FacilityCategory()
        {
            Id = 0;
            Tier = new Tiers();
            Level = new Level();
            Name = "";
        }

        public FacilityCategory(Int64 idnt) : this(){
            Id = idnt;
        }
    }
}

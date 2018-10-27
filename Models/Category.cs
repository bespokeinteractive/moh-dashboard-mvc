using System;

namespace hrhdashboard.Models
{
    public class Category
    {
        public Int64 Id { get; set; }
        public String Name { get; set; }
        public Tiers Tier { get; set; }
        public Level Level { get; set; }

        public Category()
        {
            Id = 0;
            Name = "";
            Tier = new Tiers();
            Level = new Level();
        }
    }
}

using System;
namespace hrhdashboard.Models
{
    public class Tiers
    {
        public Int64 Id { get; set; }
        public String Name { get; set; }
        public Double Count { get; set; }

        public Tiers()
        {
            Id = 0;
            Name = "";
            Count = 0;
        }
    }
}

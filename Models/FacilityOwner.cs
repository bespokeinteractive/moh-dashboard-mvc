using System;
namespace hrhdashboard.Models
{
    public class FacilityOwner
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public FacilityOwner()
        {
            Id = 0;
            Type = "";
            Name = "";
            Image = "";
        }
    }
}

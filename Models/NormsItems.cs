using System;
namespace hrhdashboard.Models
{
    public class NormsItems
    {
        public Int64 Id { get; set; }
        public String Name { get; set; }
        public NormsType Type { get; set; }
        public NormsCategory Category { get; set; }

        public NormsItems()
        {
            Id = 0;
            Name = "";
            Type = new NormsType();
            Category = new NormsCategory();
        }
    }
}

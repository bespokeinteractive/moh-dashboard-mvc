using System;
namespace hrhdashboard.Models
{
    public class NormsCategory
    {
        public Int64 Id { get; set; }
        public String Name { get; set; }

        public NormsCategory()
        {
            Id = 0;
            Name = "";
        }
    }
}

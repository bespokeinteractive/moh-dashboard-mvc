using System;
namespace hrhdashboard.Models
{
    public class NormsType
    {
        public Int64 Id { get; set; }
        public String Name { get; set; }

        public NormsType()
        {
            Id = 0;
            Name = "";
        }
    }
}

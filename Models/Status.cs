using System;
namespace hrhdashboard.Models
{
    public class Status
    {
        public Int64 Id { get; set; }
        public String Name { get; set; }

        public Status()
        {
            Id = 0;
            Name = "";
        }
    }
}

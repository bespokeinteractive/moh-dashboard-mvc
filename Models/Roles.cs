using System;
namespace hrhdashboard.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public String Name { get; set; }

        public Roles()
        {
            Id = 0;
            Type = 0;
            Name = "";
        }

        public Roles(int idnt) : this() {
            Id = idnt;
        }
    }
}

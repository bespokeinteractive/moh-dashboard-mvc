using System;
namespace hrhdashboard.Models
{
    public class Facility
    {
        public Int64 Id { get; set; }
        public String GUID { get; set; }
        public String Name { get; set; }
        public String Code { get; set; }
        public String Type { get; set; }
        public String Owner { get; set; }
        public String Regulator { get; set; }

        public County County { get; set; }
        public Constituency SubCounty { get; set; }
        public Ward Ward { get; set; }
        public Status Status { get; set; }
        public Category Category { get; set; }

        public Facility()
        {
            Id = 0;
            GUID = "";
            Name = "";
            Code = "";
            Type = "";
            Owner = "";
            Regulator = "";
            County = new County();
            SubCounty = new Constituency();
            Ward = new Ward();

            Status = new Status();
            Category = new Category();
        }

        public Facility(Int64 idnt) : this()
        {
            Id = idnt;
        }
    }
}

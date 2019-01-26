using System;
using Microsoft.AspNetCore.Http;

namespace hrhdashboard.Models
{
    public class NormsCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int HumanResources { get; set; }
        public int Infrastructure { get; set; }
        public string Description { get; set; }
        public DateTime AddedOn { get; set; }
        public Users AddedBy { get; set; }

        public NormsCategory() {
            Id = 0;
            Name = "";
            HumanResources = 0;
            Infrastructure = 0;
            Description = "";
            AddedOn = DateTime.Now;
            AddedBy = new Users();
        }

        public NormsCategory Save(HttpContext context) {
            return this;
        }

    }
}

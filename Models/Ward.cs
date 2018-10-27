using System;
using hrhdashboard.Services;
using Newtonsoft.Json.Linq;

namespace hrhdashboard.Models
{
    public class Ward
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public double Zoom { get; set; }
        public string Center { get; set; }
        public string Json { get; set; }

        public Constituency Constituency { get; set; }

        public Ward()
        {
            Id = 0;
            Code = 0;
            Zoom = 0;
            Name = "";
            Center = "";
            Json = "";

            Constituency = new Constituency();
        }

        public Ward(int idnt)
        {
            Id = idnt;
            Code = 0;
            Zoom = 0;
            Name = "";
            Center = "";
            Json = "";

            Constituency = new Constituency();
        }

        public int GetFacilitiesCount() {
            return new FacilityService().GetFacilityCount(this);
        }
        
        public JObject GetMarkers(){
            return new CountyService().GetMarkers(this);
        }
    }
}

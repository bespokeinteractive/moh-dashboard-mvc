using System;
using hrhdashboard.Services;
using Newtonsoft.Json.Linq;

namespace hrhdashboard.Models
{
    public class County
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Zoom { get; set; }
        public string Center { get; set; }
        public string Json { get; set; }
        public int Facilities { get; set; }

        public County()
        {
            Id = 0;
            Zoom = 0;
            Name = "";
            Center = "";
            Json = "";

            Facilities = 0;
        }

        public County(int idnt)
        {
            Id = idnt;
            Zoom = 0;
            Name = "";
            Center = "";
            Json = "";

            Facilities = 0;
        }

        public JObject GetMarkers() {
            return new CountyService().GetMarkers(this);
        }
    }
}

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

        public County()
        {
            Id = 0;
            Zoom = 0;
            Name = "";
            Center = "";
            Json = "";
        }

        public County(int idnt) : this()
        {
            Id = idnt;
        }

        public JObject GetMarkers() {
            return new CountyService().GetMarkers(this);
        }
    }
}

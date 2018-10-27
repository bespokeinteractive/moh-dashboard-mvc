using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hrhdashboard.Models;

namespace hrhdashboard.ViewModel
{
    public class FacilitySearchViewModel
    {
        public string facility { get; set; }
        public int count { get; set; }
        public int county { get; set; }
        public int constituency { get; set; }
        public int ward { get; set; }
        public int level { get; set; }
        public List<County> counties { get; set; }
        public List<Facility> facilities { get; set; }
        public List<Level> levels { get; set; }

        public FacilitySearchViewModel() {
            facility = "";
            count = 0;
            county = 0;
            constituency = 0;
            ward = 0;
            level = 0;

            this.InitializeLevels();

            counties = new List<County>();
            facilities = new List<Facility>();
        }

        private void InitializeLevels(){
            levels = new List<Level>
            {
                new Level(1, "Level 1"),
                new Level(2, "Level 2"),
                new Level(3, "Level 3"),
                new Level(4, "Level 4"),
                new Level(5, "Level 5"),
                new Level(6, "Level 6")
            };
        }
    }
}

using System;
using System.Collections.Generic;
using hrhdashboard.Models;

namespace hrhdashboard.ViewModel
{
    public class HomeConstituencyViewModel
    {
        public Constituency constituency { get; set; }

        public List<Level> levels { get; set; }

        public HomeConstituencyViewModel()
        {
            constituency = new Constituency();
            levels = new List<Level>();
        }
    }
}

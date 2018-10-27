using System;
using hrhdashboard.Models;

namespace hrhdashboard.ViewModel
{
    public class HomeConstituencyViewModel
    {
        public Constituency constituency { get; set; }

        public HomeConstituencyViewModel()
        {
            constituency = new Constituency();
        }
    }
}

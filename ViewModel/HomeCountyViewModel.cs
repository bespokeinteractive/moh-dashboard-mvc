using System;
using System.Collections.Generic;
using hrhdashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace hrhdashboard.ViewModel
{
    public class HomeCountyViewModel
    {
        public County county { get; set; }
        public List<Tiers> tiers { get; set; }

        public HomeCountyViewModel()
        {
            county = new County();
            tiers = new List<Tiers>();
        }
    }
}

using System;
using System.Collections.Generic;
using hrhdashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace hrhdashboard.ViewModel
{

    public class HomeWardViewModel
    {
        public Ward ward { get; set; }
        public List<Level> levels { get; set; }

        public HomeWardViewModel()
        {
            ward = new Ward();
            levels = new List<Level>();
        }
    }
}

using System;
using System.Collections.Generic;
using hrhdashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace hrhdashboard.ViewModel
{

    public class HomeWardViewModel
    {
        public Ward Ward { get; set; }
        public List<Level> Levels { get; set; }

        public HomeWardViewModel()
        {
            Ward = new Ward();
            Levels = new List<Level>();
        }
    }
}

using System;
using hrhdashboard.Models;
using Newtonsoft.Json.Linq;

namespace hrhdashboard.ViewModel
{
    public class HomeIndexViewModel
    {
        public JObject Markers { get; set; }

        public HomeIndexViewModel()
        {
        }
    }
}

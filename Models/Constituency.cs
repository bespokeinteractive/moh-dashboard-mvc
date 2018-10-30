﻿using System;
using hrhdashboard.Services;
using Newtonsoft.Json.Linq;

namespace hrhdashboard.Models
{
    public class Constituency
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public double Zoom { get; set; }
        public string Center { get; set; }
        public string Json { get; set; }
        public County County { get; set; }

        public Constituency()
        {
            Id = 0;
            Code = 0;
            Zoom = 0;
            Name = "";
            Center = "";
            Json = "";
            County = new County();
        }

        public Constituency(int idnt) : this()
        {
            Id = idnt;
        }

        public JObject GetMarkers()
        {
            return new CountyService().GetMarkers(this);
        }
    }
}

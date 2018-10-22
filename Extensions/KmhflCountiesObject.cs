using System;
using System.Collections.Generic;

namespace hrhdashboard.Extensions
{
    public class Geometry
    {
        public string type { get; set; }
        public List<List<List<double>>> coordinates { get; set; }
    }

    public class Center
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Bound
    {
        public string type { get; set; }
        public List<List<List<double>>> coordinates { get; set; }
    }

    public class Properties
    {
        public Center center { get; set; }
        public Bound bound { get; set; }
        public int facility_count { get; set; }
        public string name { get; set; }
    }

    public class Feature
    {
        public int id { get; set; }
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class KmhflCountiesObject
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
    }
}

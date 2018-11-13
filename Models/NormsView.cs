using System;
namespace hrhdashboard.Models
{
    public class NormsView
    {
        public NormsItems Item { get; set; }
        public int L1Norm { get; set; }
        public int L2Norm { get; set; }
        public int L3Norm { get; set; }
        public int L4Norm { get; set; }
        public int L5Norm { get; set; }
        public int L6Norm { get; set; }

        public NormsView() {
            Item = new NormsItems();

            L1Norm = 0;
            L2Norm = 0;
            L3Norm = 0;
            L4Norm = 0;
            L5Norm = 0;
            L6Norm = 0;
        }
    }
}

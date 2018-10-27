using System;


using hrhdashboard.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Filters;

namespace hrhdashboard.Models
{
    public class Norms
    {
        public Int64 Id { get; set; }
        public Facility Facility { get; set; }
        public NormsItems Item { get; set; }
        public Int64 Norm { get; set; }
        public Int64 Value { get; set; }
        public Int64 Gaps { get; set; }
        public Int64 Female { get; set; }
        public Int64 Male { get; set; }
        public Int64 Fit { get; set; }
        public Int64 Disabled { get; set; }

    
        public Norms()
        {
            Id = 0;
            Norm = 0;
            Value = 0;
            Gaps = 0;
            Female = 0;
            Male = 0;
            Fit = 0;
            Disabled = 0;



           Item = new NormsItems();
            Facility = new Facility();
        }

        

        public Norms Save(){
            SqlServerConnection conn = new SqlServerConnection();
            Id = conn.SqlServerUpdate("DECLARE @fac INT=" + Facility.Id + " , @norm INT=" + Item.Id + ", @val INT=" + Value + "; IF NOT EXISTS (SELECT nr_idnt FROM Norms WHERE nr_facility=@fac AND nr_norm=@norm) BEGIN INSERT INTO Norms(nr_facility, nr_norm, nr_available) output INSERTED.nr_idnt VALUES (@fac, @norm, @val) END ELSE BEGIN UPDATE Norms SET nr_available=@val output INSERTED.nr_idnt WHERE nr_facility=@fac AND nr_norm=@norm END");

            return this;
        }
        public Norms SaveHumanResource()
        {
            SqlServerConnection conn = new SqlServerConnection();
            Id = conn.SqlServerUpdate("DECLARE @fac INT=" + Facility.Id + " , @norm INT=" + Item.Id + ", @val INT=" + Value + ", @fem INT=" + Female + " , @mal INT=" + Male + ",@fit INT=" + Fit + ", @dis INT=" + Disabled + "; IF NOT EXISTS (SELECT nr_idnt FROM Norms WHERE nr_facility=@fac AND nr_norm=@norm) BEGIN INSERT INTO Norms(nr_facility, nr_norm, nr_available, nr_female, nr_male, nr_fit, nr_disabled) output INSERTED.nr_idnt VALUES (@fac, @norm, @val, @fem, @mal, @fit, @dis) END ELSE BEGIN UPDATE Norms SET nr_available=@val , nr_female=@fem, nr_male=@mal, nr_fit=@fit, nr_disabled=@dis output INSERTED.nr_idnt WHERE nr_facility=@fac AND nr_norm=@norm END");
            return this;
        }
    }
}

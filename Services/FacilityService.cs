using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using hrhdashboard.Models;
using hrhdashboard.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;

namespace hrhdashboard.Services
{
    [Authorize]
    public class FacilityService
    {
        public Facility GetFacility(String code) {
            Facility facility = new Facility();

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT fc_idnt, fc_name, fc_kmflcode, fc_type, fc_owner, fc_regulator, ct_idnt, ct_name, cn_idnt, cn_name, wd_idnt, wd_name, fs_idnt, fs_status, fctg_idnt, fctg_name, ft_idnt, ft_tier, fl_idnt, fl_level, fc_guid FROM Facility INNER JOIN FacilityCategory ON fc_catg=fctg_idnt INNER JOIN FacilityTier ON fctg_tier=ft_idnt INNER JOIN Levels ON fctg_level=fl_idnt INNER JOIN County ON ct_idnt=fc_county INNER JOIN Constituency ON cn_idnt=fc_subcounty INNER JOIN Wards ON wd_idnt=fc_ward INNER JOIN FacilityStatus ON fc_status=fs_idnt WHERE fc_kmflcode='" + code + "' ORDER BY fc_name");
            if (dr.Read())
            {
                facility.Id = Convert.ToInt64(dr[0]);
                facility.Name = dr[1].ToString();
                facility.Code = code;
                facility.Type = dr[3].ToString();
                facility.Owner = dr[4].ToString();
                facility.Regulator = dr[5].ToString();

                facility.County.Id = Convert.ToInt16(dr[6]);
                facility.County.Name = dr[7].ToString();

                facility.SubCounty.Id = Convert.ToInt16(dr[8]);
                facility.SubCounty.Name = dr[9].ToString();

                facility.Ward.Id = Convert.ToInt16(dr[10]);
                facility.Ward.Name = dr[11].ToString();

                facility.Status.Id = Convert.ToInt64(dr[12]);
                facility.Status.Name = dr[13].ToString();

                facility.Category.Id = Convert.ToInt64(dr[14]);
                facility.Category.Name = dr[15].ToString();

                facility.Category.Tier.Id = Convert.ToInt64(dr[16]);
                facility.Category.Tier.Name = dr[17].ToString();

                facility.Category.Level.Id = Convert.ToInt16(dr[18]);
                facility.Category.Level.Name = dr[19].ToString();

                facility.GUID = dr[20].ToString();
            }

            return facility;
        }

        public Facility GetFacility(Int64 Id)
        {
            Facility facility = new Facility();

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT fc_idnt, fc_name, fc_kmflcode, fc_type, fc_owner, fc_regulator, ct_idnt, ct_name, fc_type, cn_idnt, cn_name, wd_idnt, wd_name, fs_idnt, fs_status, fctg_idnt, fctg_name, ft_idnt, ft_tier, fl_idnt, fl_level, fc_guid FROM Facility INNER JOIN FacilityCategory ON fc_catg=fctg_idnt INNER JOIN Levels ON fctg_level=fl_idnt INNER JOIN FacilityTier ON fctg_tier=ft_idnt INNER JOIN County ON ct_idnt=fc_county INNER JOIN Constituency ON cn_idnt=fc_subcounty INNER JOIN Wards ON wd_idnt=fc_ward INNER JOIN FacilityStatus ON fc_status=fs_idnt WHERE fc_idnt=" + Id + " ORDER BY fc_name");
            if (dr.Read())
            {
                facility.Id = Id;
                facility.Name = dr[1].ToString();
                facility.Code = dr[2].ToString();
                facility.Type = dr[3].ToString();
                facility.Owner = dr[4].ToString();
                facility.Regulator = dr[5].ToString();

                facility.County.Id = Convert.ToInt16(dr[6]);
                facility.County.Name = dr[7].ToString();

                facility.SubCounty.Id = Convert.ToInt16(dr[8]);
                facility.SubCounty.Name = dr[9].ToString();

                facility.Ward.Id = Convert.ToInt16(dr[10]);
                facility.Ward.Name = dr[11].ToString();

                facility.Status.Id = Convert.ToInt64(dr[12]);
                facility.Status.Name = dr[13].ToString();

                facility.Category.Id = Convert.ToInt64(dr[14]);
                facility.Category.Name = dr[15].ToString();

                facility.Category.Tier.Id = Convert.ToInt64(dr[16]);
                facility.Category.Tier.Name = dr[17].ToString();

                facility.Category.Level.Id = Convert.ToInt16(dr[18]);
                facility.Category.Level.Name = dr[19].ToString();

                facility.GUID = dr[20].ToString();
            }

            return facility;
        }

        public List<Facility> GetFacilities(string query) {
            List<Facility> facilities = new List<Facility>();

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT fc_idnt, fc_name, fc_kmflcode, fc_type, fc_owner, fc_regulator, ct_idnt, ct_name, cn_idnt, cn_name, wd_idnt, wd_name, fs_idnt, fs_status, fctg_idnt, fctg_name, ft_idnt, ft_tier, fl_idnt, fl_level, fc_guid FROM Facility INNER JOIN FacilityCategory ON fc_catg=fctg_idnt INNER JOIN Levels ON fctg_level=fl_idnt INNER JOIN FacilityTier ON fctg_tier=ft_idnt INNER JOIN County ON ct_idnt=fc_county INNER JOIN Constituency ON cn_idnt=fc_subcounty INNER JOIN Wards ON wd_idnt=fc_ward INNER JOIN FacilityStatus ON fc_status=fs_idnt " + query + " ORDER BY fc_kmflcode, fc_level");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Facility facility = new Facility();
                    facility.Id = Convert.ToInt64(dr[0]);
                    facility.Name = dr[1].ToString();
                    facility.Code = dr[2].ToString();
                    facility.Type = dr[3].ToString();
                    facility.Owner = dr[4].ToString();
                    facility.Regulator = dr[5].ToString();

                    facility.County.Id = Convert.ToInt16(dr[6]);
                    facility.County.Name = dr[7].ToString();

                    facility.SubCounty.Id = Convert.ToInt16(dr[8]);
                    facility.SubCounty.Name = dr[9].ToString();

                    facility.Ward.Id = Convert.ToInt16(dr[10]);
                    facility.Ward.Name = dr[11].ToString();

                    facility.Status.Id = Convert.ToInt64(dr[12]);
                    facility.Status.Name = dr[13].ToString();

                    facility.Category.Id = Convert.ToInt64(dr[14]);
                    facility.Category.Name = dr[15].ToString();

                    facility.Category.Tier.Id = Convert.ToInt64(dr[16]);
                    facility.Category.Tier.Name = dr[17].ToString();

                    facility.Category.Level.Id = Convert.ToInt16(dr[18]);
                    facility.Category.Level.Name = dr[19].ToString();

                    facility.GUID = dr[20].ToString();

                    facilities.Add(facility);
                }
            }

            return facilities;
        }

        public List<Facility> GetFacilitiesByUserLoggedIn() {
            return GetFacilitiesByUser(1);
        }

        public List<Facility> GetFacilitiesByUser(Int64 UserId) {
            List<Facility> facilities = new List<Facility>();

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT fc_idnt, fc_name, fc_kmflcode, fc_type, fc_owner, fc_regulator, ct_idnt, ct_name, cn_idnt, cn_name, wd_idnt, wd_name, fs_idnt, fs_status, fctg_idnt, fctg_name, ft_idnt, ft_tier, fl_idnt, fl_level, fc_guid FROM UsersFacility INNER JOIN Facility ON fc_idnt=uf_fac INNER JOIN FacilityCategory ON fc_catg=fctg_idnt INNER JOIN Levels ON fctg_level=fl_idnt INNER JOIN FacilityTier ON fctg_tier=ft_idnt INNER JOIN County ON ct_idnt=fc_county INNER JOIN Constituency ON cn_idnt=fc_subcounty INNER JOIN Wards ON wd_idnt=fc_ward INNER JOIN FacilityStatus ON fc_status=fs_idnt WHERE uf_user=" + UserId + " ORDER BY fc_name");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Facility facility = new Facility();
                    facility.Id = Convert.ToInt64(dr[0]);
                    facility.Name = dr[1].ToString();
                    facility.Code = dr[2].ToString();
                    facility.Type = dr[3].ToString();
                    facility.Owner = dr[4].ToString();
                    facility.Regulator = dr[5].ToString();

                    facility.County.Id = Convert.ToInt16(dr[6]);
                    facility.County.Name = dr[7].ToString();

                    facility.SubCounty.Id = Convert.ToInt16(dr[8]);
                    facility.SubCounty.Name = dr[9].ToString();

                    facility.Ward.Id = Convert.ToInt16(dr[10]);
                    facility.Ward.Name = dr[11].ToString();

                    facility.Status.Id = Convert.ToInt64(dr[12]);
                    facility.Status.Name = dr[13].ToString();

                    facility.Category.Id = Convert.ToInt64(dr[14]);
                    facility.Category.Name = dr[15].ToString();

                    facility.Category.Tier.Id = Convert.ToInt64(dr[16]);
                    facility.Category.Tier.Name = dr[17].ToString();

                    facility.Category.Level.Id = Convert.ToInt16(dr[18]);
                    facility.Category.Level.Name = dr[19].ToString();

                    facility.GUID = dr[20].ToString();

                    facilities.Add(facility);
                }
            }

            return facilities;
        }

        public JObject GetFacilitiesAutocomplete(string query = "") {
            string facilities = "{}";

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT fc_kmflcode+' '+fc_name facility, fo_image FROM Facility INNER JOIN facilityOwner ON fc_owner=fo_name " + query + " ORDER BY fc_kmflcode");
            if (dr.HasRows) {
                facilities = "{";

                while (dr.Read()) {
                    facilities += "'" + dr[0].ToString().Replace("'", "`").Replace(":", "") + "': '../../images/logo/" + dr[1].ToString() + "', ";
                }

                facilities += "}";
            }

            return JObject.Parse(facilities);
        }

        public FacilityOwner GetFacilityOwner(Facility facility) {
            FacilityOwner owner = new FacilityOwner();

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT fo_idnt, fo_type, fo_name, fo_image FROM facilityOwner WHERE fo_name='" + facility.Owner + "'");
            if (dr.Read())
            {
                owner = new FacilityOwner
                {
                    Id = Convert.ToInt16(dr[0]),
                    Type = dr[1].ToString(),
                    Name = dr[2].ToString(),
                    Image = dr[3].ToString()
                };
            }

            return owner;
        }

        public List<Level> GetFacilityCategorizationByLevels(County county) {
            List<Level> levels = new List<Level>();

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT fl_idnt, ISNULL(fc_count,0) fl_count FROM Levels LEFT OUTER JOIN (SELECT fc_level, COUNT(*) fc_count FROM Facility WHERE fc_level<>99 AND fc_county=" + county.Id + " GROUP BY fc_level) AS Foo ON fc_level=fl_idnt WHERE fl_idnt<>99 ORDER BY fl_idnt");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Level lvls = new Level {
                        Id = Convert.ToInt16(dr[0]),
                        Name = "Level " + dr[0],
                        Count = Convert.ToDouble(dr[1])
                    };

                    levels.Add(lvls);
                }
            }

            return levels;
        }

        public List<Level> GetFacilityCategorizationByLevels(Constituency constituency)
        {
            List<Level> levels = new List<Level>();

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT fl_idnt, ISNULL(fc_count,0) fl_count FROM Levels LEFT OUTER JOIN (SELECT fc_level, COUNT(*) fc_count FROM Facility WHERE fc_level<>99 AND fc_subcounty=" + constituency.Id + " GROUP BY fc_level) AS Foo ON fc_level=fl_idnt WHERE fl_idnt<>99 ORDER BY fl_idnt");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Level lvls = new Level
                    {
                        Id = Convert.ToInt16(dr[0]),
                        Name = "Level " + dr[0],
                        Count = Convert.ToDouble(dr[1])
                    };

                    levels.Add(lvls);
                }
            }

            return levels;
        }

        public List<Level> GetFacilityCategorizationByLevels(Ward ward)
        {
            List<Level> levels = new List<Level>();

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT fl_idnt, ISNULL(fc_count,0) fl_count FROM Levels LEFT OUTER JOIN (SELECT fc_level, COUNT(*) fc_count FROM Facility WHERE fc_level<>99 AND fc_ward=" + ward.Id + " GROUP BY fc_level) AS Foo ON fc_level=fl_idnt WHERE fl_idnt<>99 ORDER BY fl_idnt");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Level lvls = new Level
                    {
                        Id = Convert.ToInt16(dr[0]),
                        Name = "Level " + dr[0],
                        Count = Convert.ToDouble(dr[1])
                    };

                    levels.Add(lvls);
                }
            }

            return levels;
        }

        public List<Tiers> GetFacilityCategorizationByTiers(County county) {
            List<Tiers> tiers = new List<Tiers>();

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT ft_idnt, ft_tier, ISNULL(fctg_count,0) ft_count FROM FacilityTier LEFT OUTER JOIN (SELECT fctg_tier, COUNT(*) fctg_count FROM Facility INNER JOIN FacilityCategory ON fc_catg=fctg_idnt WHERE fc_county=" + county.Id + " GROUP BY fctg_tier) As foo on fctg_tier=ft_idnt");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Tiers tier = new Tiers {
                        Id = Convert.ToInt64(dr[0]),
                        Name = dr[1].ToString(),
                        Count = Convert.ToDouble(dr[2])
                    };

                    tiers.Add(tier);
                }
            }

            return tiers;
        }

        public List<Norms> GetNorms(Facility facility, Int64 type, Boolean includeZeros = false, Boolean filterServices = false) {
            List<Norms> norms = new List<Norms>();

            string AdditionalQuery = " AND NOT (nt_norm=0 AND NULLIF(nr_available,0) IS NULL)";
            string ServicesQuery = "";

            if (includeZeros)
                AdditionalQuery = "";
            if (filterServices)
                ServicesQuery = "AND nc_idnt IN (SELECT ns_category FROM NormsServices WHERE ns_level=" + facility.Category.Level.Id + ")";

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT nc_idnt, nc_category, ni_idnt, ni_item, nt_norm, ISNULL(nr_available,0) nt_avail, ISNULL(nr_female,0) nt_female, ISNULL(nr_male,0)_nt_male, ISNULL(nr_disabled,0) nt_disabled FROM NormsTiers INNER JOIN NormsItems ON nt_item=ni_idnt AND ni_type=" + type + " INNER JOIN NormsCategory ON ni_catg=nc_idnt " + ServicesQuery + " LEFT OUTER JOIN Norms ON nt_item=nr_norm AND nr_facility=" + facility.Id + " WHERE nt_tctg=" + facility.Category.Id + AdditionalQuery + " ORDER BY ni_catg, nt_item");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Norms norm = new Norms();
                    norm.Item.Category.Id = Convert.ToInt64(dr[0]);
                    norm.Item.Category.Name = dr[1].ToString();
                    norm.Item.Id = Convert.ToInt64(dr[2]);
                    norm.Item.Name = dr[3].ToString();

                    norm.Norm = Convert.ToInt64(dr[4]);
                    norm.Value = Convert.ToInt64(dr[5]);

                    norm.Female = Convert.ToInt64(dr[6]);
                    norm.Male = Convert.ToInt64(dr[7]);
                    norm.Disabled = Convert.ToInt64(dr[8]);

                    if (norm.Value > norm.Norm) {
                        norm.Gaps = 0;
                    }
                    else {
                        norm.Gaps = norm.Norm - norm.Value;
                    }

                    norms.Add(norm);
                }
            }

            return norms;
        }

        public List<NormsView> GetNormsViews(NormsType type) {
            List<NormsView> views = new List<NormsView>();

            string AdditionalQuery = "";
            if (type.Id > 0) {
                AdditionalQuery = "WHERE ni_type=" + type.Id;
            }

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT ni_idnt, ni_item, ni_catg, ni_category, ni_type, ni_types, L1, L2, L3, L4, L5, L6 FROM vNormsLevels " + AdditionalQuery + " ORDER BY ni_type, ni_catg, ni_idnt");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    NormsView view = new NormsView();
                    view.Item.Id = Convert.ToInt16(dr[0]);
                    view.Item.Name = dr[1].ToString();
                    view.Item.Category.Id = Convert.ToInt16(dr[2]);
                    view.Item.Category.Name = dr[3].ToString();
                    view.Item.Type.Id = Convert.ToInt16(dr[4]);
                    view.Item.Type.Name = dr[5].ToString();

                    view.L1Norm = Convert.ToInt16(dr[6]);
                    view.L2Norm = Convert.ToInt16(dr[7]);
                    view.L3Norm = Convert.ToInt16(dr[8]);
                    view.L4Norm = Convert.ToInt16(dr[9]);
                    view.L5Norm = Convert.ToInt16(dr[10]);
                    view.L6Norm = Convert.ToInt16(dr[11]);

                    views.Add(view);
                }
            }

            return views;
        }

        public NormsView GetNormsViewsItem(int idnt) {
            NormsView view = null;

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT ni_idnt, ni_item, ni_catg, ni_category, ni_type, ni_types, L1, L2, L3, L4, L5, L6 FROM vNormsLevels WHERE ni_idnt=" + idnt);
            if (dr.Read()){
                view = new NormsView();

                view.Item.Id = Convert.ToInt16(dr[0]);
                view.Item.Name = dr[1].ToString();
                view.Item.Category.Id = Convert.ToInt16(dr[2]);
                view.Item.Category.Name = dr[3].ToString();
                view.Item.Type.Id = Convert.ToInt16(dr[4]);
                view.Item.Type.Name = dr[5].ToString();
                view.L1Norm = Convert.ToInt16(dr[6]);
                view.L2Norm = Convert.ToInt16(dr[7]);
                view.L3Norm = Convert.ToInt16(dr[8]);
                view.L4Norm = Convert.ToInt16(dr[9]);
                view.L5Norm = Convert.ToInt16(dr[10]);
                view.L6Norm = Convert.ToInt16(dr[11]);
            }

            return view;
        }


        /*DataWriters*/
        public Norms SaveNorms(Norms norm) {
            SqlServerConnection conn = new SqlServerConnection();
            norm.Id = conn.SqlServerUpdate("DECLARE @fac INT=" + norm.Facility.Id + " , @norm INT=" + norm.Item.Id + ", @val INT=" + norm.Value + ", @fem INT=" + norm.Female + ", @mal INT=" + norm.Male + ", @dis INT=" + norm.Disabled + "; IF NOT EXISTS (SELECT nr_idnt FROM Norms WHERE nr_facility=@fac AND nr_norm=@norm) BEGIN INSERT INTO Norms(nr_facility, nr_norm, nr_available, nr_female, nr_male, nr_disabled) output INSERTED.nr_idnt VALUES (@fac, @norm, @val, @fem, @mal, @dis) END ELSE BEGIN UPDATE Norms SET nr_available=@val, nr_female=@fem, nr_male=@mal, nr_disabled=@dis output INSERTED.nr_idnt WHERE nr_facility=@fac AND nr_norm=@norm END");

            return norm;
        }

        public List<SelectListItem> GetNormsTypesIEnumerable()
        {
            List<SelectListItem> types = new List<SelectListItem>();

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT ntp_idnt, ntp_type FROM NormsTypes");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    SelectListItem type = new SelectListItem();
                    type.Value = dr[0].ToString();
                    type.Text = dr[1].ToString();

                    types.Add(type);
                }
            }

            return types;
        }

        public List<SelectListItem> GetNormsCategoryIEnumerable()
        {
            List<SelectListItem> categories = new List<SelectListItem>();
            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("select nc_idnt, nc_category from NormsCategory");

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    SelectListItem category = new SelectListItem();
                    category.Value = dr[0].ToString();
                    category.Text = dr[1].ToString();

                    categories.Add(category);
                }
            }
            return categories;
        }
        
        public NormsView SaveNormItems(NormsView view) {
            SqlServerConnection conn = new SqlServerConnection();
            view.Item.Id = conn.SqlServerUpdate("DECLARE @idnt INT=" + view.Item.Id + ", @type INT=" + view.Item.Type.Id + ", @catg INT= " + view.Item.Category.Id + " , @name NVARCHAR(100)='" + view.Item.Name + "'; IF NOT EXISTS(SELECT ni_idnt FROM NormsItems WHERE ni_idnt=@idnt) BEGIN INSERT INTO NormsItems(ni_type, ni_catg, ni_item) output INSERTED.ni_idnt VALUES (@type, @catg, @name) END ELSE BEGIN UPDATE NormsItems SET ni_type=@type, ni_catg=@catg, ni_item=@name output INSERTED.ni_idnt WHERE ni_idnt=@idnt END");
           
            conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT fctg_idnt, fctg_level FROM FacilityCategory");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    NormsTiers tier = new NormsTiers();
                    tier.Item = new NormsItems(view.Item.Id);
                    tier.Category = new FacilityCategory(Convert.ToInt64(dr[0]));

                    if (Convert.ToInt64(dr[1]) == 1)
                        tier.Value = view.L1Norm;
                    else if (Convert.ToInt64(dr[1]) == 2)
                        tier.Value = view.L2Norm;
                    else if (Convert.ToInt64(dr[1]) == 3)
                        tier.Value = view.L3Norm;
                    else if (Convert.ToInt64(dr[1]) == 4)
                        tier.Value = view.L4Norm;
                    else if (Convert.ToInt64(dr[1]) == 5)
                        tier.Value = view.L5Norm;
                    else if (Convert.ToInt64(dr[1]) == 6)
                        tier.Value = view.L6Norm;

                    tier.Save();
                }
            }

            return view;
        }

        public NormsTiers SaveNormsTiers(NormsTiers tier){
            SqlServerConnection conn = new SqlServerConnection();
            tier.Id = conn.SqlServerUpdate("DECLARE @item INT=" + tier.Item.Id + ", @catg INT= " + tier.Category.Id + " , @value INT=" + tier.Value + "; IF NOT EXISTS(SELECT nt_idnt FROM NormsTiers WHERE nt_item=@item AND nt_tctg=@catg) BEGIN INSERT INTO NormsTiers(nt_item, nt_tctg, nt_norm) output INSERTED.nt_idnt VALUES (@item, @catg, @value) END ELSE BEGIN UPDATE NormsTiers SET nt_item=@item, nt_tctg=@catg, nt_norm=@value output INSERTED.nt_idnt WHERE nt_item=@item AND nt_tctg=@catg END");

            return tier;
        }

      

    }
}

using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using hrhdashboard.Models;
using hrhdashboard.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace hrhdashboard.Services
{
    [Authorize]
    public class FacilityService
    {
        public Facility GetFacility(String code) {
            Facility facility = new Facility();

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT fc_idnt, fc_name, fc_kmflcode, ct_idnt, ct_name, cn_idnt, cn_name, wd_idnt, wd_name, fs_idnt, fs_status, fctg_idnt, fctg_name, ft_idnt, ft_tier, fl_idnt, fl_level FROM Facility INNER JOIN FacilityCategory ON fc_catg=fctg_idnt INNER JOIN FacilityTier ON fctg_tier=ft_idnt INNER JOIN Levels ON fctg_level=fl_idnt INNER JOIN County ON ct_idnt=fc_county INNER JOIN Constituency ON cn_idnt=fc_subcounty INNER JOIN Wards ON wd_idnt=fc_ward INNER JOIN FacilityStatus ON fc_status=fs_idnt WHERE fc_kmflcode='" + code +"' ORDER BY fc_name");
            if (dr.Read())
            {
                facility.Id = Convert.ToInt64(dr[0]);
                facility.Name = dr[1].ToString();
                facility.Code = code;

                facility.County.Id = Convert.ToInt16(dr[3]);
                facility.County.Name = dr[4].ToString();

                facility.SubCounty.Id = Convert.ToInt16(dr[5]);
                facility.SubCounty.Name = dr[6].ToString();

                facility.Ward.Id = Convert.ToInt16(dr[7]);
                facility.Ward.Name = dr[8].ToString();

                facility.Status.Id = Convert.ToInt64(dr[9]);
                facility.Status.Name = dr[10].ToString();

                facility.Category.Id = Convert.ToInt64(dr[11]);
                facility.Category.Name = dr[12].ToString();

                facility.Category.Tier.Id = Convert.ToInt64(dr[13]);
                facility.Category.Tier.Name = dr[14].ToString();

                facility.Category.Level.Id = Convert.ToInt16(dr[15]);
                facility.Category.Level.Name = dr[16].ToString();
            }

            return facility;
        }

        public Facility GetFacility(Int64 Id)
        {
            Facility facility = new Facility();

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT fc_idnt, fc_name, fc_kmflcode, ct_idnt, ct_name, cn_idnt, cn_name, wd_idnt, wd_name, fs_idnt, fs_status, fctg_idnt, fctg_name, ft_idnt, ft_tier, fl_idnt, fl_level FROM Facility INNER JOIN FacilityCategory ON fc_catg=fctg_idnt INNER JOIN Levels ON fctg_level=fl_idnt INNER JOIN FacilityTier ON fctg_tier=ft_idnt INNER JOIN County ON ct_idnt=fc_county INNER JOIN Constituency ON cn_idnt=fc_subcounty INNER JOIN Wards ON wd_idnt=fc_ward INNER JOIN FacilityStatus ON fc_status=fs_idnt WHERE fc_idnt=" + Id + " ORDER BY fc_name");
            if (dr.Read())
            {
                facility.Id = Id;
                facility.Name = dr[1].ToString();
                facility.Code = dr[2].ToString();

                facility.County.Id = Convert.ToInt16(dr[3]);
                facility.County.Name = dr[4].ToString();

                facility.SubCounty.Id = Convert.ToInt16(dr[5]);
                facility.SubCounty.Name = dr[6].ToString();

                facility.Ward.Id = Convert.ToInt16(dr[7]);
                facility.Ward.Name = dr[8].ToString();

                facility.Status.Id = Convert.ToInt64(dr[9]);
                facility.Status.Name = dr[10].ToString();

                facility.Category.Id = Convert.ToInt64(dr[11]);
                facility.Category.Name = dr[12].ToString();

                facility.Category.Tier.Id = Convert.ToInt64(dr[13]);
                facility.Category.Tier.Name = dr[14].ToString();

                facility.Category.Level.Id = Convert.ToInt16(dr[15]);
                facility.Category.Level.Name = dr[16].ToString();
            }

            return facility;
        }
        
        public List<Facility> GetFacilitiesByUserLoggedIn(){
            return GetFacilitiesByUser(1);
        }

        public List<Facility> GetFacilitiesByUser(Int64 UserId){
            List<Facility> facilities = new List<Facility>();

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT fc_idnt, fc_name, fc_kmflcode, ct_idnt, ct_name, cn_idnt, cn_name, wd_idnt, wd_name, fs_idnt, fs_status, fctg_idnt, fctg_name, ft_idnt, ft_tier, fl_idnt, fl_level FROM UsersFacility INNER JOIN Facility ON fc_idnt=uf_fac INNER JOIN FacilityCategory ON fc_catg=fctg_idnt INNER JOIN Levels ON fctg_level=fl_idnt INNER JOIN FacilityTier ON fctg_tier=ft_idnt INNER JOIN County ON ct_idnt=fc_county INNER JOIN Constituency ON cn_idnt=fc_subcounty INNER JOIN Wards ON wd_idnt=fc_ward INNER JOIN FacilityStatus ON fc_status=fs_idnt WHERE uf_user=" + UserId + " ORDER BY fc_name");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Facility facility = new Facility();
                    facility.Id = Convert.ToInt64(dr[0]);
                    facility.Name = dr[1].ToString();
                    facility.Code = dr[2].ToString();

                    facility.County.Id = Convert.ToInt16(dr[3]);
                    facility.County.Name = dr[4].ToString();

                    facility.SubCounty.Id = Convert.ToInt16(dr[5]);
                    facility.SubCounty.Name = dr[6].ToString();

                    facility.Ward.Id = Convert.ToInt16(dr[7]);
                    facility.Ward.Name = dr[8].ToString();

                    facility.Status.Id = Convert.ToInt64(dr[9]);
                    facility.Status.Name = dr[10].ToString();

                    facility.Category.Id = Convert.ToInt64(dr[11]);
                    facility.Category.Name = dr[12].ToString();

                    facility.Category.Tier.Id = Convert.ToInt64(dr[13]);
                    facility.Category.Tier.Name = dr[14].ToString();

                    facility.Category.Level.Id = Convert.ToInt16(dr[15]);
                    facility.Category.Level.Name = dr[16].ToString();

                    facilities.Add(facility);
                }
            }

            return facilities;
        }

        public int GetFacilityCount(County county)
        {
            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT COUNT(*) fctg_count FROM Facility WHERE fc_county=" + county.Id);
            if (dr.Read())
                return Convert.ToInt16(dr[0]);
            return 0;
        }

        public int GetFacilityCount(Constituency constituency)
        {
            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT COUNT(*) fctg_count FROM Facility WHERE fc_subcounty=" + constituency.Id);
            if (dr.Read())
                return Convert.ToInt16(dr[0]);
            return 0;
        }

        public int GetFacilityCount(Ward ward)
        {
            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT COUNT(*) fctg_count FROM Facility WHERE fc_ward=" + ward.Id);
            if (dr.Read())
                return Convert.ToInt16(dr[0]);
            return 0;
        }

        public List<Tiers> GetFacilityCategorizationByTiers(County county){
            List<Tiers> tiers = new List<Tiers>();

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT ft_idnt, ft_tier, ISNULL(fctg_count,0) ft_count FROM FacilityTier LEFT OUTER JOIN (SELECT fctg_tier, COUNT(*) fctg_count FROM Facility INNER JOIN FacilityCategory ON fc_catg=fctg_idnt WHERE fc_county=" + county.Id + " GROUP BY fctg_tier) As foo on fctg_tier=ft_idnt");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Tiers tier = new Tiers();
                    tier.Id = Convert.ToInt64(dr[0]);
                    tier.Name = dr[1].ToString();
                    tier.Count = Convert.ToDouble(dr[2]);

                    tiers.Add(tier);
                }
            }

            return tiers;
        }

        public List<Norms> GetNorms(Facility facility, Int64 type, Boolean includeZeros = false){
            List<Norms> norms = new List<Norms>();

            string AdditionalQuery = " AND NOT (nt_norm=0 AND nr_available IS NULL)";
            if (includeZeros)
                AdditionalQuery = "";

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT nc_idnt, nc_category, ni_idnt, ni_item, nt_norm, ISNULL(nr_available,0) nt_avail FROM NormsTiers INNER JOIN NormsItems ON nt_item=ni_idnt AND ni_type=" + type + " INNER JOIN NormsCategory ON ni_catg=nc_idnt LEFT OUTER JOIN Norms ON nt_item=nr_norm AND nr_facility=" + facility.Id + " WHERE nt_tctg=" + facility.Category.Id + AdditionalQuery + " ORDER BY ni_catg, nt_item");
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

                    if (norm.Value > norm.Norm){
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
    }
}

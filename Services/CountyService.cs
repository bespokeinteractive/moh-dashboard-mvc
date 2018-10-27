using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using hrhdashboard.Models;
using hrhdashboard.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;

namespace hrhdashboard.Services
{
    [Authorize]
    public class CountyService
    {
        public County GetCounty(int idnt)
        {
            County county = new County(idnt);

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT ct_name, ct_zoom, ct_center, ct_geojson FROM County WHERE ct_idnt=" + idnt);
            if (dr.Read())
            {
                county.Name = dr[0].ToString();
                county.Zoom = Convert.ToDouble(dr[1]);
                county.Center = dr[2].ToString();
                county.Json = dr[3].ToString();
            }

            return county;
        }

        public List<County> GetCounties(){
            List<County> counties = new List<County>();

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT ct_idnt, ct_name FROM County");
            if (dr.HasRows){
                while (dr.Read())
                {
                    County county = new County
                    {
                        Id = Convert.ToInt16(dr[0]),
                        Name = dr[1].ToString()
                    };

                    counties.Add(county);
                }
            }

            return counties;
        }

        public Constituency GetConstituency(int idnt)
        {
            Constituency constitiency = new Constituency(idnt);

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT cn_code, cn_name, cn_geojson, cn_center, cn_zoom, ct_idnt, ct_name FROM Constituency INNER JOIN County ON cn_county=ct_idnt WHERE cn_idnt=" + idnt);
            if (dr.Read())
            {
                constitiency.Code = Convert.ToInt16(dr[0]);
                constitiency.Name = dr[1].ToString();
                constitiency.Json = dr[2].ToString();
                constitiency.Center = dr[3].ToString();
                constitiency.Zoom = Convert.ToDouble(dr[4]);
                constitiency.County.Id = Convert.ToInt16(dr[5]);
                constitiency.County.Name = dr[6].ToString();
            }

            return constitiency;
        }

        public Ward GetWard(int idnt){
            Ward ward = new Ward(idnt);

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT wd_code, wd_name, wd_geojson, wd_center, wd_zoom, cn_idnt, cn_name, ct_idnt, ct_name FROM Wards INNER JOIN Constituency ON wd_constituency=cn_idnt INNER JOIN County ON cn_county=ct_idnt WHERE wd_idnt=" + idnt);
            if (dr.Read())
            {
                ward.Code = Convert.ToInt16(dr[0]);
                ward.Name = dr[1].ToString();
                ward.Json = dr[2].ToString();
                ward.Center = dr[3].ToString();
                ward.Zoom = Convert.ToDouble(dr[4]);

                ward.Constituency.Id = Convert.ToInt16(dr[5]);
                ward.Constituency.Name = dr[6].ToString();
                ward.Constituency.County.Id = Convert.ToInt16(dr[7]);
                ward.Constituency.County.Name = dr[8].ToString();
            }

            return ward;
        }

        public JObject GetMarkers(){
            string markers = "{}";

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT ct_center, ct_idnt, ct_name FROM County WHERE ct_center<>''");
            if (dr.HasRows)
            {
                markers = "{type: 'FeatureCollection',features:[";

                while (dr.Read())
                {
                    markers += "{type:'Feature',geometry:{type:'Point',coordinates:" + dr[0] + "},properties:{id:" + Convert.ToInt16(dr[1]) + ",title: 'County',description:'" + dr[2] + "'}},";
                }

                markers += "]}";
            }

            return JObject.Parse(markers);
        }

        public JObject GetMarkers(County County){
            string markers = "{}";

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT cn_center, cn_idnt, cn_name FROM Constituency WHERE cn_center <> N'[0,0]' AND cn_county=" + County.Id);
            if (dr.HasRows)
            {
                markers = "{type: 'FeatureCollection',features:[";

                while (dr.Read())
                {
                    markers += "{type:'Feature',geometry:{type:'Point',coordinates:" + dr[0].ToString() + "},properties:{id:" + Convert.ToInt16(dr[1]) + ",title: 'Facility',description:'" + dr[2].ToString() + "'}},";
                }

                markers += "]}";
            }

            return JObject.Parse(markers);
        }

        public JObject GetMarkers(Constituency Constituency)
        {
            string markers = "{}";

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT wd_center, wd_idnt, wd_name FROM Wards WHERE wd_constituency=" + Constituency.Id);
            if (dr.HasRows)
            {
                markers = "{type: 'FeatureCollection',features:[";

                while (dr.Read())
                {
                    markers += "{type:'Feature',geometry:{type:'Point',coordinates:" + dr[0].ToString() + "},properties:{id:" + Convert.ToInt16(dr[1]) + ",title: 'Facility',description:'" + dr[2].ToString() + "'}},";
                }

                markers += "]}";
            }

            return JObject.Parse(markers);
        }

        public JObject GetMarkers(Ward Ward)
        {
            string markers = "{}";

            SqlServerConnection conn = new SqlServerConnection();
            SqlDataReader dr = conn.SqlServerConnect("SELECT fc_geolocation, fc_idnt, fc_name FROM Facility WHERE fc_geolocation<>'Null' AND fc_ward=" + Ward.Id);
            if (dr.HasRows)
            {
                markers = "{type: 'FeatureCollection',features:[";

                while (dr.Read())
                {
                    markers += "{type:'Feature',geometry:{type:'Point',coordinates:[" + dr[0].ToString() + "]},properties:{id:" + Convert.ToInt16(dr[1]) + ",title: 'Facility',description:'" + dr[2].ToString() + "'}},";
                }

                markers += "]}";
            }

            return JObject.Parse(markers);
        }

    }
}

using System.Net;
using System;
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

using hrhdashboard.Models;
using hrhdashboard.ViewModel;
using hrhdashboard.Extensions;
using hrhdashboard.Services;
using System.Collections.Generic;

namespace hrhdashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _url = "http://41.89.93.183:8080";

        public IActionResult Index(HomeIndexViewModel model, CountyService service)
        {
            model.Markers = service.GetMarkers();
            return View(model);
        }

        [Route("/county/{idnt}")]
        public IActionResult County(int idnt, HomeCountyViewModel model, CountyService service, FacilityService fac)
        {
            model.county = service.GetCounty(idnt);
            model.levels = fac.GetFacilityCategorizationByLevels(model.county);

            return View(model);
        }

        [Route("/constituency/{idnt}")]
        public IActionResult Constituency(int idnt, HomeConstituencyViewModel model, CountyService service, FacilityService fac)
        {
            model.constituency = service.GetConstituency(idnt);
            model.levels = fac.GetFacilityCategorizationByLevels(model.constituency);

            return View(model);
        }

        [Route("/ward/{idnt}")]
        public IActionResult Ward(int idnt, HomeWardViewModel model, CountyService service, FacilityService fac)
        {
            model.ward = service.GetWard(idnt);
            model.levels = fac.GetFacilityCategorizationByLevels(model.ward);

            return View(model);
        }

        [Route("/kmhfl/facility/{code}")]
        public IActionResult Facility(string code, FacilityViewModel model, FacilityService service)
        {
            model.facility = service.GetFacility(code);
            model.owner = service.GetFacilityOwner(model.facility);

            using (WebClient client = new WebClient())
            {
                client.Headers.Clear();
                client.Headers.Add("Content-Type", "application/json");
                client.Headers.Add("Authorization", "Bearer " + new Utils().GetToken());
                var response = client.DownloadString(_url + "/api/facilities/contacts/?format=json&fields=contact_type,actual_contact&facility=" + model.facility.GUID);

                model.contacts = JsonConvert.DeserializeObject<KmhflContactsObject>(response);
            }

            model.HumanResources = service.GetNorms(model.facility, 1);
            model.Infrastructure = service.GetNorms(model.facility, 2);
            model.FacilityChecks = service.GetNorms(model.facility, 3);

            model.FacilityServices = service.GetNorms(model.facility, 2, false, true);
            model.FacilityServices.Add(new Norms());

            return View(model);
        }

        [Route("/kmhfl/facilities")]
        public ActionResult FacilityList(int page = 1)
        {
            string additionalCommand = "";
            if (page != 1) {
                additionalCommand = "&page=" + page;
            }

            using (WebClient client = new WebClient())
            {
                client.Headers.Clear();
                client.Headers.Add("Content-Type", "application/json");
                client.Headers.Add("Authorization", "Bearer " + new Utils().GetToken());
                var response = client.DownloadString(_url + "/api/facilities/facilities/?format=json&fields=code,name,facility_type_name,keph_level_name,operation_status_name,county,constituency,ward_name,owner_name,lat_long" + additionalCommand);

                var data = JsonConvert.DeserializeObject<KmhflFacilitiesObject>(response);
                return View(data);
            }
        }

        [Route("/kmhfl/facilities/compare")]
        public ActionResult FacilityCompareIndex(CompareIndexViewModel model, FacilityService service) {
            model.facilities = service.GetFacilitiesAutocomplete();
                
            return View(model);   
        }

        [Route("/search")]
        public ActionResult FacilitySearch(FacilitySearchViewModel model, FacilityService service, CountyService dashboard, string facility="", int county=0, int level=0){
            string SearchString = "WHERE fc_level<>99";

            if (!string.IsNullOrWhiteSpace(facility)){
                SearchString += " AND fc_name LIKE '%" + facility.Replace("'", "`") + "%'";
            }

            if (county != 0){
                SearchString += " AND fc_county=" + county;
            }

            if (level != 0){
                SearchString += " AND fc_level=" + level;
            }

            //Don't Pull if Nothing Passed
            if (SearchString.Equals("WHERE fc_level<>99")){
                SearchString += " AND fc_idnt=0";
            }

            model.facility = facility.Trim();
            model.county = county;
            model.level = level;
            model.counties = dashboard.GetCounties();
            model.facilities = service.GetFacilities(SearchString);

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public JsonResult GetCompareFacilities(string code, Boolean ifac, FacilityService service)
        {
            code = code.Trim().Split(null)[0];

            CompareModel model = new CompareModel();
            model.Facility = service.GetFacility(code);
            if (ifac)
                model.Facilities = service.GetFacilitiesAutocomplete("WHERE fc_idnt<>" + model.Facility.Id + " AND fc_level=" + model.Facility.Category.Level.Id);

            List<Norms> HumanResources = service.GetNorms(model.Facility, 1);
            List<Norms> Infrastructure = service.GetNorms(model.Facility, 2);
            List<Norms> FacilityChecks = service.GetNorms(model.Facility, 3);

            double norms = 0;
            double value = 0;

            foreach (var norm in HumanResources){
                norms += norm.Norm;
                value += norm.Value;
            }

            model.ScoreHumanResources = (value / norms) * 100;
            norms = 0;
            value = 0;

            foreach (var norm in Infrastructure)
            {
                norms += norm.Norm;
                value += norm.Value;
            }

            model.ScoreInfrastructure = (value / norms) * 100;
            norms = 0;
            value = 0;

            foreach (var norm in FacilityChecks)
            {
                norms += norm.Norm;
                value += norm.Value;
            }

            model.ScoreChecklist = (value / norms) * 100;
            norms = 0;
            value = 0;

            model.ScoreOverall = (model.ScoreChecklist + model.ScoreInfrastructure + model.ScoreHumanResources) / 3;

            return Json(model);
        }
    }
}

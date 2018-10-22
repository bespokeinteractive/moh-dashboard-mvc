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

namespace hrhdashboard.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(HomeIndexViewModel model, CountyService service)
        {
            model.Markers = service.GetMarkers();
            return View(model);
        }

        [Route("/county/{idnt}")]
        public IActionResult County(int idnt, HomeCountyViewModel model, CountyService service, FacilityService fac)
        {
            model.county = service.GetCounty(idnt);
            model.county.Facilities = fac.GetFacilityCount(model.county);
            model.tiers = fac.GetFacilityCategorizationByTiers(model.county);

            return View(model);
        }

        [Route("/constituency/{idnt}")]
        public IActionResult Constituency(int idnt, HomeConstituencyViewModel model, CountyService service, FacilityService fac)
        {
            model.constituency = service.GetConstituency(idnt);
            model.constituency.Facilities = fac.GetFacilityCount(model.constituency);
            return View(model);
        }

        [Route("/ward/{idnt}")]
        public IActionResult Ward(int idnt, HomeWardViewModel model, CountyService service)
        {
            model.Ward = service.GetWard(idnt);
            return View(model);
        }

        [Route("/kmhfl/facility/{code}")]
        public IActionResult Facility(int code)
        {
            return View();
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
                var response = client.DownloadString("http://api.kmhfltest.health.go.ke/api/facilities/facilities/?format=json&fields=code,name,facility_type_name,keph_level_name,operation_status_name,county,constituency,ward_name,owner_name,lat_long&owner_type=6a833136-5f50-46d9-b1f9-5f961a42249f" + additionalCommand);

                var data = JsonConvert.DeserializeObject<KmhflFacilitiesObject>(response);
                return View(data);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

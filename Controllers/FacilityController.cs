using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using hrhdashboard.Models;
using hrhdashboard.ViewModel;
using hrhdashboard.Services;

namespace hrhdashboard.Controllers
{
    [Authorize]
    public class FacilityController : Controller
    {
        [BindProperty]
        public FacilityAssessmentViewModel Input { get; set; }

        // GET: /<controller>/
        [Route("/assessment/facility/{code}")]
        public IActionResult FacilityAssessment(String code, FacilityAssessmentViewModel model, FacilityService svc)
        {
            model.Facilities = svc.GetFacilitiesByUserLoggedIn();
            model.ActiveTab = "";

            if (String.IsNullOrEmpty(code) || code.Equals("x"))
                model.Selected = model.Facilities[0];
            else
                model.Selected = svc.GetFacility(code);
            
            model.HumanResources = svc.GetNorms(model.Selected, 1);
            model.Infrastructure = svc.GetNorms(model.Selected, 2);
            model.FacilityChecks = svc.GetNorms(model.Selected, 3, true);

            return View(model);
        }

        [Route("/services")]
        public ActionResult FacilityAvailableServices(FacilitySearchViewModel model, FacilityService service, CountyService dashboard, string facility = "", int county = 0, int level = 0)
        {
            string SearchString = "WHERE fc_level<>99";

            if (!string.IsNullOrWhiteSpace(facility))
            {
                SearchString += " AND fc_name LIKE '%" + facility.Replace("'", "`") + "%'";
            }

            if (county != 0)
            {
                SearchString += " AND fc_county=" + county;
            }

            if (level != 0)
            {
                SearchString += " AND fc_level=" + level;
            }

            //Don't Pull if Nothing Passed
            if (SearchString.Equals("WHERE fc_level<>99"))
            {
                SearchString += " AND fc_idnt=0";
            }


            model.facility = facility.Trim();
            model.county = county;
            model.level = level;          
            model.counties = dashboard.GetCounties();
            model.facilities = service.GetFacilities(SearchString);

            return View(model);
        }

        [HttpPost]
        public IActionResult PostFacilityChecks(FacilityAssessmentViewModel model, FacilityService svc)
        {
            foreach (var norm in Input.FacilityChecks)
            {
                norm.Facility = new Facility(Input.Selected.Id);
                norm.Save();
            }

            return LocalRedirect("/assessment/facility/" + Input.Selected.Code);
        }

        [HttpPost]
        public IActionResult PostHumanResources(FacilityAssessmentViewModel model, FacilityService svc)
        {
            foreach (var norm in Input.HumanResources)
            {
                norm.Facility = new Facility(Input.Selected.Id);
                norm.Save();
            }

            return LocalRedirect("/assessment/facility/" + Input.Selected.Code + "#humanresources");
        }

        [Route("/facility/services/{code}")]
        public IActionResult FacilityAvailableServices(String code, FacilityAssessmentViewModel model, FacilityService svc)
        {
            model.Facilities = svc.GetFacilitiesByUserLoggedIn();
            model.ActiveTab = "";

            if (String.IsNullOrEmpty(code) || code.Equals("x"))
                model.Selected = model.Facilities[0];
            else
                model.Selected = svc.GetFacility(code);

            model.Infrastructure = svc.GetNorms(model.Selected, 2);
            model.FacilityChecks = svc.GetNorms(model.Selected, 3, true);


            return View(model);
        }

        [HttpPost]
        public IActionResult PostInfrastructure(FacilityAssessmentViewModel model, FacilityService svc)
        {
            foreach (var norm in Input.Infrastructure)
            {
                norm.Facility = new Facility(Input.Selected.Id);
                norm.Save();
            }

            return LocalRedirect("/assessment/facility/" + Input.Selected.Code + "#infrastructure");
        }


        
    }
}

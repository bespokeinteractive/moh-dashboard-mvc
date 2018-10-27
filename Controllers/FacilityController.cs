using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using hrhdashboard.Models;
using hrhdashboard.ViewModel;
using hrhdashboard.Services;
using static hrhdashboard.Models.Norms;

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
            
            model.HumanResources = svc.GetHumanResourceNorms(model.Selected, 1);
            model.Infrastructure = svc.GetNorms(model.Selected, 2);
            model.FacilityChecks = svc.GetNorms(model.Selected, 3, true); 
           
    
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
                norm.SaveHumanResource();
            }

            return LocalRedirect("/assessment/facility/" + Input.Selected.Code + "#humanresources");
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

using System;
using System.Collections.Generic;
using hrhdashboard.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Filters;

namespace hrhdashboard.ViewModel
{
    public class FacilityAssessmentViewModel
    {
        public List<Facility> Facilities { get; set; }
        public List<Norms> FacilityChecks { get; set; }
        public List<Norms> HumanResources { get; set; }
        public List<Norms> Infrastructure { get; set; }
        public Facility Selected { get; set; }
        public String ActiveTab { get; set; }

        public FacilityAssessmentViewModel()
        {
            Facilities = new List<Facility>();
            FacilityChecks = new List<Norms>();
            HumanResources = new List<Norms>();
            Infrastructure = new List<Norms>();
            Selected = new Facility();
            ActiveTab = "";
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class RequestFormSizeLimitAttribute : Attribute, IAuthorizationFilter, IOrderedFilter
    {
        private readonly FormOptions _formOptions;

        public RequestFormSizeLimitAttribute(int valueCountLimit)
        {
            _formOptions = new FormOptions()
            {
                ValueCountLimit = valueCountLimit
            };
        }

        public int Order { get; set; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var features = context.HttpContext.Features;
            var formFeature = features.Get<IFormFeature>();

            if (formFeature == null || formFeature.Form == null)
            {
                // Request form has not been read yet, so set the limits
                features.Set<IFormFeature>(new FormFeature(context.HttpContext.Request, _formOptions));
            }
        }
    }


}

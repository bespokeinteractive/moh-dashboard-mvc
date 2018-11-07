using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hrhdashboard.Models;
using hrhdashboard.Services;
using hrhdashboard.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace hrhdashboard.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminServices(AdminViewModel model, FacilityService service)
        {
            model.Types = service.GetNormsTypesIEnumerable();
            model.Categories = service.GetNormsCategoryIEnumerable();

            return View(model);
        }
    }
}
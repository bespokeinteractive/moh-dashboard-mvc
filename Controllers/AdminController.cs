using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hrhdashboard.Extensions;
using hrhdashboard.Models;
using hrhdashboard.Services;
using hrhdashboard.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hrhdashboard.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        [BindProperty]
        public AdminViewModel Input { get; set; }

        [Route("/adminstrator")]
        public IActionResult AdminServices(AdminViewModel model, FacilityService service, UserServices user , CountyService dashboard)
        {
            model.Types = service.GetNormsTypesIEnumerable();
            model.Categories = service.GetNormsCategoryIEnumerable();
            model.Role = user.GetRolesIEnumarable();
            model.Counties = dashboard.GetCountyIEnumarable();

            return View(model);
        }

        [Route("/adminstrator/users")]
        public IActionResult Users(UserServices service)
        {
            List<Users> users = new List<Users>(service.GetUsers());
            return View(users);
        }

        [HttpPost]
        public IActionResult PostUsers(AdminViewModel model, UserServices svc , CrytoUtilsExtensions Cryto)
        {
            Input.Users.Password = Cryto.Encrypt(Input.Users.Password);
            Input.Users.Save();
           
           return LocalRedirect("/adminstrator");
        }

        [HttpPost]
        public IActionResult PostNormItems(AdminViewModel model, UserServices svc) {
            Input.NormsItems.Save();          
            return LocalRedirect("/adminstrator");
        }

        public JsonResult GetConstituency(int idnt, CountyService service) {
            List<SelectListItem> constituency = new List<SelectListItem>(service.GetConstituencyIEnumarable(new County(idnt)));
            return Json(constituency);
         }
    }
}
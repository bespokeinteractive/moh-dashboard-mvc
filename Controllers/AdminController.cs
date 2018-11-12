using System.Collections.Generic;
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

        [Route("/administrator")]
        public IActionResult AdminServices(AdminViewModel model, FacilityService service, UserServices user , CountyService dashboard)
        {
            model.Types = service.GetNormsTypesIEnumerable();
            model.Categories = service.GetNormsCategoryIEnumerable();
            model.Role = user.GetRolesIEnumarable();
            model.Counties = dashboard.GetCountyIEnumarable();

            return View(model);
        }

        [Route("/administrator/users")]
        public IActionResult Users(UserServices service) {
            List<Users> users = new List<Users>(service.GetUsers());
            return View(users);
        }

        [Route("/administrator/users/{idnt}")]
        public IActionResult UsersView(int idnt, UserServices service) {
            Users user = service.GetUser(idnt);
            return View(user);
        }

        [Route("/administrator/users/add")]
        public IActionResult UsersAdd(UserServices service) {
            Users user = new Users();
            return View(user);
        }

        [Route("/administrator/users/edit/{idnt}")]
        public IActionResult UsersEdit(int idnt, UserServices service) {
            Users user = service.GetUser(idnt);
            return View(user);
        }

        [HttpPost]
        public IActionResult PostUsers(AdminViewModel model, UserServices svc , CrytoUtilsExtensions Cryto)
        {
            Input.Users.Password = Cryto.Encrypt(Input.Users.Password);
            Input.Users.Save();
           
           return LocalRedirect("/administrator");
        }

        [HttpPost]
        public IActionResult PostNormItems(AdminViewModel model, UserServices svc) {
            Input.NormsItems.Save();          
            return LocalRedirect("/administrator");
        }

        public JsonResult GetConstituency(int idnt, CountyService service) {
            List<SelectListItem> constituency = new List<SelectListItem>(service.GetConstituencyIEnumarable(new County(idnt)));
            return Json(constituency);
         }
    }
}
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
        public UsersAddViewModel UserInput { get; set; }

        [BindProperty]
        public AdminViewModel NormsImput { get; set; }

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
        public IActionResult UsersAdd(UsersAddViewModel model, UserServices service) {
            model.roles = service.GetRolesIEnumarable();
            return View(model);
        }

        [Route("/administrator/users/edit/{idnt}")]
        public IActionResult UsersEdit(int idnt, UsersAddViewModel model, UserServices service) {
            model.user = service.GetUser(idnt);
            model.roles = service.GetRolesIEnumarable();

            return View(model);
        }

        [HttpPost]
        public IActionResult PostUsers(UsersAddViewModel model, UserServices svc , CrytoUtilsExtensions Cryto)
        {
            UserInput.user.Password = Cryto.Encrypt(UserInput.user.Password);
            UserInput.user.Save();
           
           return LocalRedirect("/administrator/users");
        }

        [HttpPost]
        public IActionResult PostNorms(AdminViewModel model) {
            NormsImput.NormsView.Save();         
            return LocalRedirect("/administrator/norms");
        }

        public JsonResult GetConstituency(int idnt, CountyService service) {
            List<SelectListItem> constituency = new List<SelectListItem>(service.GetConstituencyIEnumarable(new County(idnt)));
            return Json(constituency);
        }

        [Route("/administrator/norms")]
        public IActionResult Norms(FacilityService service , AdminNormsViewModel model)
        {
            model.HumanResources = new List<NormsView>(service.GetNormsViews(new NormsType(1)));
            model.Infrastructure = new List<NormsView>(service.GetNormsViews(new NormsType(2)));
            model.FacilityChecks = new List<NormsView>(service.GetNormsViews(new NormsType(3)));

            return View(model);
        }

        [Route("/administrator/norms/edit/{idnt}")]
        public IActionResult NormsEdit(int idnt, AdminViewModel model, FacilityService service)
        {
            model.NormsView = service.GetNormsViewsItem(idnt);
            model.Types = service.GetNormsTypesIEnumerable();
            model.Categories = service.GetNormsCategoryIEnumerable();
            return View(model);
        }


    }
}
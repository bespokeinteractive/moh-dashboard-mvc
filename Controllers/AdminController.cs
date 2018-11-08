using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hrhdashboard.Extensions;
using hrhdashboard.Models;
using hrhdashboard.Services;
using hrhdashboard.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace hrhdashboard.Controllers
{
    public class AdminController : Controller
    {
        [BindProperty]
        public AdminViewModel Input { get; set; }

        [Route("/adminstrator")]
        public IActionResult AdminServices(AdminViewModel model, FacilityService service, UserServices user)
        {
            model.Types = service.GetNormsTypesIEnumerable();
            model.Categories = service.GetNormsCategoryIEnumerable();
            model.Role = user.GetRolesIEnumarable();
            return View(model);
        }


        [HttpPost]
        public IActionResult PostUsers(AdminViewModel model, UserServices svc , CrytoUtilsExtensions Cryto)
        {
            Input.Users.Password = Cryto.Encrypt(Input.Users.Password);
            Input.Users.Save();
           
           return LocalRedirect("/adminstrator");

        }

        [HttpPost]
        public IActionResult PostNormItems(AdminViewModel model, UserServices svc  )
        {

            Input.NormsItems.Save();

          
            return LocalRedirect("/adminstrator");

        }

    }
}
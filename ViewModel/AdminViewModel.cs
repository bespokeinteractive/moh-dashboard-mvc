using hrhdashboard.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrhdashboard.ViewModel
{
    public class AdminViewModel
    {
        public List<SelectListItem> Types { get; set; }
        public List<SelectListItem>  Categories { get; set; }
        public List<SelectListItem> Role { get; set; }
        public List<SelectListItem> Counties { get; set; }
        public List<SelectListItem> Constituencies { get; set; }

        public Roles Roles { get; set; }
        public NormsItems NormsItems { get; set; }

        public Users Users { get; set; }

 
        public AdminViewModel()
        {
            NormsItems = new NormsItems();
            Roles = new Roles();
            Types = new List<SelectListItem>();
            Categories = new List<SelectListItem>();
            Role = new List<SelectListItem>();
            Counties = new List<SelectListItem>();
            Constituencies = new List<SelectListItem>();

            Users = new Users();
         

        }
    }

   
}

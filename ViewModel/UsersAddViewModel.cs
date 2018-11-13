using System;
using System.Collections.Generic;
using hrhdashboard.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hrhdashboard.ViewModel
{
    public class UsersAddViewModel
    {
        public Users user { get; set; }
        public String password { get; set; }
        public String accesslvl { get; set; }

        public List<SelectListItem> roles { get; set; }

        public UsersAddViewModel()
        {
            user = new Users();
            roles = new List<SelectListItem>();

            password = "";
            accesslvl = "";
        }
    }
}

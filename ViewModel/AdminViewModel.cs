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

        public NormsItems NormsItems { get; set; }

        public AdminViewModel()
        {
            NormsItems = new NormsItems();
            Types = new List<SelectListItem>();
            Categories = new List<SelectListItem>();

          
        }
    }

   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hrhdashboard.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace hrhdashboard.ViewModel
{
    public class AdminNormsViewModel
    {
        public List<NormsView> HumanResources;
        public List<NormsView> Infrastructure;
        public List<NormsView> FacilityChecks;

        public AdminNormsViewModel() {
            HumanResources = new List<NormsView>();
            Infrastructure = new List<NormsView>();
            FacilityChecks = new List<NormsView>();
        }
    }
}

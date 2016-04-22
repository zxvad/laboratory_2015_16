using System.Collections.Generic;
using ManagerReports.Services.Models;
using ManagerReports.Web.ViewModels.Models;
using Microsoft.AspNet.Mvc;

namespace ManagerReports.Web.ViewComponents
{
    public class ProjectResourcesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(decimal soldHours, decimal budget, IEnumerable<Resource> resources)
        {
            return View("_ProjectResources", new ProjectResourcesModel
            {
                SoldHours = soldHours,
                Budget = budget,
                Resources = resources
            });
        }
    }
}
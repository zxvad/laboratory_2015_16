using System.Collections.Generic;
using ManagerReports.Services.Models;
using Microsoft.AspNet.Mvc;

namespace ManagerReports.Web.ViewComponents
{
    public class ProjectVersionsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<ProjectVerison> versions)
        {
            return View("_ProjectVersions", versions);
        }
    }
}
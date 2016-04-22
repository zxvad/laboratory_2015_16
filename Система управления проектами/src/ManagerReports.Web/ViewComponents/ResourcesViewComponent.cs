using System.Collections.Generic;
using ManagerReports.Services.Models;
using Microsoft.AspNet.Mvc;

namespace ManagerReports.Web.ViewComponents
{
    public class ResourcesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<Resource> resources)
        {
            return View("_Resources", resources);
        }
    }
}
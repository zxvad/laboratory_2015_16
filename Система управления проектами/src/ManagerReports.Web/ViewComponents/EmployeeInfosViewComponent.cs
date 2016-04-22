using System.Collections.Generic;
using ManagerReports.Services.Models;
using Microsoft.AspNet.Mvc;

namespace ManagerReports.Web.ViewComponents
{
    public class EmployeeInfosViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<EmployeeTimeMoney> employeeInfos)
        {
            return View("_EmployeeInfos", employeeInfos);
        }
    }
}
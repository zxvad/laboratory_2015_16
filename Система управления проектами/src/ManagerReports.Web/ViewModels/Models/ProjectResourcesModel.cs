using System.Collections.Generic;
using ManagerReports.Services.Models;

namespace ManagerReports.Web.ViewModels.Models
{
    public class ProjectResourcesModel
    {
        public decimal SoldHours { get; set; }
        public decimal Budget { get; set; }
        public IEnumerable<Resource> Resources { get; set; }
    }
}
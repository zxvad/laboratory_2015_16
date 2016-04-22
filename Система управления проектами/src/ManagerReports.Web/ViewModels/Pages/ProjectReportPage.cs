using System;
using ManagerReports.Services.Models;

namespace ManagerReports.Web.ViewModels.Pages
{
    public class ProjectReportPage : PageBase
    {
        public ProjectReportPage() : base("Подробная информация")
        {
        }

        public ProjectReport Project { get; set; }

        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
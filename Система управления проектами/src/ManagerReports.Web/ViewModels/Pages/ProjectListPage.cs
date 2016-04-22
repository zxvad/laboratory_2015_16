using System.Collections.Generic;
using ManagerReports.Services.Models;

namespace ManagerReports.Web.ViewModels.Pages
{
    public class ProjectListPage : PageBase
    {
        public ProjectListPage() : base("Проекты ЦВТ") {}

        public IEnumerable<Project> Projects { get; set; }
    }
}
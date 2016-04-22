using System.Collections.Generic;
using ManagerReports.Services.Models;

namespace ManagerReports.Web.ViewModels.Pages
{
    public class EmployeeListPage : PageBase
    {
        public EmployeeListPage() : base("Сотрудники ЦВТ")
        {
        }

        public IEnumerable<Employee> Employees { get; set; } 
    }
}
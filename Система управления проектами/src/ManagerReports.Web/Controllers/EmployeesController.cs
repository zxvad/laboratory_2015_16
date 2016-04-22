using System;
using Microsoft.AspNet.Mvc;
using ManagerReports.Services.Interfaces;
using ManagerReports.Web.ViewModels.Pages;
using Microsoft.AspNet.Authorization;

namespace ManagerReports.Web.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        public const string Name = "employees";

        public const string DefaultAction = "index";
        public const string EmployeeDetailsAction = "employee-details";
        public const string UpdateTimeRecordResourceAction = "update-timerecordresource";

        private readonly IEmployeeService _employeeService;
        private readonly ITimeRecordService _timeRecordService;

        public EmployeesController(IEmployeeService employeeService, ITimeRecordService timeRecordService)
        {
            _employeeService = employeeService;
            _timeRecordService = timeRecordService;
        }

        [HttpGet]
        [ActionName(DefaultAction)]
        public IActionResult Index()
        {
            var model = new EmployeeListPage
            {
                Employees = _employeeService.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        [ActionName(UpdateTimeRecordResourceAction)]
        public IActionResult UpdateTimeRecordResource(Guid id, string resourceValue)
        {
            try
            {
                _timeRecordService.UpdateTimeRecordResource(id, resourceValue);

                return Json(new
                {
                    success = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
    }
}
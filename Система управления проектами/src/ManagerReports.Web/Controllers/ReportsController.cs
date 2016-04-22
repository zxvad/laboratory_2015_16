using System;
using System.IO;
using ManagerReports.Services.Interfaces.Reports;
using ManagerReports.Web.ViewModels.Pages;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http;

namespace ManagerReports.Web.Controllers
{
    public class ReportsController : Controller
    {
        public const string Name = "reports";

        public const string ProjectReportAction = "project-report";
        public const string EmployeeReportAction = "employee-report";
        public const string ProjectsExcelReportAction = "projects-excel-report";
        public const string EmployeesExcelReportAction = "employees-excel-report";
        public const string SaveDatepickerDatesAction = "save-datepicker-dates";

        private readonly IProjectReportService _projectReportService;
        private readonly IProjectExcelReportService _projectExcelReportService;

        private readonly IEmployeeReportService _employeeReportService;
        private readonly IEmployeeExcelReportService _employeeExcelReportService;

        public ReportsController(IProjectReportService projectReportService, 
                                 IProjectExcelReportService projectExcelReportService, 
                                 IEmployeeReportService employeeReportService, 
                                 IEmployeeExcelReportService employeeExcelReportService)
        {
            _projectReportService = projectReportService;
            _projectExcelReportService = projectExcelReportService;

            _employeeReportService = employeeReportService;
            _employeeExcelReportService = employeeExcelReportService;
        }

        [HttpGet]
        [ActionName(ProjectReportAction)]
        [Route("project-report/{projectId}")]
        public IActionResult ProjectReport(Guid projectId)
        {
            return View("_ProjectReport", new ProjectReportPage
            {
                Project = _projectReportService.GetReport(projectId)
            });
        }

        [HttpGet]
        [ActionName(ProjectsExcelReportAction)]
        public IActionResult ProjectsExcelReport()
        {
            DateTime? beginDate, endDate;
            GetDatesFromText(HttpContext.Session.GetString("beginDate"), HttpContext.Session.GetString("endDate"), out beginDate, out endDate);

            return GetReportFile("Отчет по проектам", beginDate?.ToShortDateString() ?? "", endDate?.ToShortDateString() ?? "", _projectExcelReportService.GetExcelReport(beginDate, endDate));
        }

        [HttpGet]
        [ActionName(EmployeeReportAction)]
        [Route("employee-report/{employeeId}")]
        public IActionResult EmployeeWebReport(Guid employeeId)
        {
            return View("_EmployeeReport", new EmployeeDetailsPage
            {
                EmployeeReport = _employeeReportService.GetReport(employeeId)
            });
        }

        [HttpGet]
        [ActionName(EmployeesExcelReportAction)]
        public IActionResult EmployeesExcelReport()
        {
            DateTime? beginDate, endDate;
            GetDatesFromText(HttpContext.Session.GetString("beginDate"), HttpContext.Session.GetString("endDate"), out beginDate, out endDate);

            return GetReportFile("Отчет по сотрудникам", beginDate?.ToShortDateString() ?? "", endDate?.ToShortDateString() ?? "", _employeeExcelReportService.GetExcelReport(beginDate, endDate));
        }

        [HttpPost]
        [ActionName(SaveDatepickerDatesAction)]
        public ActionResult SaveDatepickerDates(string beginDate, string endDate)
        {
            if (IsValidDates(beginDate, endDate))
            {
                HttpContext.Session.SetString("beginDate", DateTime.Parse(beginDate).ToString("yyyy-MM-dd"));
                HttpContext.Session.SetString("endDate", DateTime.Parse(endDate).ToString("yyyy-MM-dd"));

                return Json(new
                {
                    success = true
                });
            }

            HttpContext.Session.SetString("beginDate", DateTime.Today.ToString("yyyy-MM-dd"));
            HttpContext.Session.SetString("endDate", DateTime.Today.ToString("yyyy-MM-dd"));

            return Json(new
            {
                success = false
            });
        }

        private static bool IsValidDates(string beginDateText, string endDateText)
        {
            DateTime? beginDate;
            DateTime? endDate;

            GetDatesFromText(beginDateText, endDateText, out beginDate, out endDate);

            if (!(beginDate.HasValue && endDate.HasValue))
            {
                return false;
            }

            var lowerLimit = new DateTime(2010, 1, 1);
            var upperLimit = new DateTime(2100, 1, 1);

            return lowerLimit <= beginDate.Value &&
                   endDate.Value <= upperLimit &&
                   beginDate.Value <= endDate.Value;
        }

        private static void GetDatesFromText(string beginDateText, string endDateText, out DateTime? beginDate, out DateTime? endDate)
        {
            beginDate = null;
            endDate = null;

            DateTime parsingBeginDate, parsingEndDate;

            if (!string.IsNullOrEmpty(beginDateText) && DateTime.TryParse(beginDateText, out parsingBeginDate))
            {
                beginDate = parsingBeginDate;
            }

            if (!string.IsNullOrEmpty(endDateText) && DateTime.TryParse(endDateText, out parsingEndDate))
            {
                endDate = parsingEndDate;
            }
        }

        private static FileStreamResult GetReportFile(string fileName, string beginDate, string endDate, byte[] data)
        {
            return new FileStreamResult(new MemoryStream(data), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = $"{fileName} за {beginDate}-{endDate}.xlsx"
            };
        }
    }
}
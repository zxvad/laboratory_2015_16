using System;
using System.Collections.Generic;
using System.Linq;
using ManagerReports.Dal;
using ManagerReports.Dal.Entities;
using ManagerReports.Services.Extentions;
using ManagerReports.Services.Interfaces.Reports;
using ManagerReports.Services.Models;
using Microsoft.Data.Entity;

namespace ManagerReports.Services.Services.Reports
{
    public class EmployeeReportService : IEmployeeReportService
    {
        private readonly ManagerReportsContext _dbContext;

        public EmployeeReportService(ManagerReportsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EmployeeReport GetReport(Guid id)
        {
            var employee = LoadEmployees().ToArray().Single(i => i.Id == id);
            return ToEmployeeReport(employee);
        }

        public IEnumerable<EmployeeReport> GetAllReports(DateTime? beginDate, DateTime? endDate)
        {
            return LoadEmployees().ToArray().Select(i => ToEmployeeReport(i, beginDate, endDate));
        }

        private IQueryable<EmployeeEntity> LoadEmployees()
        {
            return _dbContext.Employees
                 .Include(i => i.TimeRecords)
                    .ThenInclude(i => i.Employee)
                .Include(i => i.TimeRecords)
                    .ThenInclude(i => i.Issue)
                    .ThenInclude(i => i.Project)
                .Include(i => i.TimeRecords)
                    .ThenInclude(i => i.Issue)
                    .ThenInclude(i => i.ProjectVersion)
                .Include(i => i.TimeRecords)
                    .ThenInclude(i => i.Resources)
                    .ThenInclude(i => i.Resource)
                .Include(i => i.SoldResources)
                    .ThenInclude(i => i.SoldResource)
                    .ThenInclude(i => i.Project)
                .AsNoTracking();
        }

        private static EmployeeReport ToEmployeeReport(EmployeeEntity employee, DateTime? beginDate = null, DateTime? endDate = null)
        {
            var actualBeginDate = beginDate ?? DateTime.MinValue;
            var actualEndDate = endDate ?? DateTime.MaxValue;

            var employeeReport = new EmployeeReport
            {
                Employee = employee.ToEmployeeModel(),

                TimeRecords = employee.TimeRecords
                    .Where(i => actualBeginDate <= i.Date && i.Date <= actualEndDate)
                    .Select(timeRecord => timeRecord.ToTimeRecord())
                    .ToArray(),

                Resources = employee.SoldResources
                    .Select(i => i.SoldResource)
                    .Select(resource => resource.ToResourceModel(beginDate, endDate))
                    .ToArray(),

                ProjectResources = employee.SoldResources.Select(resource => new ProjectResource
                {
                    ProjectName = resource.SoldResource.Project.Name,
                    Resource = resource.SoldResource.ToResourceModel(beginDate, endDate)
                })
            };

            employeeReport.TakenTime = employeeReport.ProjectResources.Sum(i => i.Resource.TakenTime);
            employeeReport.TakenMoney = employeeReport.ProjectResources.Sum(i => i.Resource.TakenMoney);

            return employeeReport;
        }
    }
}
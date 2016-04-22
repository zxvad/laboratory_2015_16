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
    public class ProjectReportService : IProjectReportService
    {
        private readonly ManagerReportsContext _dbContext;

        public ProjectReportService(ManagerReportsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProjectReport GetReport(Guid id)
        {
            var project = LoadProjects().Single(i => i.Id == id);
            return ToProjectReport(project);
        }

        public IEnumerable<ProjectReport> GetAllReports(DateTime? beginDate = null, DateTime? endDate = null)
        {
            return LoadProjects().ToArray().Select(i => ToProjectReport(i, beginDate, endDate));
        }
        
        private ProjectReport ToProjectReport(ProjectEntity project, DateTime? beginDate = null, DateTime? endDate = null)
        {
            var timeRecordsWithoutResources = LoadTimeRecordsWithoutResources(project.Id, project.Versions.Select(i => i.ExternalId), beginDate, endDate).ToArray();

            return new ProjectReport
            {
                Project = project
                    .ToProjectModel(timeRecordsWithoutResources.Sum(i => i.Hours), beginDate, endDate),

                SelfCost = project.Issues.SelectMany(issue => issue.TimeRecords).GroupBy(timeRecords => timeRecords.Employee)
                    .Select(timeRecordsGroup => timeRecordsGroup.Key.SelfRate * timeRecordsGroup.Sum(i => i.Hours))
                    .Sum(),

                Payments = project.Payments
                    .Select(payment => payment.ToPaymentRecord())
                    .ToArray(),

                Resources = project.SoldResources
                    .Where(i => i.ProjectVersion == null)
                    .Select(resource => resource.ToResourceModel(beginDate, endDate))
                    .ToArray(),

                EmployeesWithoutResource = GetEmployeesWithoutResource(null, timeRecordsWithoutResources)
                    .ToArray(),

                ProjectVerisons = project.Versions
                    .Select(projectVersion => projectVersion.ToProjectVerison(GetEmployeesWithoutResource(projectVersion.ExternalId, timeRecordsWithoutResources), beginDate, endDate))
                    .ToArray()
            };
        }

        private static IEnumerable<EmployeeTimeMoney> GetEmployeesWithoutResource(int? projectVersionId, IEnumerable<TimeRecordEntity> timeRecordsWithoutResources, DateTime? beginDate = null, DateTime? endDate = null)
        {
            var actualBeginDate = beginDate ?? DateTime.MinValue;
            var actualEndDate = endDate ?? DateTime.MaxValue;

            return timeRecordsWithoutResources
                .Where(timeRecord => timeRecord.Issue.ProjectVersionId == projectVersionId &&
                       actualBeginDate <= timeRecord.Date && timeRecord.Date <= actualEndDate)
                .GroupBy(i => i.Employee)
                .Select(i => new EmployeeTimeMoney
                {
                    EmployeeFullName = i.Key.FullName,
                    TakenTime = i.Sum(timeRecord => timeRecord.Hours)
                });
        }

        private IEnumerable<ProjectEntity> LoadProjects()
        {
            return _dbContext.Projects
                .Include(i => i.Issues)
                    .ThenInclude(i => i.TimeRecords)
                    .ThenInclude(i => i.Resources)
                    .ThenInclude(i => i.Resource)
                .Include(i => i.Issues)
                    .ThenInclude(i => i.TimeRecords)
                    .ThenInclude(i => i.Employee)
                .Include(i => i.Issues)
                    .ThenInclude(i => i.ProjectVersion)
                .Include(i => i.Issues)
                    .ThenInclude(i => i.IssueStatus)
                .Include(i => i.SoldResources)
                    .ThenInclude(i => i.Employees)
                    .ThenInclude(i => i.Employee)
                    .ThenInclude(i => i.TimeRecords)
                    .ThenInclude(i => i.Issue)
                    .ThenInclude(i => i.Project)
                .Include(i => i.SoldResources)
                    .ThenInclude(i => i.Employees)
                    .ThenInclude(i => i.Employee)
                    .ThenInclude(i => i.TimeRecords)
                    .ThenInclude(i => i.Resources)
                    .ThenInclude(i => i.Resource)
                .Include(i => i.Payments)
                .Include(i => i.Versions)
                    .ThenInclude(i => i.SoldResources)
                    .ThenInclude(i => i.Employees)
                    .ThenInclude(i => i.Employee)
                    .ThenInclude(i => i.TimeRecords)
                    .ThenInclude(i => i.Issue)
                .Include(i => i.Versions)
                    .ThenInclude(i => i.SoldResources)
                    .ThenInclude(i => i.Employees)
                    .ThenInclude(i => i.Employee)
                    .ThenInclude(i => i.TimeRecords)
                    .ThenInclude(i => i.Resources)
                    .ThenInclude(i => i.Resource)
                .Include(i => i.Versions)
                    .ThenInclude(i => i.Issues)
                    .ThenInclude(i => i.TimeRecords)
                    .ThenInclude(i => i.Employee)
                .Include(i => i.Versions)
                    .ThenInclude(i => i.Payments)
                .AsNoTracking();
        }

        private IEnumerable<TimeRecordEntity> LoadTimeRecordsWithoutResources(Guid projectId, IEnumerable<int?> projectVersionIds, DateTime? beginDate = null, DateTime? endDate = null)
        {
            var actualBeginDate = beginDate ?? DateTime.MinValue;
            var actualEndDate = endDate ?? DateTime.MaxValue;

            Func<SoldResourceEntity, bool> hasSingleResource = resource => resource.ProjectId == projectId &&
                                                                           projectVersionIds.Count(id => resource.ProjectVersionId == id) == 1;

            Func<TimeRecordEntity, bool> fromThisProject = timeRecord => actualBeginDate <= timeRecord.Date && timeRecord.Date <= actualEndDate &&
                                                                         timeRecord.Issue.ProjectId == projectId && 
                                                                         timeRecord.Employee.SoldResources.Count(resource => hasSingleResource(resource.SoldResource)) != 1;

            return _dbContext.TimeRecords
                .Include(i => i.Employee)
                    .ThenInclude(i => i.SoldResources)
                    .ThenInclude(i => i.SoldResource)
                    .ThenInclude(i => i.Project)
                .Include(i => i.Issue)
                    .ThenInclude(i => i.Project)
                .AsNoTracking()
                .ToArray()
                .Where(fromThisProject);
        }
    }
}
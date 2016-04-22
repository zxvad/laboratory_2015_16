using System;
using System.Collections.Generic;
using System.IO;
using ManagerReports.Dal;
using RedmineTool.Infrastructure;
using Serilog;
using Serilog.Events;
using System.Linq;
using ManagerReports.Dal.Entities;
using RedmineTool.Models;
using RedmineTool.Repositories;
using Microsoft.Data.Entity;

namespace RedmineTool
{
    public class Program
    {
        private static ManagerReportsContext _dbContext;

        public static void Main(string[] args)
        {
            _dbContext = new ManagerReportsContext(new Startup().Configuration);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.RollingFile(Path.Combine(Directory.GetCurrentDirectory(), "logs", "{Date}.log"))
                .WriteTo.Console(LogEventLevel.Information)
                .CreateLogger();

            //DownloadProjects();
           DownloadProejectVersions();
            //DownloadEmployees();
            //DownloadIssueStatuses();
           DownloadIssues();

           DownloadTimeRecords();

           UpdatedTimeRecordResourceNames();
        }

        private static void DownloadTimeRecords()
        {
            try
            {
                Log.Logger.Information("Download timeRecords started");

                var timeRecordImporter = ImporterFactory.GetTimeRecordImporter();
                var timeRecordRepository = new TimeRecordRepository();

                foreach (var issueId in _dbContext.Issues.Where(i => i.ExternalId.HasValue).Select(i => i.ExternalId.Value).ToArray())
                {
                    var timeRecords = timeRecordImporter.GetMany(issueId: issueId).ToArray();
                    timeRecordRepository.Save(timeRecords);
                }

                Log.Logger.Information("Download timeRecords finished");

            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.InnerException.Message);
            }
        }

        private static void DownloadProjects()
        {
            try
            {
                Log.Logger.Information("Download projects started");

                var projectImporter = ImporterFactory.GetProjectImporter();
                var projectRepository = new ProjectRepository();

                var projects = new List<RedmineProject>
                {
                    projectImporter.GetById(13),
                    projectImporter.GetById(331),
                    projectImporter.GetById(300),
                    projectImporter.GetById(365),
                    projectImporter.GetById(352)
                };

                projectRepository.Save(projects);

                Log.Logger.Information("Download projects finished");
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
            }
        }

        private static void DownloadIssueStatuses()
        {
            try
            {
                Log.Logger.Information("Download issue statuses started");

                var issueStatusesImporter = ImporterFactory.GetIssueStatusesImporter();
                var issueStatusesRepository = new IssueStatusRepository();

                var statuses = issueStatusesImporter.GetAll();
                issueStatusesRepository.Save(statuses);

                Log.Logger.Information("Download issue statuses finished");
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
            }
        }

        private static void DownloadIssues()
        {
            try
            {
                Log.Logger.Information("Download issues started");

                var issueImporter = ImporterFactory.GetIssueImporter();
                var issueRepository = new IssueRepository();

                var projectIds = _dbContext.Projects.Where(i => i.ExternalId.HasValue).Select(i => i.ExternalId.Value).ToArray();

                foreach (var issues in projectIds.Select(projectId => issueImporter.GetMany(projectId).ToArray()))
                {
                    issueRepository.Save(issues);
                }

                Log.Logger.Information("Download issues finished");
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
            }
        }

        private static void DownloadEmployees()
        {
            try
            {
                Log.Logger.Information("Download users started");

                var employeeImporter = ImporterFactory.GetEmployeeImporter();
                var employeeRepository = new EmployeeRepository();

                var employees = employeeImporter.GetAll().ToList();

                employeeRepository.Save(employees);

                Log.Logger.Information("Download users finished");
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
            }
        }

        private static void DownloadProejectVersions()
        {
            try
            {
                Log.Logger.Information("Download project versions started");

                var projectImporter = ImporterFactory.GetProjectImporter();
                var versionRepository = new VersionRepository();

                var projectIds = _dbContext.Projects.Where(i => i.ExternalId.HasValue).Select(i => i.ExternalId.Value).ToArray();

                foreach (var versions in projectIds.Select(projectId => projectImporter.GetAllProjectVersions(projectId).ToList()))
                {
                    versionRepository.Save(versions);
                }

                Log.Logger.Information("Download project versions finished");
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
            }
        }

        private static void UpdatedTimeRecordResourceNames()
        {
            Log.Logger.Information("Update resource names started");

            try
            {
                var projects = _dbContext.Projects
                    .Include(i => i.Versions)
                        .ThenInclude(i => i.SoldResources)
                        .ThenInclude(i => i.Employees)
                        .ThenInclude(i => i.Employee)
                        .ThenInclude(i => i.TimeRecords)
                        .ThenInclude(i => i.Issue)
                        .ThenInclude(i => i.Project)
                   .Include(i => i.Versions)
                        .ThenInclude(i => i.SoldResources)
                        .ThenInclude(i => i.Employees)
                        .ThenInclude(i => i.Employee)
                        .ThenInclude(i => i.TimeRecords)
                        .ThenInclude(i => i.Resources)
                   .Include(i => i.SoldResources)
                        .ThenInclude(i => i.Employees)
                        .ThenInclude(i => i.Employee)
                        .ThenInclude(i => i.TimeRecords)
                        .ThenInclude(i => i.Resources)
                   .Include(i => i.SoldResources)
                        .ThenInclude(i => i.Employees)
                        .ThenInclude(i => i.Employee)
                        .ThenInclude(i => i.TimeRecords)
                        .ThenInclude(i => i.Issue)
                        .ThenInclude(i => i.ProjectVersion)
                        .ThenInclude(i => i.Project)
                    .ToArray();

                foreach (var project in projects)
                {
                    foreach (var projectVersion in project.Versions.ToArray())
                    {
                        UpdateTimeRecords(projectVersion.SoldResources.ToArray());
                    }

                    UpdateTimeRecords(project.SoldResources.Where(i => i.ProjectVersion == null).ToArray());
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
            }

            Log.Logger.Information("Update resource names finished");
        }

        private static void UpdateTimeRecords(IEnumerable<SoldResourceEntity> resources)
        {
            var resourceTimeRecords = resources.Select(resource => new
            {
                Resource = resource,
                TimeRecords = resource.Employees.SelectMany(i => i.Employee.TimeRecords.Where(tr =>
                {
                    if (tr.Resources.Any())
                    {
                        return false;
                    }

                    if (tr.Issue.ProjectVersion != null)
                    {
                        return tr.Issue.ProjectVersion.Id == resource.ProjectVersion.Id;
                    }

                    return tr.Issue.Project.Id == resource.Project.Id;
                }))
                .ToList()
            })
            .ToArray();

            foreach (var resourceTimeRecord in resourceTimeRecords)
            {
                resourceTimeRecord.TimeRecords.ForEach(timeRecord =>
                {
                    timeRecord.Resources.Add(new ResourceTimeRecordEntity
                    {
                        Resource = resourceTimeRecord.Resource,
                        TimeRecord = timeRecord
                    });

                    _dbContext.Update(timeRecord);
                    _dbContext.SaveChanges();
                });
            }
        }
    }
}
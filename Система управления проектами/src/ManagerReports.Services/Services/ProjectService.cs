using System;
using System.Collections.Generic;
using System.Linq;
using ManagerReports.Dal;
using ManagerReports.Dal.Entities;
using ManagerReports.Services.Extentions;
using ManagerReports.Services.Interfaces;
using ManagerReports.Services.Models;
using Microsoft.Data.Entity;

namespace ManagerReports.Services.Services
{
    /// <summary>
    ///     Бизнес-логика работы с проектами
    /// </summary>
    public class ProjectService : IProjectService
    {
        private readonly ManagerReportsContext _dbContext;

        public ProjectService(ManagerReportsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Project GetById(Guid id)
        {
            return LoadProjects().Single(i => i.Id == id).ToProjectModel();
        }

        public IEnumerable<Project> GetAll()
        {
            return LoadProjects().Select(project => project.ToProjectModel());
        }

        public IEnumerable<Tuple<int?, string>> GetAllVersions(Guid projectId)
        {
            return _dbContext.ProjectVersions
                .Where(i => i.ProjectId == projectId)
                .Select(i => Tuple.Create(i.ExternalId, i.Name));
        }

        public void UpdateProject(Project projectInfo)
        {
            var project = _dbContext.Projects.FirstOrDefault(i => i.Id == projectInfo.Id);

            if (project == null)
            {
                throw new ArgumentException(nameof(projectInfo));
            }

            project.Name = projectInfo.Name ?? project.Name;
            project.Currency = projectInfo.Currency != CurrencyTypes.Undefined ? projectInfo.Currency : project.Currency;

            _dbContext.SaveChanges();
        }

        private ProjectEntity[] LoadProjects()
        {
            return _dbContext.Projects
                .Include(i => i.Issues)
                    .ThenInclude(i => i.TimeRecords)
                    .ThenInclude(i => i.Resources)
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
                .AsNoTracking()
                .ToArray();
        } 
    }
}
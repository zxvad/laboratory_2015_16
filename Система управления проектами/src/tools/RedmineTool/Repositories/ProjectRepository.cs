using System.Collections.Generic;
using ManagerReports.Dal;
using ManagerReports.Dal.Entities;
using RedmineTool.Interfaces.Repositories;
using RedmineTool.Models;
using System.Linq;

namespace RedmineTool.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ManagerReportsContext _dbContext;

        public ProjectRepository()
        {
            _dbContext = new ManagerReportsContext(new Startup().Configuration); ;
        }

        public void Save(IEnumerable<RedmineProject> entities)
        {
            var projectEntities = entities.Select(project => new ProjectEntity
            {
                ExternalId = project.Id,
                Name = project.Name,
                Description = project.Description,
                BegintDate = project.CreatedOn
            });

            foreach (var projectEntity in projectEntities)
            {
                var sourceProject = _dbContext.Projects.FirstOrDefault(project => project.ExternalId == projectEntity.ExternalId);

                if (sourceProject == null)
                {
                    _dbContext.Projects.Add(projectEntity);
                }
                else
                {
                    sourceProject.Name = projectEntity.Name;
                    sourceProject.BegintDate = projectEntity.BegintDate;
                    sourceProject.Description = projectEntity.Description;

                    _dbContext.Projects.Update(sourceProject);
                }
            }

            _dbContext.SaveChanges();
        }
    }
}
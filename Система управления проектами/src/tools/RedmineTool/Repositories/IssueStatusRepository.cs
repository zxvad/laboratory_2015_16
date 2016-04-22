using System.Collections.Generic;
using ManagerReports.Dal;
using ManagerReports.Dal.Entities;
using RedmineTool.Interfaces.Repositories;
using RedmineTool.Models;
using System.Linq;

namespace RedmineTool.Repositories
{
    public class IssueStatusRepository : IIssueStatusRepository
    {
        private readonly ManagerReportsContext _dbContext;

        public IssueStatusRepository()
        {
            _dbContext = new ManagerReportsContext(new Startup().Configuration); ;
        }

        public void Save(IEnumerable<RedmineIssueStatus> entities)
        {
            var issueStatuses = entities.Select(status => new IssueStatusEntity
            {
                ExternalId = status.Id,
                Name = status.Name
            });

            foreach (var statusEntity in issueStatuses)
            {
                var sourceStatus = _dbContext.IssueStatuses.FirstOrDefault(project => project.ExternalId == statusEntity.ExternalId);

                if (sourceStatus == null)
                {
                    _dbContext.IssueStatuses.Add(statusEntity);
                }
                else
                {
                    sourceStatus.Name = statusEntity.Name;

                    _dbContext.IssueStatuses.Update(sourceStatus);
                }
            }

            _dbContext.SaveChanges();
        }
    }
}
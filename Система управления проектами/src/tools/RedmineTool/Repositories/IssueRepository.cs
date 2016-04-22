using System.Collections.Generic;
using ManagerReports.Dal.Entities;
using RedmineTool.Interfaces.Repositories;
using System.Linq;
using ManagerReports.Dal;
using RedmineTool.Models;

namespace RedmineTool.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private readonly ManagerReportsContext _dbContext;

        public IssueRepository()
        {
            _dbContext = new ManagerReportsContext(new Startup().Configuration);
        }

        public void Save(IEnumerable<RedmineIssue> entities)
        {
            var projectVersionIds = _dbContext.ProjectVersions.Select(i => i.ExternalId).ToList();

            var issues = entities.Where(i => i.ProjectVersion == null || projectVersionIds.Contains(i.ProjectVersion.Id)).Select(issue => new IssueEntity
            {
                ExternalId = issue.Id,
                Priority = issue.Priority?.Name,
                Description = issue.Description,
                StartDate = issue.StartDate.Date,
                Author = issue.Author?.Name,
                AssignedTo = issue.AssignedTo?.Name,
                IssueStatus = _dbContext.IssueStatuses.FirstOrDefault(i => i.ExternalId == issue.Status.Id),
                Project = _dbContext.Projects.FirstOrDefault(p => p.ExternalId == issue.Project.Id),
                ProjectVersion = _dbContext.ProjectVersions.ToArray().FirstOrDefault(pv => pv.ExternalId == issue.ProjectVersion?.Id)
            });

            foreach (var issueEntity in issues)
            {
                var sourceIssue = _dbContext.Issues.FirstOrDefault(issue => issue.ExternalId == issueEntity.ExternalId);

                if (sourceIssue == null)
                {
                    _dbContext.Issues.Add(issueEntity);
                    _dbContext.SaveChanges();
                }
                else
                {
                    sourceIssue.Priority = issueEntity.Priority;
                    sourceIssue.Description = issueEntity.Description;
                    sourceIssue.AssignedTo = issueEntity.AssignedTo;

                    _dbContext.Issues.Update(sourceIssue);
                }
            }

            _dbContext.SaveChanges();
        }
    }
}
using System.Collections.Generic;
using ManagerReports.Dal;
using ManagerReports.Dal.Entities;
using RedmineTool.Interfaces.Repositories;
using RedmineTool.Models;
using System.Linq;

namespace RedmineTool.Repositories
{
    public class VersionRepository : IVersionRepository
    {
        private readonly ManagerReportsContext _dbContext;

        public VersionRepository()
        {
            _dbContext = new ManagerReportsContext(new Startup().Configuration); ;
        }

        public void Save(IEnumerable<RedmineVersion> entities)
        {
            var redmineVersions = entities as RedmineVersion[] ?? entities.ToArray();

            var openVersions = redmineVersions.Where(i => i.Status == "open").ToList();
            var recentlyClosedVersions = redmineVersions.Where(i => i.Status == "closed").OrderByDescending(i => i.CreatedOn).Take(3);

            var versions = openVersions.Union(recentlyClosedVersions).Select(version => new ProjectVersionEntity
            {
                ExternalId = version.Id,
                Name = version.Name,
                Status = version.Status,
                Description = version.Description,
                CreatedOn = version.CreatedOn,
                Project = _dbContext.Projects.FirstOrDefault(p => p.ExternalId == version.Project.Id)
            });

            foreach (var versionEntity in versions)
            {
                var sourceVersion = _dbContext.ProjectVersions.FirstOrDefault(version => version.ExternalId == versionEntity.ExternalId);

                if (sourceVersion == null)
                {
                    _dbContext.ProjectVersions.Add(versionEntity);
                }
                else
                {
                    sourceVersion.Name = versionEntity.Name;
                    sourceVersion.Status = versionEntity.Status;
                    sourceVersion.Description = versionEntity.Description;
                    sourceVersion.CreatedOn = versionEntity.CreatedOn;

                    _dbContext.ProjectVersions.Update(sourceVersion);
                }
            }

            _dbContext.SaveChanges();
        }
    }
}
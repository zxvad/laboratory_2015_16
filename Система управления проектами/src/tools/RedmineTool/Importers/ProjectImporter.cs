using System.Collections.Generic;
using System.Linq;
using RedmineTool.Containers;
using RedmineTool.Infrastructure;
using RedmineTool.Interfaces;
using RedmineTool.Interfaces.Importers;
using RedmineTool.Models;

namespace RedmineTool.Importers
{
    public class ProjectImporter : IProjectImporter
    {
        private readonly string _apiFormat;
        private readonly ISerializer _serializer;
        private readonly CommonImporter _commonImporter;
        private readonly DownloadManager _downloadManager;

        public ProjectImporter(string apiFormat)
        {
            _apiFormat = apiFormat;
            _serializer = SerializerFactory.Get(apiFormat);
            _commonImporter = new CommonImporter(RedmineResources.Projects, _apiFormat);
            _downloadManager = new DownloadManager();
        }

        public RedmineProject GetById(int id)
        {
            var source = _commonImporter.GetById(id);
            return _serializer.Deserialize<ProjectContainer>(source).Project;
        }

        public IEnumerable<RedmineProject> GetAll()
        {
            var source = _commonImporter.GetMany();
            return source.SelectMany(i => _serializer.Deserialize<ProjectsContainer>(i).Projects);
        }

        public int GetTotalRecordCount()
        {
            return _commonImporter.GetTotalRecordCount();
        }

        public IEnumerable<RedmineVersion> GetAllProjectVersions(int projectId)
        {
            var query = $"projects/{projectId}/versions.{_apiFormat}";
            var source = _downloadManager.Download(query);
            return _serializer.Deserialize<VersionsContainer>(source).Versions;
        }
    }
}
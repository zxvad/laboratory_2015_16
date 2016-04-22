using System.Collections.Generic;
using System.Linq;
using RedmineTool.Containers;
using RedmineTool.Infrastructure;
using RedmineTool.Interfaces;
using RedmineTool.Interfaces.Importers;
using RedmineTool.Models;

namespace RedmineTool.Importers
{
    public class IssueImporter : IIssueImporter
    {
        private readonly ISerializer _serializer;
        private readonly CommonImporter _commonImporter;


        public IssueImporter(string apiFormat)
        {
            _serializer = SerializerFactory.Get(apiFormat);
            _commonImporter = new CommonImporter(RedmineResources.Issues, apiFormat);
        }

        public RedmineIssue GetById(int id)
        {
            var source = _commonImporter.GetById(id);
            return _serializer.Deserialize<IssueContainer>(source).Issue;
        }

        public IEnumerable<RedmineIssue> GetAll()
        {
            var source = _commonImporter.GetMany();
            return source.SelectMany(i => _serializer.Deserialize<IssuesContainer>(i).Issues);
        }

        public int GetTotalRecordCount()
        {
            return _commonImporter.GetTotalRecordCount();
        }

        public IEnumerable<RedmineIssue> GetMany(int? projectId = null, int? statusId = null)
        {
            var parameters = new List<string>();

            if (projectId.HasValue)
            {
                parameters.Add($"project_id={projectId.Value}");
            }

            parameters.Add(statusId.HasValue ? $"status_id={statusId.Value}" : "status_id=*");

            var source = _commonImporter.GetMany(parameters);
            return source.SelectMany(i => _serializer.Deserialize<IssuesContainer>(i).Issues);
        }
    }
}
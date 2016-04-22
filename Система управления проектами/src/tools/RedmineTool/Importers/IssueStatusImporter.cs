using System.Collections.Generic;
using System.Linq;
using RedmineTool.Containers;
using RedmineTool.Infrastructure;
using RedmineTool.Interfaces;
using RedmineTool.Interfaces.Importers;
using RedmineTool.Models;

namespace RedmineTool.Importers
{
    public class IssueStatusImporter : IIssueStatusImporter
    {
        private readonly ISerializer _serializer;
        private readonly CommonImporter _commonImporter;

        public IssueStatusImporter(string apiFormat)
        {
            _serializer = SerializerFactory.Get(apiFormat);
            _commonImporter = new CommonImporter(RedmineResources.IssueStatuses, apiFormat);
        }

        public IEnumerable<RedmineIssueStatus> GetAll()
        {
            var source = _commonImporter.GetMany();
            return source.SelectMany(i => _serializer.Deserialize<IssueStatusesContainer>(i).Statuses);
        }
    }
}
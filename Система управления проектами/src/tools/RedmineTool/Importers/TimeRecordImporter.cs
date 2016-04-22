using System.Collections.Generic;
using System.Linq;
using RedmineTool.Containers;
using RedmineTool.Infrastructure;
using RedmineTool.Interfaces;
using RedmineTool.Interfaces.Importers;
using RedmineTool.Models;

namespace RedmineTool.Importers
{
    public class TimeRecordImporter : ITimeRecordImporter
    {
        private readonly ISerializer _serializer;
        private readonly CommonImporter _commonImporter;
        
        public TimeRecordImporter(string apiFormat)
        {
            _serializer = SerializerFactory.Get(apiFormat);
            _commonImporter = new CommonImporter(RedmineResources.TimeRecords, apiFormat);
        }

        public RedmineTimeRecord GetById(int id)
        {
            var source = _commonImporter.GetById(id);
            return _serializer.Deserialize<TimeRecordContainer>(source).TimeRecord;
        }

        public IEnumerable<RedmineTimeRecord> GetAll()
        {
            var source = _commonImporter.GetMany();
            return source.SelectMany(i => _serializer.Deserialize<TimeRecordsContainer>(i).TimeRecords);
        }

        public int GetTotalRecordCount()
        {
            return _commonImporter.GetTotalRecordCount();
        }

        public IEnumerable<RedmineTimeRecord> GetMany(int? projectId = null, int? issueId = null)
        {
            var parameters = new List<string>();

            if (projectId.HasValue)
            {
                parameters.Add($"project_id={projectId.Value}");
            }

            if (issueId.HasValue)
            {
                parameters.Add($"issue_id={issueId.Value}");
            }

            var source = _commonImporter.GetMany(parameters);
            return source.SelectMany(i => _serializer.Deserialize<TimeRecordsContainer>(i).TimeRecords);
        }
    }
}
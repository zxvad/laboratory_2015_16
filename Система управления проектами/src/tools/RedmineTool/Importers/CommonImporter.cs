using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using RedmineTool.Infrastructure;

namespace RedmineTool.Importers
{
    internal class CommonImporter
    {
        private string _resourceName { get; }
        private string _resourceFormat { get; }
        private DownloadManager _downloadManager { get; }

        public CommonImporter(string resourceName, string resourceFormat)
        {
            _resourceName = resourceName;
            _resourceFormat = resourceFormat;
            _downloadManager = new DownloadManager();
        }

        public string GetById(int id)
        {
            var query = string.Concat($"{_resourceName}/", id.ToString(), $".{_resourceFormat}");
            return _downloadManager.Download(query);
        }

        public IEnumerable<string> GetMany(IList<string> parameters = null)
        {
            int actualRecordCount = GetTotalRecordCount(parameters);
            int queriesCount = actualRecordCount / DownloadManager.QueryRecordsLimit;

            var queries = Enumerable.Range(0, queriesCount)
                .Select(i => AddParameters($"{_resourceName}.{_resourceFormat}?limit={DownloadManager.QueryRecordsLimit}&offset={i * DownloadManager.QueryRecordsLimit}", parameters))
                .ToList();

            int excessRecords = actualRecordCount - queriesCount * DownloadManager.QueryRecordsLimit;

            if (excessRecords > 0)
            {
                queries.Add(AddParameters($"{_resourceName}.{_resourceFormat}?limit={excessRecords}&offset={queriesCount * DownloadManager.QueryRecordsLimit}", parameters));
            }

            return _downloadManager.DownloadMany(queries);
        }

        public int GetTotalRecordCount(IList<string> parameters = null)
        {
            var source = _downloadManager.Download(AddParameters($"{_resourceName}.{_resourceFormat}?limit=1", parameters));
            var recordCountPattern = new Regex(@"(?<=""?total_count""?[=:][\s""]?)\d{1,10}");

            return recordCountPattern.IsMatch(source) ? int.Parse(recordCountPattern.Match(source).Value) : 1;
        }

        private static string AddParameters(string query, IList<string> parameters)
        {
            if (parameters == null)
            {
                return query;
            }

            var result = new StringBuilder(query);

            foreach (var parameter in parameters)
            {
                result.Append($"&{parameter}");
            }

            return result.ToString();
        }
    }
}
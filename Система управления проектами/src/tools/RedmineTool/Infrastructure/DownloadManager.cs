using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Serilog;

namespace RedmineTool.Infrastructure
{
    public class DownloadManager
    {
        public const int QueryRecordsLimit = 100;

        private RedmineContext RedmineContext { get; }

        public DownloadManager()
        {
            RedmineContext = new RedmineContext();

            Uri redmineHost;

            if (!Uri.TryCreate("http://task.htc-cs.com/", UriKind.Absolute, out redmineHost) ||
                Uri.UriSchemeHttp != redmineHost.Scheme)
            {
                return;
            }

            RedmineContext.HostUri = redmineHost;
            RedmineContext.ApiKey = "5d4039d6dcd37231bf9781ee94a009a8c69ee2bf";
        }

        public string Download(string query)
        {
            string sourceString;

            using (var webClient = GetWebClient())
            {
                Log.Logger.Information($"Download for query {query} started");
                sourceString = webClient.DownloadString(new Uri(RedmineContext.HostUri, query));
                Log.Logger.Information("Done");
            }

            return sourceString;
        }

        public IEnumerable<string> DownloadMany(IEnumerable<string> queries)
        {
            return queries.Select(Download).ToArray();
        }

        private WebClient GetWebClient()
        {
            var client = new WebClient();

            if (string.IsNullOrWhiteSpace(RedmineContext.ApiKey))
            {
                client.Credentials = new NetworkCredential(RedmineContext.Login, RedmineContext.Password);
            }
            else
            {
                client.Headers.Add("X-Redmine-API-Key", RedmineContext.ApiKey);
            }

            return client;
        }
    }
}
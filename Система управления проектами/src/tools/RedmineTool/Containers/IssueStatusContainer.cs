using System.Collections.Generic;
using RedmineTool.Models;
using Newtonsoft.Json;

namespace RedmineTool.Containers
{
    internal class IssueStatusesContainer : CollectionContainer
    {
        [JsonProperty("issue_statuses")]
        public IEnumerable<RedmineIssueStatus> Statuses { get; set; }
    }
}
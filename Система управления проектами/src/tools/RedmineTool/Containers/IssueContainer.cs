using System.Collections.Generic;
using RedmineTool.Models;

namespace RedmineTool.Containers
{
    internal class IssueContainer
    {
        public RedmineIssue Issue { get; set; }
    }

    internal class IssuesContainer : CollectionContainer
    {
        public IEnumerable<RedmineIssue> Issues { get; set; }
    }
}
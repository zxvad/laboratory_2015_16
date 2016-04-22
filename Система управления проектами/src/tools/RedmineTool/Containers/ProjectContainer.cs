using System.Collections.Generic;
using RedmineTool.Models;

namespace RedmineTool.Containers
{
    internal class ProjectContainer
    {
        public RedmineProject Project { get; set; }
    }

    internal class ProjectsContainer : CollectionContainer
    {
        public IEnumerable<RedmineProject> Projects { get; set; }
    }
}
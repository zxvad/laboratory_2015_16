using System.Collections.Generic;
using RedmineTool.Models;

namespace RedmineTool.Containers
{
    internal class VersionsContainer : CollectionContainer
    {
        public IEnumerable<RedmineVersion> Versions { get; set; }
    }
}
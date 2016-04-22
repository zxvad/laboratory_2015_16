using System.Collections.Generic;
using RedmineTool.Models;

namespace RedmineTool.Interfaces.Importers
{
    public interface IProjectImporter : IImporter<RedmineProject>
    {
        IEnumerable<RedmineVersion> GetAllProjectVersions(int projectId);
    }
}
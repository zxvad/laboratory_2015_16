using System.Collections.Generic;
using RedmineTool.Models;

namespace RedmineTool.Interfaces.Importers
{
    public interface IIssueStatusImporter
    {
        IEnumerable<RedmineIssueStatus> GetAll();
    }
}
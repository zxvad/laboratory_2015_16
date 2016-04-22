using RedmineTool.Importers;
using RedmineTool.Interfaces.Importers;

namespace RedmineTool.Infrastructure
{
    public static class ImporterFactory
    {
        public static IProjectImporter GetProjectImporter()
        {
            return new ProjectImporter(ApiFormats.Json);
        }

        public static ITimeRecordImporter GetTimeRecordImporter()
        {
            return new TimeRecordImporter(ApiFormats.Json);
        }

        public static IIssueImporter GetIssueImporter()
        {
            return new IssueImporter(ApiFormats.Json);
        }

        public static IEmployeeImporter GetEmployeeImporter()
        {
            return new EmployeeImporter(ApiFormats.Json);
        }

        public static IIssueStatusImporter GetIssueStatusesImporter()
        {
            return new IssueStatusImporter(ApiFormats.Json);
        }
    }
}
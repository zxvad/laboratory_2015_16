using System.Linq;
using RedmineTool.Infrastructure;
using RedmineTool.Interfaces.Importers;
using RedmineTool.Models;
using Xunit;

namespace ManagerReports.Tests.ImporterTests
{
    public class IssueStatusImporterTests
    {
        private readonly IIssueStatusImporter _issueStatusImporter;

        public IssueStatusImporterTests()
        {
            _issueStatusImporter = ImporterFactory.GetIssueStatusesImporter();
        }

        [Fact]
        public void GetSingleTest()
        {
            var actual = _issueStatusImporter.GetAll().Single(i => i.Id == 1);
            var expected = new RedmineIssueStatus
            {
                Id = 1,
                Name = "New",
                IsDefault = true
            };

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.IsDefault, actual.IsDefault);
        }

        [Fact]
        public void GetAllTest()
        {
            var actual = _issueStatusImporter.GetAll().Count();
            var expected = 14;
            Assert.Equal(expected, actual);
        }
    }
}
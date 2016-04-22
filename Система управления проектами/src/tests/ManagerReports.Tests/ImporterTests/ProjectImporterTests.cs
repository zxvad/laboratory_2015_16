using System;
using RedmineTool.Infrastructure;
using RedmineTool.Models;
using Xunit;
using System.Linq;
using RedmineTool.Interfaces.Importers;

namespace ManagerReports.Tests.ImporterTests
{
    public class ProjectImporterTests
    {
        private readonly IProjectImporter _projectImproter;

        public ProjectImporterTests()
        {
            _projectImproter = ImporterFactory.GetProjectImporter();
        }

        [Fact]
        public void GetSingleTest()
        {
            var actual = _projectImproter.GetById(2);
            var expected = new RedmineProject
            {
                Id = 2,
                Name = "_Redmine Support",
                CreatedOn = new DateTime(2013, 8, 12, 9, 14, 53),
                Description = ""
            };

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.CreatedOn, actual.CreatedOn);
            Assert.Equal(expected.Description, actual.Description);
        }

        [Fact]
        public void GetTotalRecordCountTest()
        {
            var actual = _projectImproter.GetTotalRecordCount();
            Assert.True(actual != 0);
        }

        [Fact]
        public void GetAllTest()
        {
            var actual = _projectImproter.GetAll().Count();
            var expected = _projectImproter.GetTotalRecordCount();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetWithNoVersionsTest()
        {
            var actual = _projectImproter.GetAllProjectVersions(92).Count();
            var expected = 0;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetWithVersionsTest()
        {
            var actual = _projectImproter.GetAllProjectVersions(13).Count();
            var expected = 31;
            Assert.Equal(expected, actual);
        }
    }
}
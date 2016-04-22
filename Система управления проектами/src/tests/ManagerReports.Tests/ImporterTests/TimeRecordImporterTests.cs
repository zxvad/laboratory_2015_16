using System;
using RedmineTool.Infrastructure;
using RedmineTool.Models;
using Xunit;
using System.Linq;
using RedmineTool.Interfaces.Importers;

namespace ManagerReports.Tests.ImporterTests
{
    public class TimeRecordImporterTests
    {
        private readonly ITimeRecordImporter _timeRecordImporter;

        public TimeRecordImporterTests()
        {
            _timeRecordImporter = ImporterFactory.GetTimeRecordImporter();
        }
        
        [Fact]
        public void GetSingleTest()
        {
            var actual = _timeRecordImporter.GetById(5);
            var expected = new RedmineTimeRecord
            {
                Id = 5,
                SpentOn = new DateTime(2013, 08, 19),
                Hours = 0.5m,
                Comments = "",
                Project = new RedmineIdNameObject
                {
                    Id = 13,
                    Name = "_Presale"
                },
                Activity = new RedmineIdNameObject
                {
                    Id = 8,
                    Name = "Проектирование"
                },
                User = new RedmineIdNameObject
                {
                    Id = 36,
                    Name = "Юдин Артем"
                },
                Issue = new RedmineIdNameObject
                {
                    Id = 93
                }
            };

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.SpentOn, actual.SpentOn);
            Assert.Equal(expected.Hours, actual.Hours);
            Assert.Equal(expected.Comments, actual.Comments);

            AssertIdNameObject(expected.Project, actual.Project);
            AssertIdNameObject(expected.Activity, actual.Activity);
            AssertIdNameObject(expected.User, actual.User);
            AssertIdNameObject(expected.Issue, actual.Issue);
        }

        [Fact]
        public void GetTotalRecordCountTest()
        {
            var actual = _timeRecordImporter.GetTotalRecordCount();
            Assert.True(actual != 0);
        }

        [Fact]
        public void GetManyTest()
        {
            var actual = _timeRecordImporter.GetMany(352);
            Assert.True(actual.Any());
        }

        private static void AssertIdNameObject(RedmineIdNameObject expected, RedmineIdNameObject actual)
        {
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
        }
    }
}
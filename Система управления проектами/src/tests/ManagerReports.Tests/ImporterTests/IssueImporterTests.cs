using System;
using RedmineTool.Infrastructure;
using RedmineTool.Models;
using Xunit;
using System.Linq;
using RedmineTool.Interfaces.Importers;

namespace ManagerReports.Tests.ImporterTests
{
    public class IssueImporterTests
    {
        private readonly IIssueImporter _issueImporter;

        public IssueImporterTests()
        {
            _issueImporter = ImporterFactory.GetIssueImporter();
        }

        [Fact]
        public void GetSingleTest()
        {
            var actual = _issueImporter.GetById(1000);
            var expected = new RedmineIssue
            {
                Id = 1000,
                Project = new RedmineIdNameObject
                {
                    Id = 3,
                    Name = "Сайт ЦВТ"
                },

                Status = new RedmineIdNameObject
                {
                    Id = 5,
                    Name = "Closed"
                },

                Priority = new RedmineIdNameObject
                {
                    Id = 2,
                    Name = "Нормальный"
                },

                Author = new RedmineIdNameObject
                {
                    Id = 13,
                    Name = "Столярова Екатерина"
                },

                AssignedTo = new RedmineIdNameObject
                {
                    Id = 58,
                    Name = "Алексеева Валерия"
                },

                ClosedOn = new DateTime(2013, 11, 15, 8, 42, 32),

                Description = "Сейчас альтернативный текст логотипа - это название текущего раздела. А должен быть на любой странице текст \"Центр высоких технологий\". ",
                Subject = "У логотпа неверный  альтернативный текст",
                StartDate = new DateTime(2013, 11, 5).Date
            };

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Subject, actual.Subject);
            Assert.Equal(expected.StartDate, actual.StartDate);
            Assert.Equal(expected.ClosedOn, actual.ClosedOn);

            AssertIdNameObject(expected.Project, actual.Project);
            AssertIdNameObject(expected.Status, actual.Status);
            AssertIdNameObject(expected.Priority, actual.Priority);
            AssertIdNameObject(expected.Author, actual.Author);
            AssertIdNameObject(expected.AssignedTo, actual.AssignedTo);
        }

        [Fact]
        public void GetTotalRecordCountTest()
        {
            var actual = _issueImporter.GetTotalRecordCount();
            Assert.True(actual != 0);
        }

        [Fact]
        public void GetAllTest()
        {
            var actual = _issueImporter.GetAll().Count();
            var expected = _issueImporter.GetTotalRecordCount();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetManyTest()
        {
            var actual = _issueImporter.GetMany(projectId: 2).Count();
            var expected = 41;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetManyNewOnlyTest()
        {
            var actual = _issueImporter.GetMany(projectId: 2, statusId: 1).Count();
            var expected = 2;
            Assert.Equal(expected, actual);
        }

        private static void AssertIdNameObject(RedmineIdNameObject expected, RedmineIdNameObject actual)
        {
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
        }
    }
}
using RedmineTool.Infrastructure;
using RedmineTool.Interfaces.Importers;
using RedmineTool.Models;
using Xunit;
using System.Linq;

namespace ManagerReports.Tests.ImporterTests
{
    public class EmployeeImporterTests
    {
        private readonly IEmployeeImporter _employeeImporter;

        public EmployeeImporterTests()
        {
            _employeeImporter = ImporterFactory.GetEmployeeImporter();
        }

        [Fact]
        public void GetSingleTest()
        {
            var actual = _employeeImporter.GetById(1);

            Assert.NotNull(actual);

            var expected = new RedmineEmployee
            {
                Id = 1,
                Login = "admin",
                FirstName = "Redmine",
                LastName = "Admin",
                Email = "ovasilyeva@htcmail.ru",
            };

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Login, actual.Login);
            Assert.Equal(expected.Email, actual.Email);
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
        }

        [Fact]
        public void GetTotalRecordCountTest()
        {
            var actual = _employeeImporter.GetTotalRecordCount();
            Assert.True(actual != 0);
        }

        [Fact]
        public void GetAllTest()
        {
            var actual = _employeeImporter.GetAll().Count();
            var expected = _employeeImporter.GetTotalRecordCount();
            Assert.Equal(expected, actual);
        }
    }
}
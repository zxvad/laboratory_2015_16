using System.Collections.Generic;
using ManagerReports.Dal;
using ManagerReports.Dal.Entities;
using RedmineTool.Interfaces.Repositories;
using RedmineTool.Models;
using System.Linq;

namespace RedmineTool.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ManagerReportsContext _dbContext;

        public EmployeeRepository()
        {
            _dbContext = new ManagerReportsContext(new Startup().Configuration);
        }

        public void Save(IEnumerable<RedmineEmployee> entities)
        {
            var employeeEntities = entities.Select(user => new EmployeeEntity
            {
                ExternalId = user.Id,
                Login = user.Login,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            });

            foreach (var employeeEntity in employeeEntities)
            {
                var sourceEmployee = _dbContext.Employees.FirstOrDefault(employee => employee.ExternalId == employeeEntity.ExternalId);

                if (sourceEmployee == null)
                {
                    _dbContext.Employees.Add(employeeEntity);
                }
                else
                {
                    sourceEmployee.FirstName = employeeEntity.FirstName;
                    sourceEmployee.LastName = employeeEntity.LastName;
                    sourceEmployee.Email = employeeEntity.Email;
                    sourceEmployee.Login = employeeEntity.Login;

                    _dbContext.Employees.Update(sourceEmployee);
                }
            }

            _dbContext.SaveChanges();
        }
    }
}
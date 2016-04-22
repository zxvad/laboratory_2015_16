using System;
using System.Collections.Generic;
using ManagerReports.Dal;
using ManagerReports.Services.Interfaces;
using ManagerReports.Services.Models;
using System.Linq;
using ManagerReports.Services.Extentions;

namespace ManagerReports.Services.Services
{
    /// <summary>
    ///     Бизнес-логика работы с сотрудниками
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly ManagerReportsContext _dbContext;

        public EmployeeService(ManagerReportsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Employee GetById(Guid id)
        {
            return _dbContext.Employees.Single(i => i.Id == id).ToEmployeeModel();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _dbContext.Employees.Where(i => i.TimeRecords.Any()).Select(i => i.ToEmployeeModel());
        }
    }
}
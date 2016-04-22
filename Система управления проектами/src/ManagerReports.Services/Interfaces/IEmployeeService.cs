using System;
using System.Collections.Generic;
using ManagerReports.Services.Models;

namespace ManagerReports.Services.Interfaces
{
    public interface IEmployeeService
    {
        /// <summary>
        ///     Возвращает информацию о сотруднике по заданному id
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        Employee GetById(Guid id);

        /// <summary>
        ///     Возвращает информацию о всех сотрудникахы
        /// </summary>
        IEnumerable<Employee> GetAll();
    }
}
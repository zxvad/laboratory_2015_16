using System;
using System.Collections.Generic;

namespace ManagerReports.Services.Interfaces.Reports
{
    public interface IReport<out T>
    {
        T GetReport(Guid id);
        IEnumerable<T> GetAllReports(DateTime? beginDate, DateTime? endDate);
    }
}
using System;

namespace ManagerReports.Services.Interfaces.Reports
{
    public interface IExcelReport
    {
        /// <summary>
        ///     Строит отчет за заданный период времени
        /// </summary>
        byte[] GetExcelReport(DateTime? beginDate, DateTime? endDate);
    }
}
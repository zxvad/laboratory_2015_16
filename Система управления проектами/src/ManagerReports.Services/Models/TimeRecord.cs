using System;
using System.Collections.Generic;

namespace ManagerReports.Services.Models
{
    public class TimeRecord : BaseModel
    {
        public string EmployeeFullName { get; set; }

        public string ProjectName { get; set; }

        public string ProjectVersionName { get; set; }

        public int? IssueId { get; set; }

        /// <summary>
        ///     Названия ресурсов, куда могло быть потрачено время
        /// </summary>
        public IEnumerable<string> ResourceNames { get; set; }

        /// <summary>
        ///     Дата затраченного времени
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        ///     Количество затраченного времени
        /// </summary>
        public decimal Hours { get; set; }

        /// <summary>
        ///     Деятельность
        /// </summary>
        public string Activity { get; set; }

        /// <summary>
        ///     Комментарии
        /// </summary>
        public string Comments { get; set; }
    }
}
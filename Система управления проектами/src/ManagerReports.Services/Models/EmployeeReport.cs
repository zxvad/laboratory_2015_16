using System.Collections.Generic;

namespace ManagerReports.Services.Models
{
    public class EmployeeReport
    {
        public Employee Employee { get; set; }

        /// <summary>
        ///     Сумма потраченных денег
        /// </summary>
        public decimal TakenMoney { get; set; }

        /// <summary>
        ///     Сумма потраченного времени
        /// </summary>
        public decimal TakenTime { get; set; }

        public IEnumerable<ProjectResource> ProjectResources { get; set; }

        public IEnumerable<TimeRecord> TimeRecords { get; set; }
        public IEnumerable<Resource> Resources { get; set; }
    }
}
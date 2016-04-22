using System.Collections.Generic;

namespace ManagerReports.Services.Models
{
    public class ProjectReport
    {
        public Project Project { get; set; }

        /// <summary>
        ///     Себестоимость проекта
        /// </summary>
        public decimal SelfCost { get; set; }

        /// <summary>
        ///     Версии проекта
        /// </summary>
        public IEnumerable<ProjectVerison> ProjectVerisons { get; set; }

        /// <summary>
        ///     Ресурсы проекта
        /// </summary>
        public IEnumerable<Resource> Resources { get; set; }

        /// <summary>
        ///     Поступившие оплаты по проекту
        /// </summary>
        public IEnumerable<PaymentRecord> Payments { get; set; }

        public IEnumerable<EmployeeTimeMoney> EmployeesWithoutResource { get; set; } 
    }
}
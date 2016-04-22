using System;
using System.Collections.Generic;

namespace ManagerReports.Services.Models
{
    public class ProjectVerison : BaseModel
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public DateTime CreatedOn { get; set; }

        /// <summary>
        ///     Сумма потраченных денег
        /// </summary>
        public decimal TakenMoney { get; set; }

        /// <summary>
        ///     Сумма потраченного времени
        /// </summary>
        public decimal TakenTime { get; set; }

        /// <summary>
        ///     Проданные ресурсы на проект
        /// </summary>
        public IEnumerable<Resource> Resources { get; set; }

        /// <summary>
        ///     Поступившие оплаты по проекту
        /// </summary>
        public IEnumerable<PaymentRecord> Payments { get; set; }

        public IEnumerable<EmployeeTimeMoney> EmployeesWithoutResource { get; set; }
    }
}
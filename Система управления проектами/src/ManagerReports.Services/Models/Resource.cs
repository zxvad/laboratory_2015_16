using System.Collections.Generic;

namespace ManagerReports.Services.Models
{
    public class Resource : BaseModel
    {
        /// <summary>
        ///     Название ресурса
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Рейт
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        ///     Количество проданных часов
        /// </summary>
        public decimal SoldHours { get; set; }

        /// <summary>
        ///     Сумма потраченных денег
        /// </summary>
        public decimal TakenMoney { get; set; }

        /// <summary>
        ///     Сумма потраченного времени
        /// </summary>
        public decimal TakenTime { get; set; }

        public IEnumerable<EmployeeTimeMoney> EmployeesTimeMonies { get; set; } 
    }
}
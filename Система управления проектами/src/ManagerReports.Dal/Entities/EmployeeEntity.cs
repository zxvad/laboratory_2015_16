using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerReports.Dal.Entities
{
    [Table("Employees")]
    public class EmployeeEntity : RedmineEntity
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        /// <summary>
        ///     Себестоимость работника
        /// </summary>
        public decimal SelfRate { get; set; }
        
        /// <summary>
        ///     Записи о затраченном времени
        /// </summary>
        public ICollection<TimeRecordEntity> TimeRecords { get; set; }

        /// <summary>
        ///     Все проданные ресурсы, где сотрудник участвовал в какой-либо роли
        /// </summary>
        public ICollection<EmployeeSoldResourceEntity> SoldResources { get; set; }

        [NotMapped]
        public string FullName => string.Concat(FirstName, ' ', LastName);
    }
}
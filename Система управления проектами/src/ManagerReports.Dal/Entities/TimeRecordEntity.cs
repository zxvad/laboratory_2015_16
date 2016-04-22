using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerReports.Dal.Entities
{
    [Table("TimeRecords")]
    public class TimeRecordEntity : RedmineEntity
    {
        /// <summary>
        ///     Дата затраченного времени
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        ///     Количество затраченного времени
        /// </summary>
        public decimal Hours { get; set; }

        /// <summary>
        ///     Тип выполняемых работ
        /// </summary>
        public string Activity { get; set; }

        /// <summary>
        ///     Комментарий к затраченному времени
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        ///     Сотрудник, потративший время на проект
        /// </summary>
        public Guid EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public EmployeeEntity Employee { get; set; }

        /// <summary>
        ///     Задача на проекте
        /// </summary>
        public Guid IssueId { get; set; }
        [ForeignKey(nameof(IssueId))]
        public IssueEntity Issue { get; set; }

        /// <summary>
        ///     Ресурсы, в которые может быть потрачено время
        /// </summary>
        public ICollection<ResourceTimeRecordEntity> Resources { get; set; } 
    }
}
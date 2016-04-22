using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerReports.Dal.Entities
{
    [Table("SoldResources")]
    public class SoldResourceEntity : BaseEntity
    {
        /// <summary>
        ///     Название ресурса
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Почасовая оплата ресурса
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        ///     Количество часов проданной роли
        /// </summary>
        public decimal Hours { get; set; }

        /// <summary>
        ///     Проект, на который продан ресурс
        /// </summary>
        public Guid ProjectId { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public ProjectEntity Project { get; set; }

        public int? ProjectVersionId { get; set; }
        [ForeignKey(nameof(ProjectVersionId))]
        public ProjectVersionEntity ProjectVersion { get; set; }

        /// <summary>
        ///     Все сотрудники, выполняющие роль на проекте
        /// </summary>
        public ICollection<EmployeeSoldResourceEntity> Employees { get; set; }

        /// <summary>
        ///     Записи о времени, потраченном на ресурс
        /// </summary>
        public ICollection<ResourceTimeRecordEntity> TimeRecords { get; set; } 
    }
}
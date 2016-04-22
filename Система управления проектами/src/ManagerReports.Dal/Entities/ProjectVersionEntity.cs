using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerReports.Dal.Entities
{
    [Table("ProjectVersions")]
    public class ProjectVersionEntity : RedmineEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }

        public Guid ProjectId { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public ProjectEntity Project { get; set; }

        /// <summary>
        ///     Записи о поступлениях платежей по проекту
        /// </summary>
        public ICollection<PaymentRecordEntity> Payments { get; set; }

        /// <summary>
        ///     Проданные ресурсы
        /// </summary>
        public ICollection<SoldResourceEntity> SoldResources { get; set; }

        /// <summary>
        ///     Задачи проекта
        /// </summary>
        public ICollection<IssueEntity> Issues { get; set; }
    }
}
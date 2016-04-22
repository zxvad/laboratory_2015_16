using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerReports.Dal.Entities
{
    [Table("Payments")]
    public class PaymentRecordEntity : BaseEntity
    {
        /// <summary>
        ///     Дата платежа
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        ///     Сумма платежа
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        ///     Проект, по которому поступил платеж
        /// </summary>
        public Guid ProjectId { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public ProjectEntity Project { get; set; }

        public int? ProjectVersionId { get; set; }
        [ForeignKey(nameof(ProjectVersionId))]
        public ProjectVersionEntity ProjectVersion { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerReports.Dal.Entities
{
    [Table("Projects")]
    public class ProjectEntity : RedmineEntity
    {
        public string Name { get; set; }

        /// <summary>
        ///     Дата начала проекта
        /// </summary>
        public DateTime? BegintDate { get; set; }

        /// <summary>
        ///     Флаг наличия проблем по проекту (перересход бюджета, времени и пр.)
        /// </summary>
        public bool HasProblems { get; set; }

        /// <summary>
        ///     Тип валюты проекта
        /// </summary>
        public CurrencyTypes Currency { get; set; }

        /// <summary>
        ///     Описание проекта
        /// </summary>
        public string Description { get; set; }

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

        /// <summary>
        ///     Версии проекта
        /// </summary>
        public ICollection<ProjectVersionEntity> Versions { get; set; } 
    }
}
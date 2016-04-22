using System;
using ManagerReports.Dal;

namespace ManagerReports.Services.Models
{
    public class Project : BaseModel
    {
        public string Name { get; set; }
        public decimal? Budget { get; set; }
        public CurrencyTypes Currency { get; set; }

        /// <summary>
        ///     Дата начала проекта
        /// </summary>
        public DateTime? BeginDate { get; set; }

        /// <summary>
        ///     Количество проданных часов на проект
        /// </summary>
        public decimal? SoldHours { get; set; }

        /// <summary>
        ///     Флаг наличия проблем по проекту (перересход бюджета, времени и пр.)
        /// </summary>
        public bool HasProblems { get; set; }

        /// <summary>
        ///     Оплаченная сумма по проекту
        /// </summary>
        public decimal? PaidAmount { get; set; }

        /// <summary>
        ///     Затраченное время на проекте
        /// </summary>
        public decimal? TakenTime { get; set; }

        /// <summary>
        ///     Количество денег, потраченых на данный момент
        /// </summary>
        public decimal TakenMoney { get; set; }
    }
}
using System;
using System.Collections.Generic;
using ManagerReports.Services.Models;

namespace ManagerReports.Services.Interfaces
{
    public interface IPaymentService
    {
        /// <summary>
        ///     Добавляет оплату по проекту
        /// </summary>
        /// <param name="projectId">Id проекта</param>
        /// <param name="payment">Размер оплаты</param>
        /// <param name="projectVersionId">Id версии проекта</param>
        /// <returns>Созданную запись</returns>
        PaymentRecord Add(Guid projectId, int? projectVersionId, DateTime date, decimal amount);

        /// <summary>
        ///     Удаляет запись об оплате
        /// </summary>
        /// <param name="paymentId">Id записи</param>
        void Remove(Guid paymentId);

        /// <summary>
        ///     Обновляет существующую запись
        /// </summary>
        /// <param name="paymentId">Id записи</param>
        /// <param name="projectVersionId">Id версии проекта</param>
        /// <param name="date">Дата создания</param>
        /// <param name="amount">Сумма</param>
        void Update(Guid paymentId, int? projectVersionId, DateTime date, decimal amount);

        /// <summary>
        ///     Возвращает запись об обплате по проекту
        /// </summary>
        /// <param name="projectId">Id проекта</param>
        /// <param name="paymentId">Id записи</param>
        PaymentRecord GetPaymentRecordById(Guid projectId, Guid paymentId);

        /// <summary>
        ///     Возвращает все записи об оплате по проекту
        /// </summary>
        /// <param name="projectId">Id проекта</param>
        IEnumerable<PaymentRecord> GetAllPaymentRecords(Guid projectId);
    }
}
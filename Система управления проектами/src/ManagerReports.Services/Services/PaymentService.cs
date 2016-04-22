using System;
using System.Collections.Generic;
using ManagerReports.Dal;
using ManagerReports.Dal.Entities;
using ManagerReports.Services.Interfaces;
using ManagerReports.Services.Models;
using Microsoft.Data.Entity;
using System.Linq;

namespace ManagerReports.Services.Services
{
    /// <summary>
    ///     Бизнес-логика работы с платежами
    /// </summary>
    public class PaymentService : IPaymentService
    {
        private readonly ManagerReportsContext _dbContext;

        public PaymentService(ManagerReportsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PaymentRecord Add(Guid projectId, int? projectVersionId, DateTime date, decimal amount)
        {
            var paymentRecord = new PaymentRecordEntity
            {
                ProjectId = projectId,
                ProjectVersionId = projectVersionId,
                Date = date,
                Amount = amount
            };

            _dbContext.Payments.Add(paymentRecord);
            _dbContext.SaveChanges();

            return new PaymentRecord
            {
                Id = paymentRecord.Id,
                ProjectVersionId = paymentRecord.ProjectVersionId,
                Date = paymentRecord.Date,
                Amount = paymentRecord.Amount
            };
        }

        public void Remove(Guid paymentId)
        {
            var paymentRecord = _dbContext.Payments.SingleOrDefault(i => i.Id == paymentId);

            if (paymentRecord == null)
            {
                throw new ArgumentException(nameof(paymentId));
            }

            _dbContext.Payments.Remove(paymentRecord);
            _dbContext.SaveChanges();
        }

        public void Update(Guid paymentId, int? projectVersionId, DateTime date, decimal amount)
        {
            var paymentRecord = _dbContext.Payments.SingleOrDefault(i => i.Id == paymentId);

            if (paymentRecord == null)
            {
                throw new ArgumentException(nameof(paymentId));
            }

            paymentRecord.Date = date;
            paymentRecord.Amount = amount;
            paymentRecord.ProjectVersionId = projectVersionId;

            _dbContext.Payments.Update(paymentRecord);
            _dbContext.SaveChanges();
        }

        public PaymentRecord GetPaymentRecordById(Guid projectId, Guid paymentId)
        {
            return
                (from payment in _dbContext.Payments.AsNoTracking()
                 where payment.Id == paymentId && payment.ProjectId == projectId
                 select new PaymentRecord
                 {
                     Id = payment.Id,
                     Date = payment.Date,
                     Amount = payment.Amount
                 })
                .FirstOrDefault();
        }

        public IEnumerable<PaymentRecord> GetAllPaymentRecords(Guid projectId)
        {
            return
                from payment in _dbContext.Payments.AsNoTracking()
                where payment.ProjectId == projectId
                select new PaymentRecord
                {
                    Id = payment.Id,
                    Date = payment.Date,
                    Amount = payment.Amount
                };
        }
    }
}